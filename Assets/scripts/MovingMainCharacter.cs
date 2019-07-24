using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingMainCharacter : MonoBehaviour {
	public Animator animator;
	Vector3 pos;
	float speed = 4.0f;

	// Use this for initialization
	void Start () {
		pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKey("up") || Input.GetKey("w")) && transform.position == pos) {				// UP
			animator.SetInteger("Direction", 2);
			animator.SetBool("Moving", true);
			pos += Vector3.up;
		}
		else if ((Input.GetKey("down") || Input.GetKey("s")) && transform.position == pos) {		// DOWN
			animator.SetInteger("Direction", 0);
			animator.SetBool("Moving", true);
			pos += Vector3.down;
		}
		else if ((Input.GetKey("left") || Input.GetKey("a")) && transform.position == pos) {		// LEFT
			animator.SetInteger("Direction", 1);
			animator.SetBool("Moving", true);
			pos += Vector3.left;
		}
		else if ((Input.GetKey("right") || Input.GetKey("d")) && transform.position == pos) {		// RIGHT
			animator.SetInteger("Direction", 3);
			animator.SetBool("Moving", true);
			pos += Vector3.right;
		}

		else if(transform.position == pos) {
			animator.SetBool("Moving", false);
		}

		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}
}
