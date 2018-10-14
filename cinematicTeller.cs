using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cinematicTeller : MonoBehaviour
{

	Text content;
	string msg = "";
	
	int dispLength;
	float timer;

	public GameObject intro;
    public GameObject start;
    public GameObject exit;


	// Use this for initialization
	void Start()
	{
		content = GetComponent<Text> ();

        start.SetActive(false);
        exit.SetActive(false);
        msg = content.text;

		dispLength = 0;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update()
	{
		timer += Time.deltaTime;
		if (timer > .05)
		{
			timer = 0;

			if (dispLength < msg.Length)
				dispLength += 1;
			else
				Invoke ("showButton", 1.3f);
		}

		content.text = msg.Substring (0, dispLength);
	}

	void showButton()
	{
		start.SetActive (true);
        exit.SetActive(true);
    }
}
