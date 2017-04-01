using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinFlipBehavior : MonoBehaviour {

    public GameObject coinSideA;
    public GameObject coinSideB;
    public GameObject noCoin;
    private bool SideAactive = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Space))
        {
            SideAactive = !SideAactive;
            coinSideA.SetActive(SideAactive);
            coinSideB.SetActive(!SideAactive);
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Pause");
        }
    }
}
