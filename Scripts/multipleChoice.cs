﻿using System.Collections;
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
using Random = System.Random;


public class multipleChoice : MonoBehaviour {

    private GlobalVars vars;
    private List<Question> questions;
    private QuestionData data;
    private string myChoice;
    public string answer;
    public GameObject question;
    public Button submit;
    public Button cancel;
    public Button A;
    public Button B;
    public Button C;
    public Button D;
    public Button E;
    

    void Start()
    {

        vars = GameObject.Find("GlobalVars").GetComponent<GlobalVars>();

        int id;
        id = vars.currentQuestion;

        var danielsABitch = vars.wrapper.Data.Questions.Where(x => x.QuestionId == id).FirstOrDefault();
        answer = danielsABitch.Answer;
        Cursor.lockState = CursorLockMode.None;

        question.GetComponent<Text>().text = danielsABitch.Title;
        A.GetComponentInChildren<Text>().text = danielsABitch.A;
        B.GetComponentInChildren<Text>().text = danielsABitch.B;
        C.GetComponentInChildren<Text>().text = danielsABitch.C;
        D.GetComponentInChildren<Text>().text = danielsABitch.D;
        E.GetComponentInChildren<Text>().text = danielsABitch.E;
        submit.gameObject.SetActive(true);
        cancel.gameObject.SetActive(true);
    }

    void Update()
    {

    }

    public void TurnRed(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.red;
        colors.highlightedColor = new Color32(255, 100, 100, 255);
        button.colors = colors;
    }

    public void TurnWhite(Button button)
    {
        ColorBlock colors = button.colors;
        colors.normalColor = Color.white;
        colors.highlightedColor = new Color32(225, 225, 225, 255);
        button.colors = colors;
    }


    public void choseButtunA() {
        myChoice = "A";

        // change color
        TurnRed(A);
        TurnWhite(B);
        TurnWhite(C);
        TurnWhite(D);
        TurnWhite(E);
    }

    public void choseButtunB()
    {
        myChoice = "B";

        // change color
        TurnRed(B);
        TurnWhite(A);
        TurnWhite(C);
        TurnWhite(D);
        TurnWhite(E);
    }

    public void choseButtunC()
    {
        myChoice = "C";

        // change color
        TurnRed(C);
        TurnWhite(A);
        TurnWhite(B);
        TurnWhite(D);
        TurnWhite(E);
    }

    public void choseButtunD()
    {
        myChoice = "D";

        // change color
        TurnRed(D);
        TurnWhite(A);
        TurnWhite(C);
        TurnWhite(B);
        TurnWhite(E);

    }

    public void chooseButtonE()
    {
        myChoice = "D";

        // change color
        TurnRed(E);
        TurnWhite(A);
        TurnWhite(C);
        TurnWhite(B);
        TurnWhite(D);
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
        if (myChoice == answer)
        {
            if (index >= 0)
            {
                vars.doors[index] = 2;
            }
        }
        else
        {
            vars.doors[index] = 0;
        }
        SceneManager.LoadScene("Roomly");
    }

    //close popup window
    public void closeWindow()
    {
        int index = get1(vars.doors);
        vars.doors[index] = 0;
        SceneManager.LoadScene("Roomly");
    }


}
