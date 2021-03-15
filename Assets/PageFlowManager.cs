using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageFlowManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPage;
    [SerializeField] private GameObject setPasswordPage;
    [SerializeField] private GameObject passwordSetPage;
    [SerializeField] private GameObject enterPasswordPage;
    [SerializeField] private GameObject wrongPasswordPage;
    [SerializeField] private GameObject diaryListPage;
    [SerializeField] private GameObject diaryContentPage;
    
    public void MainPageButtonClicked()
    {
        if (PlayerPrefs.HasKey("Password"))
        {
            enterPasswordPage.SetActive(true);
        }
        else
        {
            setPasswordPage.SetActive(true);
        }
        
        mainPage.SetActive(false);
    }

    public void PasswordSet()
    {
        StartCoroutine(TimeoutPasswordSetScreenCoroutine());
        setPasswordPage.SetActive(false);
        diaryListPage.SetActive(true);
    }

    private IEnumerator TimeoutPasswordSetScreenCoroutine()
    {
        passwordSetPage.SetActive(true);
        yield return new WaitForSeconds(3);
        passwordSetPage.SetActive(false);
    }
    
    
    public void CorrectPassword()
    {
        Debug.Log("Correct Password");
        enterPasswordPage.SetActive(false);
        diaryListPage.SetActive(true);
    }

    public void WrongPassword()
    {
        Debug.Log("Wrong Password");
        StartCoroutine(TimeOutWrongPasswordScreenCoroutine());
    }

    private IEnumerator TimeOutWrongPasswordScreenCoroutine()
    {
        wrongPasswordPage.SetActive(true);
        yield return new WaitForSeconds(3);
        wrongPasswordPage.SetActive(false);
    }

    public void DiaryListClick()
    {
        diaryContentPage.SetActive(true);
    }
}
