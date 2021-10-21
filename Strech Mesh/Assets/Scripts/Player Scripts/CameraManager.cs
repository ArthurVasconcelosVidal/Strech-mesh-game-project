using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour{

    #region Cinemachine Camera
    [SerializeField] CinemachineFreeLook freeLookCM;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default
    #endregion

    void FixedUpdate(){
        CameraMoviment();
    }

    void CameraMoviment(){
        freeLookCM.m_XAxis.Value += playerManager.inputManager.rightStick.x * camSpeedX * Time.fixedDeltaTime;
        freeLookCM.m_YAxis.Value += playerManager.inputManager.rightStick.y * camSpeedY * Time.fixedDeltaTime;
    }
}

