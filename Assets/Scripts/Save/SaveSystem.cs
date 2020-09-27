using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Save
{
    public static class SaveSystem
    {
        public static void SaveEntry(DiaryEntryContentPage dataSave)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Path.Combine(Application.persistentDataPath, "DearDiary.love");

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                DiaryEntryData data = new DiaryEntryData(dataSave);
            
                formatter.Serialize(stream, data);
                //stream.Close();
            }
        }

        public static DiaryEntryData LoadEntry()
        {
            string path = Path.Combine(Application.persistentDataPath, "DearDiary.love");
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    DiaryEntryData data = formatter.Deserialize(stream) as DiaryEntryData;
                    //stream.Close();
                
                    return data;
                }
            }
            else
            {
                Debug.Log("Save File Not Found in " + path);
                return null;
            }
        }
    }
}
