using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVars : MonoBehaviour
{

	public bool showDoorHint = true;
    public bool initialLoad = true;
    public Vector3 currentPosition;

    public int[] doors;
	// Use this for initialization
	void Start()
	{
        DontDestroyOnLoad(gameObject);
	    doors = new int[]
	    {
	        0, 0, 0, 0, 0, 0, 0
	    };

        SceneManager.LoadScene("Roomly");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
