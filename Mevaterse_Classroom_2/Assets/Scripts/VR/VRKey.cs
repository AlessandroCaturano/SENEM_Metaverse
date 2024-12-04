using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRKey : MonoBehaviour
{
    VRKeyboard keyboard;

    [SerializeField] char keyChar;

    void Awake()
    {
        keyboard = transform.parent.parent.GetComponent<VRKeyboard>();
    }

    public void OnPress()
    {
        keyboard.Append(keyChar);
    }

    public void Cancel()
    {
        keyboard.Cancel();
    }

    public void Return()
    {
        keyboard.Send();
    }

}
