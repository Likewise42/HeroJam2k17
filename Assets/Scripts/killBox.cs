using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBox : MonoBehaviour {

    public GameObject player;
    public MoveControls playerScript;
    
    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = (MoveControls)player.GetComponent<MoveControls>();
    }

    void OnTriggerStay(Collider other)
    {

        if(other.tag == "Player")
        {
            playerScript.dead = true;
        }
    }
}
