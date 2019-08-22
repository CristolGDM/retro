using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ShowRendererOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<TilemapRenderer>().enabled = true;
	}

}
