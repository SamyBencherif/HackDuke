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
using System.Linq;
using System.Runtime.Serialization;

public class checkInput : MonoBehaviour {

    public InputField input;
    public InputField.SubmitEvent se;
    public bool check = false;
    public GlobalVars vars;
    void Start() {
        input = gameObject.GetComponent<InputField>();
        vars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>();
        se = new InputField.SubmitEvent();
        se.AddListener(test);
        input.onEndEdit = se;
    }

        private void test(string arg0)
        {
            var question = vars.wrapper.Data.Questions.Where(x => x.QuestionId == vars.currentQuestion).FirstOrDefault();
            double[] inputs = new double[5];
            inputs[0] = 1.0;
            inputs[1] = 2.0;
            inputs[2] = 5.0;
            inputs[3] = 4.0;
            inputs[4] = 6.0;
            string correctcode = question.Answer;
            codepuzzle thepuzzle = new codepuzzle(inputs, correctcode);
            if(!string.Equals(arg0,""))
            {
                check = thepuzzle.testsoln(arg0);
                Debug.Log(check);
            }
            else
            {
                check = false;
            }
            if (check)
            {
                int index = get1(vars.doors);
                vars.doors[index] = 2;
            }

    }

    public int get1(int[] nums)
    {
        int index = 0;
        foreach (var num in nums)
        {
            if (num == 1)
            {
                return index;
            }

            index++;
        }

        return -1;
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
        string runpuzzle(double n, string usersoln)
        {
            string intro = "def main(n):\n\t";
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
                var res = scope.GetVariable("main")(n);
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
