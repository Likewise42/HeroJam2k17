using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemyControl : MonoBehaviour {


    private float inputDirection;
    private float verticalVelocity;
    private float gravity;
    private float startY;
    private float topY;

    public GameObject gameManager;
    public gmScript gameManagerScript;

    private Vector3 moveVector;
    private CharacterController controller;

    // Use this for initialization
    void Start() {
        controller = GetComponent<CharacterController>();
        gravity = 2.0f;
        startY = transform.position.y;
        topY = startY + .5f;
        verticalVelocity = gravity;

        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        gameManagerScript = (gmScript)gameManager.GetComponent<gmScript>();
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.y > topY) {
            verticalVelocity = -1 * gravity;
        }
        else if(transform.position.y < startY) {
            verticalVelocity = gravity;
        }

        moveVector = new Vector3(0, verticalVelocity, 0);

        controller.Move(moveVector * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            gameManagerScript.heroPoints += 100;
            Destroy(gameObject);
        }
    }

}
