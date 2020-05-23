using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Jam.Ghoul.Click
{
    public class ClickCounter : MonoBehaviour
    {
        [Space]
        [Header("UI References")]
        [SerializeField] private Text counterText;

        [Space]
        [Header("Audio References")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip audioFile;

        private ulong mouseClickCount = 0;

        private bool iHeldMouseButton = false;

        private float holdDelay = 500f;
        private float holdTimer = 0f;

        // Remove All Pointer functions and audio delay and the Update for not having a onHoldTimeSpeed Increase

        public void IncrementCounter()
        {
            mouseClickCount++;
            counterText.text = mouseClickCount.ToString("n0");
        }

        public void onPointerDown()
        {
            iHeldMouseButton = true;
            holdDelay = 0.17f;
            holdTimer = 0f;
        }

        public void onPointerUp()
        {
            iHeldMouseButton = false;
            holdDelay = 500f;
        }

        public void onPointerClick()
        {
            IncrementCounter();
            PlayAudio();
            holdDelay = 500f;
        }

        private void Update()
        {
            holdTimer += Time.smoothDeltaTime;

            if (iHeldMouseButton && holdTimer > holdDelay)
            {
                IncrementCounter();
                StartCoroutine(DelayAudio());
            }
        }

        private void PlayAudio()
        {
            audioSource.pitch = Random.Range(0.1f, 3f);
            audioSource.panStereo = Random.Range(-1f, 1f);
            audioSource.PlayOneShot(audioFile);
        }

        IEnumerator DelayAudio()
        {
            yield return new WaitForSeconds(0.25f);
            audioSource.volume = 0.21f;
            PlayAudio();
        }
    }
}
