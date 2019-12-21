using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {
    [SerializeField]
    private string StartingSceneName;
    [SerializeField]
    private string TargetSpawnName;
    [SerializeField]
    private GameObject player;

    // Use this for initialization
    private void Awake () {
        InitItemDB();
        StartCoroutine(DoInitialTransition());
        GameData.AddNewCharacter(PlayerCharacters.MainCharacter);
        GameData.AddCharacterToParty(PlayerCharacters.MainCharacter);
        GameData.AddNewCharacter(PlayerCharacters.Yurgurine);
        GameData.AddCharacterToParty(PlayerCharacters.Yurgurine);

        Inventory.AddItemToInventory("potion", 7);
        Inventory.AddItemToInventory("hi-potion", 2);
        Inventory.AddItemToInventory(new FangOfDestroyer(), 1);
        Inventory.AddItemToInventory("poison", 2);
        Inventory.AddItemToInventory("elixir", 1);
    }

    private IEnumerator DoInitialTransition() {
        GameData.PlayerCanTransition = false;
        player.GetComponent<SpriteRenderer>().enabled = true;
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(StartingSceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone) {
            yield return null;
        }

        GameObject spawn = GameObject.Find(TargetSpawnName);
        spawn.GetComponent<Spawn>().clearTransit = true;
        player.transform.position = spawn.transform.position;
        player.GetComponent<CharacterMover>().StopMoving();
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(StartingSceneName));
        SceneManager.UnloadSceneAsync(currentScene);
    }

    private void InitItemDB() {
        Inventory.AddItemToDatabase(new Potion());
        Inventory.AddItemToDatabase(new HiPotion());
        Inventory.AddItemToDatabase(new FangOfDestroyer());
        Inventory.AddItemToDatabase(new Poison());
        Inventory.AddItemToDatabase(new Elixir());
    }
}
