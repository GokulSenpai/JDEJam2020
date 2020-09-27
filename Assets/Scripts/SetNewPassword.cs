using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetNewPassword : MonoBehaviour
{
    public TMP_InputField enteredPassword;
    public GameObject passwordSetUi;
    private const string Password = "Password";

    public void OnSetPasswordButtonClick()
    {
        PlayerPrefs.SetString(Password, enteredPassword.text);
        enteredPassword.text = "";
        Debug.Log("Password Set Successfully and the password is " + PlayerPrefs.GetString(Password));
       
        passwordSetUi.SetActive(true);
    }
}
