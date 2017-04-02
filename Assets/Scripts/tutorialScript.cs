using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialScript : MonoBehaviour {
    public GameObject player;
    public GameObject canvas;
    public int firstX;
    public int secondX;
    public int thirdX;
    public int fourthX;
    public int fifthX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.x >= firstX)
        {
            canvas.transform.FindChild("ad").gameObject.SetActive(true);
            if (player.transform.position.x >= secondX)
            {
                canvas.transform.FindChild("w").gameObject.SetActive(true);
                canvas.transform.FindChild("ad").gameObject.SetActive(false);
                if (player.transform.position.x >= thirdX)
                {
                    canvas.transform.FindChild("space").gameObject.SetActive(true);
                    canvas.transform.FindChild("w").gameObject.SetActive(false);
                    if (player.transform.position.x >= fourthX)
                    {
                        canvas.transform.FindChild("q").gameObject.SetActive(true);
                        canvas.transform.FindChild("space").gameObject.SetActive(false);
                        if (player.transform.position.x >= fifthX)
                        {
                            canvas.transform.FindChild("shift").gameObject.SetActive(true);
                            canvas.transform.FindChild("q").gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
	}
}
