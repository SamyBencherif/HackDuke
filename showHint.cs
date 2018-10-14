using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class showHint : MonoBehaviour
{

	public GameObject hint;
	GlobalVars vars;

	void OnTriggerEnter(Collider collision)
	{
		if (vars.showDoorHint)
		{
			hint.SetActive (true);
			vars.showDoorHint = false;
		}

	    
	}

	void OnTriggerExit(Collider collision)
	{
		hint.SetActive (false);
	}

    void OnTriggerStay(Collider collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            vars.currentPosition = collision.transform.position;
            SceneManager.LoadScene("Daniel");
        }
    }

	// Use this for initialization
	void Start()
	{
		vars = GameObject.Find ("GlobalVars").GetComponent<GlobalVars>();
	}
	
	// Update is called once per frame
	void Update()
	{

    }
}
