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
        GameData.addNewCharacter(PlayerCharacters.MainCharacter);
        GameData.addCharacterToParty(PlayerCharacters.MainCharacter);
        GameData.addNewCharacter(PlayerCharacters.Yurgurine);
        GameData.addCharacterToParty(PlayerCharacters.Yurgurine);
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
