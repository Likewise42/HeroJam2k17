using UnityEngine;
using System.Collections;

public class MoveControls : MonoBehaviour {

    public float moveSpeed;
    private float inputDirection; //X Value of moveVector
    private float verticalVelocity; //Y Value of moveVector
    public float jump;
    private float gravity;
    public bool dashPower;
    public float dashTimer;
    public float dashLimit;
    public float dashWaitLimit;
    public float dashingTimer;
    public bool dashReady;
    public bool dashReplenish;
    public bool dashing;
    private bool facingRight;
    private Vector3 moveVector;
    private CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        gravity = 1.0f;
        jump = 20;
        dashTimer = 0.0f;
        dashReady = true;
        dashing = false;
        dashReplenish = false;
        dashPower = true;
    }
	
	// Update is called once per frame
	void Update () {

        inputDirection = Input.GetAxis("Horizontal") * moveSpeed;

        //Switching Powers
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if(dashPower)
            {
                dashPower = false;
            }
            else
            {
                dashPower = true;
            }
        }

        //Jump Power
        if(!dashPower)
        {
            jump = 40;
        }
        else
        {
            jump = 20;
        }

        //Dash Power
        if (dashPower)
        {
            if (Input.GetKey(KeyCode.S) && dashReady) //They want to dash and can
            {
                dashing = true;
            }

            if (dashing) //The Dash lasts for a certain amount of time
            {
                inputDirection *= 4;
                dashingTimer += Time.deltaTime;
                dashReady = false;
            }

            if (dashingTimer >= dashLimit) //Their dash time is up
            {
                dashing = false;
                dashReplenish = true;
                dashingTimer -= dashLimit;
            }

            if (dashReplenish) //Dash power needs to be replenished
            {
                dashTimer += Time.deltaTime;
            }

            if (dashTimer >= dashWaitLimit) //Their dash is replenished
            {
                dashReplenish = false;
                dashReady = true;
                dashTimer -= dashWaitLimit;
            }
        }

        if (controller.isGrounded) //They are on the ground
        {
            verticalVelocity = 0;

            if(Input.GetAxis("Horizontal") == -1) //Going Left
            {
                transform.forward = new Vector3(-1, 0, 0);
                facingRight = false;
            }
            if (Input.GetAxis("Horizontal") == 1) //Going Right
            {
                transform.forward = new Vector3(1, 0, 0);
                facingRight = true;
            }

            if (Input.GetKey(KeyCode.W)) //Jumping
            {
                verticalVelocity = jump;
            }
        }
        else
        {
            verticalVelocity -= gravity; //Gravity Stuff
        }

        moveVector = new Vector3(inputDirection, verticalVelocity, 0);
        controller.Move(moveVector * Time.deltaTime);
    }
}
