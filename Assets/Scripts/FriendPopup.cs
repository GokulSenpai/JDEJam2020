using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendPopup : MonoBehaviour
{
    //Properties to modify when popping up
    public Text m_headerText;
    public RawImage m_profilePicture;
    public Button m_confirmButton;

    public void SpawnPopup(int friends, Vector3 position, Texture2D image)
    {
        m_profilePicture.texture = image;
    }
}
