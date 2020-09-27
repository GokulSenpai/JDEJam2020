using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordProtection : MonoBehaviour
{
    public TMP_InputField inputPassword;
    public TMP_Text wiredTitle;

    public GameObject wrongPasswordUi;
    
    private const string Password = "Password";
    public void PasswordChecker()
    {
        if (PlayerPrefs.GetString(Password) == inputPassword.text)
        {
            Debug.Log("Correct Password");
            // Go to next menu
        }
        else
        {
            Debug.Log("Wrong Password");
            //wiredTitle.text = "Wrong";
            wrongPasswordUi.SetActive(true);
            
            StartCoroutine(DisableWrongUi());
        }
    }

    private IEnumerator DisableWrongUi()
    {
        yield return new WaitForSeconds(3);
        wrongPasswordUi.SetActive(false);
    }
}
