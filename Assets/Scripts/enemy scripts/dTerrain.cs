using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dTerrain : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.tag == "coin") {
            Destroy(gameObject);
        }
    }
}
