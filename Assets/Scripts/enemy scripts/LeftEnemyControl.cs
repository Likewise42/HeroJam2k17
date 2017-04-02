using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftEnemyControl : MonoBehaviour {

    public float moveSpeed;
    private float inputDirection;
    private float verticalVelocity;
    private float gravity;
    private float direction;
    private Vector3 moveVector;
    private CharacterController controller;

    public GameObject gameManager;
    public gmScript gameManagerScript;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        gravity = 1.0f;
        direction = -1.0f;

        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        gameManagerScript = (gmScript)gameManager.GetComponent<gmScript>();
    }
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded)
        {
            verticalVelocity = 0;
        }
        else
        {
            verticalVelocity -= gravity;
        }

        inputDirection = direction * moveSpeed;

        moveVector = new Vector3(inputDirection, verticalVelocity, 0);

        controller.Move(moveVector * Time.deltaTime);
	}

    void changeDirection () {
        direction = direction * -1;
    }
    void OnTriggerEnter(Collider other) {
        
        if (other.tag == "enemyChange") {
            changeDirection();
        }

        if(other.tag == "coin")
        {
            gameManagerScript.heroPoints += 100;
            Destroy(gameObject);
        }
    }

}
