using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalVars : MonoBehaviour
{

	public bool showDoorHint = true;
    public bool initialLoad = true;
    public Vector3 currentPosition;

	// Use this for initialization
	void Start()
	{
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Roomly");
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
