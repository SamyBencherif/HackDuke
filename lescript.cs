﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using UnityEngine;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public class lescript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        double[] inputs = new double[5];
        inputs[0] = 1.0;
        inputs[1] = 2.0;
        inputs[2] = 5.0;
        inputs[3] = 4.0;
        inputs[4] = 6.0;
        string correctcode = "return input";
        codepuzzle thepuzzle = new codepuzzle(inputs,correctcode);
        Debug.Log(thepuzzle.testsoln("return input"));
        Debug.Log(thepuzzle.testsoln("return 1.0"));
        string fibcode = "def recurse(usrinput):\n\tif(usrinput < 2):\n\t\treturn 1\n\telse:\n\t\treturn recurse(usrinput-1) + recurse(usrinput-2)\nreturn recurse(input)";
        codepuzzle fibpuzzle = new codepuzzle(inputs,fibcode);
        Debug.Log(fibpuzzle.testsoln(fibcode));
        Debug.Log(fibpuzzle.testsoln(correctcode));
	}
        // Update is called once per frame
	void Update () {
		
	}
}
public class codepuzzle{
        public double[] possibleinputs;
        public string CorrectCode;
        public codepuzzle(double[] inputs, string correctcode)
        {
                possibleinputs = inputs;
                CorrectCode = correctcode;
        }
        public bool testsoln(string solncode)
        {
                for(int i = 0; i < possibleinputs.Length; i++)
                {
                        string userresult = runpuzzle(possibleinputs[i],solncode);
                        string correctresult = runpuzzle(possibleinputs[i],CorrectCode);
                        if(!string.Equals(userresult,correctresult))
                        {
                                return false;
                        }
                }
                return true;
        }
        string runpuzzle(double input,string usersoln)
        {
                string intro = "def main(input):\n\t";
                string cleanedinput = usersoln.Replace("\n","\n\t");
                string pySrc = intro + cleanedinput;

                // host python and execute script
                var engine = Python.CreateEngine ();
                var scope = engine.CreateScope ();
                engine.Execute (pySrc, scope);

                // get function and dynamically invoke
                string stringres;
                try
                {
                        var res = scope.GetVariable ("main") (input);
                        if(res is string)
                        {
                                stringres = res;
                        }
                        else
                        {
                                stringres = res.ToString();
                        }
                }
                catch (Exception e)
                {
                        Debug.Log(e.ToString());
                        Debug.Log("SYNTAX ERROR!");
                        return "";
                }
                return stringres;
        }
}
