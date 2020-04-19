using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    //Edit the value in editor, influences the speed at which the player moves.
	[SerializeField]private float moveSpeed;

    //Rigidbody of the object used for movement.
	private Rigidbody rigidbody;
    //Velocity to influence where the player moves depending on the input
	private Vector3 velocity;
    //Used to make the character face the direction your mouse is.
	private Camera viewCamera;

    //Using Start to assign a rigidbody and a camera to the variables made above
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
		viewCamera = Camera.main;
	}

    //Using Update to make the Player face the mouse direction, and to calculate the velocity.
	void Update () {
		Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
		transform.LookAt (mousePos + Vector3.up * transform.position.y);
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * moveSpeed;
	}

    //Using FixedUpdate for moving the character
	void FixedUpdate() {
		rigidbody.MovePosition (rigidbody.position + velocity * Time.fixedDeltaTime);
	}
}