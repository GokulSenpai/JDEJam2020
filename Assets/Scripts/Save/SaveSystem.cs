using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public string saveDirectoryName;
    public string saveFileFormat;

    private const string FolderCharacter = "/";
    private const string FileCharacter = ".";

    private Fence m_fence;
    
    private string m_folderName;
    private string m_fileFormat;

    private const string SaveSeparator = "\n#-------------------------------------#\n";

    // Check between persistentDataPath and dataPath.

    private void Awake()
    {
        m_fence = GetComponent<Fence>();
    }

    private void Start()
    {
        // Adds / at both start and end of the character
        m_folderName = FolderCharacter + saveDirectoryName + FolderCharacter;
        
        // Adds . at the start of file format
        m_fileFormat = FileCharacter + saveFileFormat;
    }

    public void SaveEntry(int entryNumber, string entryTitle, string entryContent)
    {
        if(!Directory.Exists(Application.dataPath + m_folderName))
        {
            Directory.CreateDirectory(Application.dataPath + m_folderName);
        }

        string[] contents = {entryTitle, entryContent};

        string saveString = string.Join(SaveSeparator, contents);

        string encodedString = m_fence.Encode(saveString);
        
        File.WriteAllText(Application.dataPath + m_folderName + entryNumber + m_fileFormat, encodedString);
    }

    public string[] LoadEntry(int entryNumber)
    {
        string savedContent = File.ReadAllText(Application.dataPath + m_folderName + entryNumber + m_fileFormat);
        
        print(savedContent);

        string decodedString = m_fence.Decode(savedContent);

        string[] contents = decodedString.Split(new []{SaveSeparator}, StringSplitOptions.None);
        
        print(decodedString);

        return contents;
    }
}
