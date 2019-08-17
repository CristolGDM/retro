using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMover : MonoBehaviour {

    private Vector3 pos;

    // Use this for initialization
    void Start () {
        pos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition != pos) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, Time.deltaTime * 48);
        }
    }

    /////////
    
    public void MoveToNewPosition(Vector3 newPos) {
        pos = newPos;
    }
    public void MoveToNewPosition(Vector2 newPos) {
        MoveToNewPosition(new Vector3(newPos.x, newPos.y));
    }
}
