using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordProtection : MonoBehaviour
{
    public TMP_InputField inputPassword;
    public TMP_Text wiredTitle;
    
    private const string Password = "Password";
    private string m_wiredTitleBackup = "The Wired";
    public void PasswordChecker()
    {
        if (PlayerPrefs.GetString(Password) == inputPassword.text)
        {
            // Go to next menu
        }
        else
        {
            Debug.Log("Wrong Password");
            
            wiredTitle.text = m_wiredTitleBackup;
            gameObject.GetComponent<LetterRandomize>().enabled = false;
            wiredTitle.text = "Wrong";
            StartCoroutine(SetWiredTitleBack());
        }
    }

    private IEnumerator SetWiredTitleBack()
    {
        gameObject.GetComponent<LetterRandomize>().enabled = true;
        yield return new WaitForSeconds(7);
        wiredTitle.text = m_wiredTitleBackup;
    }
}
