using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRendererOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
		foreach (Renderer childRenderer in allRenderers) {
			childRenderer.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
