using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trial : MonoBehaviour
{
    public int number;
    public string title;
    public string content;

    private SaveSystem m_saveSystemTest;

    private void Awake()
    {
        m_saveSystemTest = FindObjectOfType<SaveSystem>();
    }

    [ContextMenu("Save File")]
    public void Save()
    {
        m_saveSystemTest.SaveEntry(number, title, content);
    }
    
    [ContextMenu("Load File")]
    public void Load()
    {
        var loaded = m_saveSystemTest.LoadEntry(number);

        // loaded[0] = title
        // loaded[1] = content
        
        print(loaded[0]);
        print(loaded[1]);
    }
}
