using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToPixelGrid : MonoBehaviour {

	private Transform parent;

	// Use this for initialization
	void Start () {
		parent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void LateUpdate() {
		Vector3 newLocalPosition = Vector3.zero;

		newLocalPosition.x = 0;
		newLocalPosition.y = 0;

		// newLocalPosition.x = (Mathf.Round(parent.position.x * 16) / 16) - parent.position.x;
		// newLocalPosition.y = (Mathf.Round(parent.position.y * 16) / 16) - parent.position.y;
		newLocalPosition.z = transform.localPosition.z;

		transform.localPosition = newLocalPosition;
	}
}
