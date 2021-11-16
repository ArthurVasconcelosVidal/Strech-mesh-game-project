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
            playerManager.BackHandBehaviour.BackHandMovimentHasStoped();
        };

        playerControl.Control.LBump.started += ctx => {
            
        };

        playerControl.Control.LBump.canceled += ctx => {
        };

        playerControl.Control.RBump.started += ctx => {
            playerManager.BackHandBehaviour.TryGrabSomething(true);
        };

        playerControl.Control.RBump.performed += ctx => {
        };

        playerControl.Control.RBump.canceled += ctx => {
            playerManager.BackHandBehaviour.TryGrabSomething(false);
        };

        playerControl.Control.RShouder.performed += ctx => {
            playerManager.CameraManager.MoveCam(-1);
        };

        playerControl.Control.LShouder.performed += ctx => {
            playerManager.CameraManager.MoveCam(1);
        };

        playerControl.Control.LRShouder.canceled += ctx =>{
            playerManager.CameraManager.StopMoveCam();
        };
    }

    void OnEnable(){
        playerControl.Control.Enable();
    }

    void OnDisable(){
        playerControl.Control.Disable();
    }
}
