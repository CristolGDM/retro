using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDeleteOnLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}
}
