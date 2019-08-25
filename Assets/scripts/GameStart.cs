using System.Collections;
using System.Collections.Generic;
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
        PlayerCharacter mainCharacter = PlayerCharacters.MainCharacter;
        GameData.addNewCharacter(mainCharacter);
        GameData.addCharacterToParty(mainCharacter);
    }

    IEnumerator DoInitialTransition() {
        GameData.PlayerCanTransition = false;
        Scene currentScene = SceneManager.GetActiveScene();

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(StartingSceneName, LoadSceneMode.Additive);

        while (!asyncLoad.isDone) {
            yield return null;
        }

        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(StartingSceneName));
        GameObject spawn = GameObject.Find(TargetSpawnName);
        spawn.GetComponent<Spawn>().clearTransit = true;
        player.transform.position = spawn.transform.position;
        player.GetComponent<CharacterMover>().StopMoving();
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
