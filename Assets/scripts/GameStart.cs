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
    void Awake () {
        StartCoroutine(DoInitialTransition());
        GameData.addNewCharacter(PlayerCharacters.MainCharacter);
        GameData.addCharacterToParty(PlayerCharacters.MainCharacter);
        GameData.addNewCharacter(PlayerCharacters.Yurgurine);
        GameData.addCharacterToParty(PlayerCharacters.Yurgurine);

        Inventory.AddItemToInventory(new Potion(), 1);
        Inventory.AddItemToInventory(new HiPotion(), 1);
        Inventory.AddItemToInventory(new Potion(), 2);
        Inventory.AddItemToInventory(new FangOfDestroyer(), 1);
        Inventory.AddItemToInventory(new Poison(), 2);
        Inventory.AddItemToInventory(new Elixir(), 1);
    }

    IEnumerator DoInitialTransition() {
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
}
