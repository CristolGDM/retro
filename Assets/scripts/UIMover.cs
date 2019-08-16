using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMover : MonoBehaviour {

    private Vector3 pos;

    // Use this for initialization
    void Start () {
        pos = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position != pos) {
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 888);
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
