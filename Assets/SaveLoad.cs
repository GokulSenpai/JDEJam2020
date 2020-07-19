using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update

    public string theText;
    public TMP_Text note;
    public TMP_InputField placeHolder;

    private void Start()
    {
        theText = PlayerPrefs.GetString("NoteContents");
        placeHolder.text = theText;
    }

    public void SaveNote()
    {
        theText = note.text;
        PlayerPrefs.SetString("NoteContents", theText);
    }
}
