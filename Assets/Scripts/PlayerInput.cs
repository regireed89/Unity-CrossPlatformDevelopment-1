using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OnXboxStart : UnityEvent { }
[System.Serializable]
public class OnXboxRightStick : UnityEvent { }
[System.Serializable]
public class OnXboxLeftStick : UnityEvent { }
[System.Serializable]
public class OnXboxBack : UnityEvent { }

public class PlayerInput : MonoBehaviour
{
    public float rightstick_H;
    public float rightstick_V;
    
    
    public float leftstick_H;
    public float leftstick_V;
    public bool StartButton;
    public bool RightBumper;
    public bool LeftBumper;
    private void Update()
    {

        StartButton = Input.GetButton("Start");
        rightstick_H = Input.GetAxis("RightHorizontal");
        rightstick_V = Input.GetAxis("RightVertical");
        LeftBumper = Input.GetButton("LeftBumper");
        RightBumper = Input.GetButton("RightBumper");
    }

    

    
    
}
