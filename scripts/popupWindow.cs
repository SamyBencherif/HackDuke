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
using Assets.HackDuke.scripts;
using UnityEngine.SceneManagement;


public class popupWindow : MonoBehaviour
{
    private GlobalVars vars;
    private List<Question> questions;
    private QuestionData data;
    public GameObject question;
    public Button submit;
    public Button cancel;
    public GameObject modalPanelObject;
    public InputField input;

//check if there is a popupWindow
    private static popupWindow modalPanel;

    void Start()
    {
        vars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>();
        int id;
        id = vars.currentQuestion;

        var danielsABitch = vars.wrapper.Data.Questions.Where(x => x.QuestionId == id).FirstOrDefault();
        Cursor.lockState = CursorLockMode.None;
        //modalPanelObject.SetActive(true);

        question.GetComponent<Text>().text = danielsABitch.Title;

        submit.gameObject.SetActive(true);
        cancel.gameObject.SetActive(true);
    }

    void Update()
    {

    }
    public static popupWindow Instance () {
        if (!modalPanel) {
            modalPanel = FindObjectOfType(typeof(popupWindow)) as popupWindow;
            if (!modalPanel) {
                Debug.LogError("There has to be one popup window on a GameObject.");
            }
        }
        return modalPanel;
    }

    // load input from the box when clicking submit
    public void loadInput() {
        input = modalPanelObject.GetComponent<InputField>();
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

    // submit button clicked
    public void submitResult()
    {
        int index = get1(vars.doors);
        if (index >= 0)
        {
            vars.doors[index] = 0;
            Debug.Log("set to close..");
        }

        SceneManager.LoadScene("Roomly");
    }

    //close popup window
    public void closeWindow() {
        int index = get1(vars.doors);
        if (index >= 0)
            vars.doors[index] = 0;
        SceneManager.LoadScene("Roomly");
    }


}
