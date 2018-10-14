using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using Microsoft.Scripting.Hosting;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;
using IronPython.Hosting;
using System.IO;
using System.Runtime.Serialization;

public class checkInput : MonoBehaviour {
    
        public InputField input;
    public InputField.SubmitEvent se; 

    void Start() {
        input = gameObject.GetComponent<InputField>();
        se = new InputField.SubmitEvent();
        se.AddListener(test);
        input.onEndEdit = se;
    }

        private void test(string arg0)
        {
            double[] inputs = new double[5];
            inputs[0] = 1.0;
            inputs[1] = 2.0;
            inputs[2] = 5.0;
            inputs[3] = 4.0;
            inputs[4] = 6.0;
            string correctcode = "return input";
            codepuzzle thepuzzle = new codepuzzle(inputs, correctcode);
            Debug.Log(thepuzzle.testsoln(arg0));
        }

    }

    public class codepuzzle
    {
        public double[] possibleinputs;
        public string CorrectCode;
        public codepuzzle(double[] inputs, string correctcode)
        {
            possibleinputs = inputs;
            CorrectCode = correctcode;
        }
        public bool testsoln(string solncode)
        {
            for (int i = 0; i < possibleinputs.Length; i++)
            {
                string userresult = runpuzzle(possibleinputs[i], solncode);
                string correctresult = runpuzzle(possibleinputs[i], CorrectCode);
                if (!string.Equals(userresult, correctresult))
                {
                    return false;
                }
            }
            return true;
        }
        string runpuzzle(double input, string usersoln)
        {
            string intro = "def main(input):\n\t";
            string cleanedinput = usersoln.Replace("\n", "\n\t");
            string pySrc = intro + cleanedinput;

            // host python and execute script
            var engine = Python.CreateEngine();
            var scope = engine.CreateScope();
            engine.Execute(pySrc, scope);

            // get function and dynamically invoke
            string stringres;
            try
            {
                var res = scope.GetVariable("main")(input);
                if (res is string)
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
