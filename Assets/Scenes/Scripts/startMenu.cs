﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class startMenu : MonoBehaviour, IPointerClickHandler
{

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("coinUI");
    }
}
