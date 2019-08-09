using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MovingMainCharacter : MonoBehaviour {
    public Animator animator;
    public Texture2D spriteSheet;

    private Vector3 pos;
    private float speed = 4.0f;
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private string modelSpritesheetName = "test-Sheet";

    // Use this for initialization
    void Start () {
        pos = transform.position;
        sprites = Resources.LoadAll<Sprite>("sprites/" + spriteSheet.name);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

	// Update is called once per frame
	void Update () {

		if ((Input.GetKey("up") || Input.GetKey("w")) && transform.position == pos) {				// UP
			animator.SetInteger("Direction", 2);
			MoveInDirection(Vector3.up);
		}
		else if ((Input.GetKey("down") || Input.GetKey("s")) && transform.position == pos) {		// DOWN
			animator.SetInteger("Direction", 0);
			MoveInDirection(Vector3.down);
		}
		else if ((Input.GetKey("left") || Input.GetKey("a")) && transform.position == pos) {		// LEFT
			animator.SetInteger("Direction", 1);
			MoveInDirection(Vector3.left);
		}
		else if ((Input.GetKey("right") || Input.GetKey("d")) && transform.position == pos) {		// RIGHT
			animator.SetInteger("Direction", 3);
			MoveInDirection(Vector3.right);
		}

		else if(transform.position == pos) {
			animator.SetBool("Moving", false);
		}
		transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
	}

    private void LateUpdate() {
        string currentSpriteName = spriteRenderer.sprite.name;
        string newSpritename = currentSpriteName.Replace(modelSpritesheetName, spriteSheet.name);
        //Sprite newSprite;
        foreach (var sprite in sprites) {
            //Debug.Log(sprite.name + " / " + newSpritename);
            if (sprite.name == newSpritename) {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }
    /////////////////////////////////

    void MoveInDirection(Vector3 direction){
		RaycastHit2D raycast = Physics2D.Raycast(transform.position + direction, direction, 0.1f);
		if(raycast.collider && raycast.collider.tag != "Traversable"){
			animator.SetBool("Moving", false);
		}
		else {
			animator.SetBool("Moving", true);
			pos += direction;
		}
	}

}
