using UnityEngine;
using System.Collections;

public class Sidescroller_MoveControls : MonoBehaviour {

    public float moveSpeed;
    private float inputDirection; //X Value of moveVector
    private float verticalVelocity; //Y Value of moveVector
    private float gravity;
    private Vector3 moveVector;
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        gravity = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {

        inputDirection = Input.GetAxis("Horizontal") * moveSpeed;

        if (controller.isGrounded)
        {
            verticalVelocity = 0;

            if (Input.GetKey(KeyCode.Space))
            {
                verticalVelocity = 20;
            }
        }
        else
        {
            verticalVelocity -= gravity;
        }

        moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
    }
}
