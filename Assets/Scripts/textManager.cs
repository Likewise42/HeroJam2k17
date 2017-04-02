using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textManager : MonoBehaviour {

    public GameObject HPTextObj;
    public Text HPText;
    public GameObject HPEarnedTextObj;
    public Text HPEarnedText;

    public GameObject gameManager;
    public gmScript gameManagerScript;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        gameManagerScript = (gmScript) gameManager.GetComponent<gmScript>();

        HPText.text = "Hero Points: "+gameManagerScript.heroPoints;
        HPEarnedText.text = "Hero Points Required: " + gameManagerScript.requiredHeroPoints;
    }
	
	// Update is called once per frame
	void Update () {
        HPText.text = "Hero Points: " + gameManagerScript.heroPoints;
    }
}
