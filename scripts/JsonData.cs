using System.Collections;
using System.Collections.Generic;
using Assets.HackDuke.scripts;
using UnityEngine;

public class JsonData : MonoBehaviour
{
    public JsonWrapper wrapper = new JsonWrapper();

    private int index = 0;
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
	    {
	        wrapper.GetQuestion(index);
	        index++;
	    }
	}

    
}
