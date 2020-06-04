using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedJoystick : Joystick
{
    public static FixedJoystick Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Debug.Log("Instance created");
    }
}