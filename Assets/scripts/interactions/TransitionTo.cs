﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTo : MonoBehaviour {

    [SerializeField]
    private string TargetSceneName;

    [SerializeField]
    private string TargetSpawnName;


    // Use this for initialization
    void Start () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.name == "MainCharacter" && GameData.PlayerCanTransition) {
			StartCoroutine(DoSceneTransition(collider.gameObject));
		}
	}

    // Update is called once per frame
    void Update () {
		
	}

	////////////

	IEnumerator DoSceneTransition(GameObject player){
        GameData.PlayerCanTransition = false;
		Scene currentScene = SceneManager.GetActiveScene();

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(TargetSceneName, LoadSceneMode.Additive);

		while(!asyncLoad.isDone) {
			yield return null;
		}

		SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(TargetSceneName));
		GameObject spawn = GameObject.Find(TargetSpawnName);
        spawn.GetComponent<Spawn>().clearTransit = true;
		player.transform.position = spawn.transform.position;
        player.GetComponent<CharacterMover>().StopMoving();
		SceneManager.UnloadSceneAsync(currentScene);
	}
}