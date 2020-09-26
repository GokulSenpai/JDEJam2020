using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tayx.Graphy.Utils.NumString;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class LetterRandomize : MonoBehaviour
{
    public TMP_Text textToShuffleReference;
    public float timeToInvokeShuffles = 1f;
    public float shuffleStopAfter = 3f;
    public float timeBeforeStartingShuffle = 7f;

    private string m_originalTextBackup;

    private string m_textToShuffle;


    private bool m_timeToShuffle = false;
    
    public void Start()
    {
        m_textToShuffle = textToShuffleReference.text;
        m_originalTextBackup = textToShuffleReference.text;

        StartCoroutine(ItsNotABugItsAFeature());
    }
            
    private void Update()
    {
        if (m_timeToShuffle)
        {
            InvokeRepeating(nameof(EveryDayImShuffling), timeToInvokeShuffles, shuffleStopAfter);
        }
        else
        {
            textToShuffleReference.text = m_originalTextBackup;
        }
    }

    private void EveryDayImShuffling()
    {
        textToShuffleReference.text = RandomStringGenerator(m_textToShuffle);
    }

    private static string RandomStringGenerator(string input)
    {
        Random rand = new Random();
        string outputString = new string(input.OrderBy(x => rand.Next()).ToArray());
        return outputString;
    }

    private IEnumerator ItsNotABugItsAFeature()
    {
        yield return new WaitForSeconds(timeBeforeStartingShuffle);
        m_timeToShuffle = true;
        yield return new WaitForSeconds(0.5f);
        m_timeToShuffle = false;
    }
}
