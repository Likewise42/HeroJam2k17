using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sidescroller_Camera : MonoBehaviour {

    public Transform target;
    public float cameraSpeed = 10;
    public float zOffset = 15;
    public bool smoothFollow = true;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 newPos = transform.position;
            newPos.x = target.position.x;
            newPos.y = target.position.y + 2;

            if (!smoothFollow)
            {
                transform.position = newPos;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, newPos, cameraSpeed * Time.deltaTime);
            }

            transform.position.Set(transform.position.x, transform.position.y, transform.position.z - 10);
        }
	}
}
