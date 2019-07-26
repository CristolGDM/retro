using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTo : MonoBehaviour {

	public string TargetScene;
	public string TargetSpawn;


	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.name == "MainCharacter") {
			StartCoroutine(DoSceneTransition(collider.gameObject));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	////////////

	IEnumerator DoSceneTransition(GameObject player){
		Scene currentScene = SceneManager.GetActiveScene();

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(TargetScene, LoadSceneMode.Additive);

		while(!asyncLoad.isDone) {
			yield return null;
		}

		SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(TargetScene));
		GameObject spawn = GameObject.Find(TargetSpawn);
		player.transform.position = spawn.transform.position;
		SceneManager.UnloadSceneAsync(currentScene);
	}
}
