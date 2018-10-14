using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class jumpButton_intro : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("Entry");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
