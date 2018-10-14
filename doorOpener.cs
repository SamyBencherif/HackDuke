using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpener : MonoBehaviour
{

    public bool Open = false;

    public GameObject LDoorClosed;

    public GameObject RDoorClosed;

    public GameObject LDoorOpen;

    public GameObject RDoorOpen;

    public GameObject DoorSolid;

    public int Index;
    // Use this for initialization
    void Start () {
        var vars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>();
        if (vars.doors[Index] == 2)
        {
            Open = true;
        }
        else
        {
            Open = false;
        }
	}
	
	// Update is called once per frame
	void Update () {
	    
            LDoorOpen.SetActive(Open);
	        RDoorOpen.SetActive(Open);
	        LDoorClosed.SetActive(!Open);
            RDoorClosed.SetActive(!Open);
            DoorSolid.SetActive(!Open);


    }
}
