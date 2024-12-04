using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;

public class TextChat : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputField;
    public bool isSelected = false;
    private GameObject commandInfo;

    bool vrChat;

    private void Start()
    {
        commandInfo = GameObject.Find("CommandInfo");
    }

    public void LateUpdate()
    {
        if((Input.GetKeyUp(KeyCode.Return) || vrChat) && !isSelected)
        {
            isSelected = true;
            // Set the selected GameObject to the input field
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);
            inputField.caretPosition = inputField.text.Length;
            commandInfo.SetActive(false);
        }

        else if(Input.GetKeyUp(KeyCode.Escape) && isSelected)
        {
            isSelected = false;
            // Reset the selected GameObject 
            EventSystem.current.SetSelectedGameObject(null);
            commandInfo.SetActive(true);
        }

        else if (Input.GetKeyUp(KeyCode.Return) && isSelected && inputField.text != "")
        {
            photonView.RPC("SendMessageRpc", RpcTarget.AllBuffered, PhotonNetwork.NickName, inputField.text);
            inputField.text = "";
            isSelected = false;
            EventSystem.current.SetSelectedGameObject(null);
            commandInfo.SetActive(true);
        }
    }

    public bool VRToggleTextChat()
    {
        if (!isSelected)
        {
            isSelected = true;
            // Set the selected GameObject to the input field
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);
            inputField.caretPosition = inputField.text.Length;
            commandInfo.SetActive(false);
        } 
        else
        {
            isSelected = false;
            // Reset the selected GameObject 
            EventSystem.current.SetSelectedGameObject(null);
            commandInfo.SetActive(true);
        }
        return isSelected;
    }

    public void VRSendTextChat()
    {
        if (isSelected && inputField.text != "")
        {
            photonView.RPC("SendMessageRpc", RpcTarget.AllBuffered, PhotonNetwork.NickName, inputField.text);
            inputField.text = "";
            isSelected = false;
            EventSystem.current.SetSelectedGameObject(null);
            commandInfo.SetActive(true);
        }
    }

    public void Append(char c)
    {
        inputField.text = inputField.text + c;
    }

    public void Cancel()
    {
        if (inputField.text.Length < 1)
            return;
        inputField.text = inputField.text.Substring(0, inputField.text.Length-1);
    }

    [PunRPC]
    public void SendMessageRpc(string sender, string msg)
    {
        string message = $"<color=\"yellow\">{sender}</color>: {msg}";
        Logger.Instance.LogInfo(message);
        LogManager.Instance.LogInfo($"{sender} wrote in the chat: \"{msg}\"");
    }
}