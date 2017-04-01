using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinFlipBehavior : MonoBehaviour {

    public GameObject coinSideA;
    public GameObject coinSideB;
    public GameObject noCoin;
    private bool SideAactive = true;
    private bool lostCoin = false;
    private float time = 0;

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
        if (Input.GetKeyUp(KeyCode.Y))
        {
            lostCoin = true;
        }
        if (lostCoin)
        {
            time += Time.deltaTime;
            if (time > 5)
            {
                lostCoin = false;
                time = 0;
                coinSideA.SetActive(true);
                coinSideB.SetActive(false);
                noCoin.SetActive(false);
                SideAactive = true;
            }
            else
            {
                coinSideA.SetActive(false);
                coinSideB.SetActive(false);
                noCoin.SetActive(true);
            }
        
        }
    }
}
