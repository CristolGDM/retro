using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMover : MonoBehaviour {

    private Vector3 pos;
    private int speed = 4;
    private int defaultSpeed = 4;

    // Use this for initialization
    void Start () {
        pos = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition != pos) {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, pos, Time.deltaTime * speed);
        }
    }

    /////////


    public void MoveToNewPosition(Vector3 newPos, int newSpeed) {
        speed = newSpeed;
        pos = newPos;
    }
    public void MoveToNewPosition(Vector2 newPos, int newSpeed) {
        MoveToNewPosition(new Vector3(newPos.x, newPos.y), newSpeed);
    }

    public void MoveToNewPosition(Vector3 newPos) {
        MoveToNewPosition(newPos, defaultSpeed);
    }
    public void MoveToNewPosition(Vector2 newPos) {
        MoveToNewPosition(new Vector3(newPos.x, newPos.y), defaultSpeed);
    }
}
