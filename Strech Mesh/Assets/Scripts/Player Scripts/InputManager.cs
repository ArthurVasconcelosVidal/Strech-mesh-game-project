using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
    public PlayerManager playerManager;
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

        playerControl.Control.LBump.started += ctx => {
            playerManager.backHandBehaviour.ActiveHand(true);
        };

        playerControl.Control.LBump.canceled += ctx => {
            playerManager.backHandBehaviour.ActiveHand(false);
        };

        playerControl.Control.RBump.started += ctx => {
            playerManager.backHandBehaviour.PinchObject(true);
        };

        playerControl.Control.RBump.canceled += ctx => {
            playerManager.backHandBehaviour.PinchObject(false);
        };
    }

    void OnEnable(){
        playerControl.Control.Enable();
    }

    void OnDisable(){
        playerControl.Control.Disable();
    }
}
