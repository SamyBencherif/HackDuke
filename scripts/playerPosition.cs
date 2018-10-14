using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerPosition : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    var vars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>();
	    if (!vars.initialLoad)
	    {
	        transform.position = vars.currentPosition;
        }

	    vars.initialLoad = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
