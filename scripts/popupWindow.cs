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
using UnityEngine.SceneManagement;

public class popupWindow : MonoBehaviour
{
    public Text question;
    public Button submit;
    public Button cancel;
    public GameObject modalPanelObject;
    public InputField input;

//check if there is a popupWindow
    private static popupWindow modalPanel;


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

    // if the submit or cancel button is clicked
    public void choice(string question)
    {
        Cursor.lockState = CursorLockMode.None;
        modalPanelObject.SetActive(true);

        // set question
        this.question.text = question;

        submit.gameObject.SetActive(true);
        cancel.gameObject.SetActive(true);
    }

    // submit button clicked
    public void submitResult() {
        SceneManager.LoadScene("Roomly");
    }

    //close popup window
    public void closeWindow() {
        modalPanelObject.SetActive(false);
    }

}
