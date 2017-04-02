using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class resumeScript : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SceneManager.GetSceneByName("Pause").isLoaded)
        {
            SceneManager.UnloadSceneAsync("Pause");
            SceneManager.LoadScene("coinUI", LoadSceneMode.Additive);
            Time.timeScale = 1;
        }
        else
        {
            SceneManager.LoadScene("main");
        }
    }
}
