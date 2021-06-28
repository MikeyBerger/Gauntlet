using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchMaps : MonoBehaviour
{
    private PlayerInput Controls;
    public bool ControlSwitched;

    // Start is called before the first frame update
    void Start()
    {
        Controls = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //Attempt1();
        Attempt2();
    }

    private void Attempt1()
    {
        if (Controls.playerIndex == 1)
        {
            Controls.actions.FindActionMap("CubeMap2").Enable();
            Controls.SwitchCurrentActionMap("CubeMap2");

        }
    }

    void Attempt2()
    {
        if (!ControlSwitched)
        {
            Controls.actions.FindActionMap("CubeMap").Disable();
            Controls.actions.FindActionMap("CubeMap2").Enable();
        }
    }
}
