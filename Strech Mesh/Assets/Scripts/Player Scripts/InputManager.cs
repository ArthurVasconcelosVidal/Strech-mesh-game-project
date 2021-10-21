using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
    PlayerControl playerControl;
    public Vector2 rightStick;

    void Awake(){
        playerControl = new PlayerControl();

        playerControl.control.Moviment.performed += ctx => {
            rightStick = ctx.ReadValue<Vector2>();
        };

        playerControl.control.Moviment.canceled += ctx =>{
            rightStick = Vector2.zero;
        };
    }

    void OnEnable(){
        playerControl.control.Enable();
    }

    void OnDisable(){
        playerControl.control.Disable();
    }
}
