using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
    PlayerControl playerControl;
    public Vector2 rightStick;
    public Vector2 leftStick;

    void Awake(){
        playerControl = new PlayerControl();

        playerControl.Control.LeftStick.performed += ctx => {
            leftStick = ctx.ReadValue<Vector2>();
        };

        playerControl.Control.LeftStick.canceled += ctx =>{
            leftStick = Vector2.zero;
        };

        playerControl.Control.RightStick.performed += ctx => {
            rightStick = ctx.ReadValue<Vector2>();
        };

        playerControl.Control.RightStick.canceled += ctx => {
            rightStick = Vector2.zero;
        };
    }

    void OnEnable(){
        playerControl.Control.Enable();
    }

    void OnDisable(){
        playerControl.Control.Disable();
    }
}
