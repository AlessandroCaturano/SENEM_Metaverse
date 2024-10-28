using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigPlayerInterface : MonoBehaviour
{
    private PlayerController controller;

    bool raiseHand = false;
    bool wave = false;
    bool clap = false;

    public PlayerController Controller { get => controller; set => controller = value; }

    public void ToggleSit()
    {
        controller.VRToggleSit();
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

    void Update()
    {
        controller.VRRaiseHand(raiseHand);
        controller.VRWave(val);
        controller.VRClap(val);
    }
}
