using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRKeyboard : MonoBehaviour
{
    TextChat textChat;
    void Awake()
    {
        textChat = GameObject.Find("TextChat").GetComponent<TextChat>();
    }

    public void Append(char c)
    {
        textChat.Append(c);
    }

    public void Cancel()
    {
        textChat.Cancel();
    }

    public void Send()
    {
        textChat.VRSendTextChat();
    }
}
