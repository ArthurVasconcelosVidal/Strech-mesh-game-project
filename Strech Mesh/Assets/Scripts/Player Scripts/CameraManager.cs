using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour{

    #region Cinemachine Camera
    [SerializeField] CinemachineFreeLook normalLookCM;
    [SerializeField] CinemachineVirtualCamera backHandLookCM;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default
    #endregion

    void FixedUpdate(){
        switch (playerManager.movimentMamager.GetMovimentState()){
            case MovimentState.normalMoviment:
                NormalCameraMoviment();
                break;
            case MovimentState.backHandMoviment:
                BackHandCameraMoviment();
                break;
        }
    }

    void NormalCameraMoviment(){
        normalLookCM.m_XAxis.Value += playerManager.inputManager.rightStick.x * camSpeedX * Time.fixedDeltaTime;
        normalLookCM.m_YAxis.Value += playerManager.inputManager.rightStick.y * camSpeedY * Time.fixedDeltaTime;
    }

    void BackHandCameraMoviment() {
        float cameraRotationSpeed = 2;
        Vector3 direction = playerManager.meshObject.transform.up * playerManager.inputManager.rightStick.y;
        Vector3 rotateDirection = Vector3.Lerp(playerManager.meshObject.transform.forward, direction, 0.5f);
        Quaternion finalRotation = Quaternion.LookRotation(rotateDirection, backHandLookCM.transform.up);
        if (direction != Vector3.zero) backHandLookCM.transform.rotation = Quaternion.Lerp(backHandLookCM.transform.rotation, finalRotation, cameraRotationSpeed * Time.fixedDeltaTime);
    }
}

