using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VRKeyboard : MonoBehaviour
{
    [SerializeField] TMP_Text field;
    TextChat textChat;
    void Awake()
    {
        textChat = GameObject.Find("TextChat").GetComponent<TextChat>();
    }

    private void OnEnable()
    {
        field.text = "";
    }

    public void Append(char c)
    {
        textChat.Append(c);
        field.text = field.text + "c";
    }

    public void Cancel()
    {
        textChat.Cancel();
        if (field.text.Length < 1)
            return;
        field.text = field.text.Substring(0, field.text.Length - 1);
    }

    public void Send()
    {
        textChat.VRSendTextChat();
        field.text = "";
    }
}
