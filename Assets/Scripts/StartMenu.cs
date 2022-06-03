using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{

    //Variables
    public TMP_InputField userInput;
    public TMP_Text confirmText;
    public GameObject inputScreen;
    public GameObject confirmScreen;
    

    public void Confirmation()
    {
        SubmitName();
        confirmText.text = "Play as " + GameManager.ActualPlayername + " ?";
        inputScreen.SetActive(false);
        confirmScreen.SetActive(true);
    }

    public void ConfirmAbort()
    {
        confirmScreen.SetActive(false);
        inputScreen.SetActive(true);
    }
    public void ConfirmAndStart()
    {  
        SceneManager.LoadScene(1);
    }
    public void SubmitName()
    {
        GameManager.ActualPlayername = userInput.text;       
    }

}
