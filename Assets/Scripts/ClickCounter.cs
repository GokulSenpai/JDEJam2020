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
        [SerializeField] private Text counterText;

        private ulong mouseClickCount = 0;

        private bool iHeldMouseButton = false;

        private float holdDelay = 500f;
        private float holdTimer = 0f;

        //Remove All Pointer functions adn the Update for not having a onHoldTimeSpeed Increase

        public void IncrementCounter()
        {
            mouseClickCount++;
            counterText.text = mouseClickCount.ToString();
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
            holdDelay = 500f;
        }

        private void Update()
        {
            holdTimer += Time.smoothDeltaTime;

            if (iHeldMouseButton && holdTimer > holdDelay)
            {
                IncrementCounter();
            }
        }
    }
}
