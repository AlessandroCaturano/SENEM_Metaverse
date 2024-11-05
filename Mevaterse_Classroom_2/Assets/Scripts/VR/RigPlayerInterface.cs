using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigPlayerInterface : MonoBehaviour
{
    [SerializeField] GameObject keyboard;
    private TextChat textChat;
    private PlayerController controller;
    private PlayerVoiceController voiceController;
    private GameObject movementHandler;

    bool raiseHand = false;
    bool wave = false;
    bool clap = false;
    bool vrChat = false;
    Vector2 movement;

    public void Initialize(GameObject player)
    {
        controller = player.GetComponent<PlayerController>();
        voiceController = player.GetComponent<PlayerVoiceController>();
        textChat = GameObject.Find("TextChat").GetComponent<TextChat>();
    }

    public void ToggleSit()
    {
        if (controller.VRToggleSit())
            movementHandler.SetActive(false);
        else
            movementHandler.SetActive(true);
    }

    public void RaiseHand(bool val)
    {
        raiseHand = val;
    }

    public void Wave(bool val)
    {
        wave = val;
    }

    public void Clap(bool val)
    {
        clap = val;
    }

    public void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }

    public void VoiceChat()
    {
        voiceController.ToggleVRVoiceChat();
    }

    public bool TextChat()
    {
        keyboard.SetActive(textChat.VRToggleTextChat());

    }

    void Update()
    {
        controller.VRRaiseHand(raiseHand);
        controller.VRWave(wave);
        controller.VRClap(clap);
        controller.UpdateVRMovement(movement);
    }
}
