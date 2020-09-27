using System.Collections;
using System.Collections.Generic;
using Save;
using TMPro;
using UnityEngine;

public class DiaryEntryContentPage : MonoBehaviour
{
    public TMP_Text entryTitle;
    public TMP_InputField entryContent;
    
    
    public void SaveDiaryEntry()
    {
        SaveSystem.SaveEntry(this);
    }

    public void LoadDiaryEntry()
    {
        DiaryEntryData data = SaveSystem.LoadEntry();

        entryTitle.text = data.entryHeading;
        entryContent.text = data.entryInformation;
    }
}
