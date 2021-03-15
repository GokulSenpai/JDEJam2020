using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PasswordManager : MonoBehaviour
{
    public TMP_InputField setPassword;
    private const string Password = "Password";
    
    public TMP_InputField enteredPassword;

    private PageFlowManager m_pageFlowManager;

    private void Awake()
    {
        m_pageFlowManager = FindObjectOfType<PageFlowManager>();
    }

    public void OnSetPasswordButtonClick()
    {
        PlayerPrefs.SetString(Password, setPassword.text);
        setPassword.text = "";
        Debug.Log("Password Set Successfully and the password is " + PlayerPrefs.GetString(Password));
       
        m_pageFlowManager.PasswordSet();
    }
    
    public void PasswordChecker()
    {
        if (PlayerPrefs.GetString(Password) == enteredPassword.text)
        {
            m_pageFlowManager.CorrectPassword();
        }
        else
        {
            m_pageFlowManager.WrongPassword();
        }
    }
}
