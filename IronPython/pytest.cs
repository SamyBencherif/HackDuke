using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;


using System.IO;
using System.Runtime.Serialization;
using System.Text;


public class pytest : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		string pySrc =
			@"
import math	
def main():
    return math.sin(math.radians(30));";

		// host python and execute script
		var engine = Python.CreateEngine ();
		var scope = engine.CreateScope ();
		engine.Execute (pySrc, scope);

		// get function and dynamically invoke
		var res = scope.GetVariable ("main") ();

		Debug.Log (res);

		Debug.Log ("Did they get the result we wanted?");
		Debug.Log ((float)res == .5f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
