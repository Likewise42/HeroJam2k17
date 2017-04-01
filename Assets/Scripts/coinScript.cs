using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour {

    public GameObject playerObject;
    private MoveControls playerMoveScript;
    public float moveForwardTimer;
    public bool moveForward;
    public float coinSpeed;
    private bool direction;
    private Vector3 moveVector;
    private CharacterController controller;

    // Use this for initialization
    void Start () {
        moveForward = true;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerMoveScript = (MoveControls) playerObject.GetComponent("MoveControls");
        direction = playerMoveScript.getDirection();
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (moveForward)
        {
            moveForwardTimer -= Time.deltaTime;

            if (direction)
            {
                moveVector = new Vector3(coinSpeed, 0, 0);
            }else
            {
                moveVector = new Vector3(coinSpeed * -1, 0, 0);
            }
            

            if(moveForwardTimer < 0)
            {
                moveForward = false;
            }
        }else
        {
            moveVector = playerObject.transform.position - gameObject.transform.position;

            if(moveVector.magnitude < 2)
            {
                Destroy(gameObject);
            }

            moveVector.Normalize();
            moveVector *= coinSpeed;
        }

        controller.Move(moveVector * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        
    }
}
