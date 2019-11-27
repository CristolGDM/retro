using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class CharacterMover : MonoBehaviour {
    public Animator animator;
    public Texture2D spriteSheet;

    private Vector3 pos;
    private float speed = 4.0f;
    private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private string modelSpritesheetName = "test-Sheet";
    private bool canMove = true;
    private Vector3 originalPosition;

    // Use this for initialization
    public void Start () {
        pos = transform.position;
        originalPosition = transform.position;
        sprites = Resources.LoadAll<Sprite>("sprites/spritesheets/" + spriteSheet.name);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update() {
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        if (!animator.GetBool("Moving")) transform.position = pos;
        if (transform.position == pos) animator.SetBool("Moving", false);
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        pos = originalPosition;
    }


    public void LateUpdate() {
        string currentSpriteName = spriteRenderer.sprite.name;
        string newSpritename = currentSpriteName.Replace(modelSpritesheetName, spriteSheet.name);
        foreach (var sprite in sprites) {
            if (sprite.name == newSpritename) {
                spriteRenderer.sprite = sprite;
                break;
            }
        }
    }
    /////////////////////////////////
    
    private bool IsMoving() {
        return animator.GetBool("Moving");
    }

    private void MoveInDirection(Vector3 direction){
		RaycastHit2D raycast = Physics2D.Raycast(transform.position + direction, direction, 0.1f);
		if(raycast.collider && raycast.collider.tag != "Traversable") {
			animator.SetBool("Moving", false);
		}
		else {
            originalPosition = pos;
			animator.SetBool("Moving", true);
			pos += direction;
		}
    }

    public IEnumerator MoveUp() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", 2);
            MoveInDirection(Vector3.up);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }
    public IEnumerator MoveDown() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", 0);
            MoveInDirection(Vector3.down);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }
    public IEnumerator MoveLeft() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", 1);
            MoveInDirection(Vector3.left);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }
    public IEnumerator MoveRight() {
        if (transform.position == pos) {
            animator.SetInteger("Direction", 3);
            MoveInDirection(Vector3.right);
            yield return new WaitWhile(IsMoving);
        }
        yield break;
    }

    public void StopMoving() {
            animator.SetBool("Moving", false);
            pos = transform.position;
    }

    public Vector3 GetCurrentDirection() {
        switch (animator.GetInteger("Direction")){
            case 1: return Vector3.left;
            case 2: return Vector3.up;
            case 3: return Vector3.right;

            default: return Vector3.down;
        };
    }

    public bool CanMove {
        get {
            return canMove;
        }
        set {
            canMove = value;
        }
    }
}
