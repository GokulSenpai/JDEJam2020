using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public string userName;
    
    public GameObject chatPanel;
    public GameObject textObject;
    public TMP_InputField chatBox;

    public Color playerMessage, info;

    [SerializeField] private List<Message> messageList = new List<Message>();
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(chatBox.text, Message.MessageType.PlayerMessage);
               // chatBox.text = "";
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                chatBox.ActivateInputField();
            }
        }
    }

    private void SendMessageToChat(string text, Message.MessageType messageType)
    {
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);
        
        messageList.Add(newMessage);
    }

    public void SendMessageButton()
    {
        if (chatBox.text != "")
        {
            SendMessageToChat(chatBox.text, Message.MessageType.PlayerMessage);
            chatBox.text = "";
        }
    }

    private Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.PlayerMessage:
                color = playerMessage;
                break;
        }
        
        
        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;
    
    public enum MessageType
    {
        PlayerMessage,
        Info
    }
}
