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
            playerManager.backHandBehaviour.BackHandMovimentHasStoped();
        };

        playerControl.Control.LBump.started += ctx => {
            
        };

        playerControl.Control.LBump.canceled += ctx => {
            //playerManager.backHandBehaviour.ActiveHand(false);
        };

        playerControl.Control.RBump.started += ctx => {
            Debug.Log("comeco");  
            //playerManager.backHandBehaviour.PinchObject(true);
        };

        playerControl.Control.RBump.performed += ctx => {
            Debug.Log(ctx.ReadValue<float>());
        };

        playerControl.Control.RBump.canceled += ctx => {
            Debug.Log("termino");
        };

        playerControl.Control.RShouder.performed += ctx => {
            playerManager.cameraManager.MoveCam(-1);
            //Debug.Log("ta la");
        };

        playerControl.Control.LShouder.performed += ctx => {
            playerManager.cameraManager.MoveCam(1);
            //Debug.Log("n ta la");
        };

        playerControl.Control.LRShouder.canceled += ctx =>{
            playerManager.cameraManager.StopMoveCam();
            //Debug.Log("canceled");
        };
    }

    void OnEnable(){
        playerControl.Control.Enable();
    }

    void OnDisable(){
        playerControl.Control.Disable();
    }
}
