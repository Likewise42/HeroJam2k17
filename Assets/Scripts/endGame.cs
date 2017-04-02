using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    public GameObject gameManager;
    public gmScript gameManagerScript;
    public bool gameOver;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager");
        gameManagerScript = (gmScript)gameManager.GetComponent<gmScript>();
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);

        if (gameManagerScript.heroPoints >= gameManagerScript.requiredHeroPoints)
        {
            SceneManager.LoadScene("victoryScreen");
        }
    }

}
