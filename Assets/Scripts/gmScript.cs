using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gmScript : MonoBehaviour {

    public int heroPoints;
    public int requiredHeroPoints;

	// Use this for initialization
	void Start () {
        SceneManager.LoadScene("coinUI", LoadSceneMode.Additive);
        heroPoints = 0;
        requiredHeroPoints = 10000;
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
