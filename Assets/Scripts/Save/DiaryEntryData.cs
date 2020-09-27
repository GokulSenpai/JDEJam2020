namespace Save
{
    [System.Serializable]
    public class DiaryEntryData
    {
        public string entryHeading;
        public string entryInformation;

        public DiaryEntryData(DiaryEntryContentPage dataSave)
        {
            entryHeading = dataSave.entryTitle.text;
            entryInformation = dataSave.entryContent.text;
        }
    }
}
