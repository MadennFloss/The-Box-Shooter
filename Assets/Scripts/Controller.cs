using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	// public variables
	public float moveSpeed = 3.0f;
	public float gravity = 9.81f;
    public float jumpSpeed = 15.0f;
    public float minFall = -1.5f;
    public float terminalVelocity = -10.0f;

	private CharacterController myController;
    private bool groundedPlayer;
    private float vertSpeed;

    // Use this for initialization
    void Start () {
		// store a reference to the CharacterController component on this gameObject
		// it is much more efficient to use GetComponent() once in Start and store
		// the result rather than continually use etComponent() in the Update function
		myController = gameObject.GetComponent<CharacterController>();
        vertSpeed = minFall;
	}
	
	// Update is called once per frame
	void Update () {
        groundedPlayer = myController.isGrounded;

        // Determine how much should move in the z-direction
        Vector3 movementZ = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed * Time.deltaTime;

		// Determine how much should move in the x-direction
		Vector3 movementX = Input.GetAxis("Horizontal") * Vector3.right * moveSpeed * Time.deltaTime;

		// Convert combined Vector3 from local space to world space based on the position of the current gameobject (player)
		Vector3 movement = transform.TransformDirection(movementZ+movementX);

        //Jumping;
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump"))
                vertSpeed = jumpSpeed;//Move player up with vertSpeed when key downed
            else
                vertSpeed = minFall;//apply minFall speed when key button up
        }
        else
        {
            vertSpeed += (-gravity) * 5 * Time.deltaTime;//if player not grounded apply gravity in deltaTime
            if (vertSpeed < terminalVelocity)
            {
                vertSpeed = terminalVelocity;
            }
        }

        // Apply gravity (so the object will fall if not grounded)
        movement.y = vertSpeed * Time.deltaTime;

        // Actually move the character controller in the movement direction
        myController.Move(movement);
	}
}
