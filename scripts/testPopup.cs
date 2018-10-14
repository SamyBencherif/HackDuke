using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class testPopup : MonoBehaviour {
    
    private popupWindow popup;
    private UnityAction cancelAction;
    private UnityAction checkAction;


    void Awake()
    {
        popup = popupWindow.Instance();
        checkAction = new UnityAction(myCheck);
        cancelAction = new UnityAction(myCancel);
    }

    public void testThis() {
        Debug.Log("Clicked");
        popup.choice("Sample Questio");
        }

    void myCheck() {
        Debug.Log("Cheeeeeeeecccckkk");
    }
    void myCancel()
    {
        Debug.Log("xxxxxxxxxxxxxxxxx");
    }
    }
