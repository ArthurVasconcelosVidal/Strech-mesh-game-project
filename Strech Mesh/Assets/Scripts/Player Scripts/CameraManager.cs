using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour{

    #region Cinemachine Camera
    [SerializeField] CinemachineFreeLook normalLookCM;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] float camSpeedY = 1; //Default
    [SerializeField] float camSpeedX = 80; //Default
    #endregion

    void FixedUpdate(){

    }

    void NormalCameraMoviment(){
        normalLookCM.m_XAxis.Value += playerManager.InputManager.rightStick.x * camSpeedX * Time.fixedDeltaTime;
        normalLookCM.m_YAxis.Value += playerManager.InputManager.rightStick.y * camSpeedY * Time.fixedDeltaTime;
    }

    public void MoveCam(float value) {
        value = Mathf.Clamp(value, -1, 1);
        StopCoroutine("MoveCamLeftRight");
        StartCoroutine("MoveCamLeftRight", value);
    }

    public void StopMoveCam() {
        StopCoroutine("MoveCamLeftRight");
    }

    IEnumerator MoveCamLeftRight(float value) {
        while (true){
            normalLookCM.m_XAxis.Value += value * camSpeedX * Time.fixedDeltaTime;
            Debug.Log("Ta rodando");
            yield return null;
        }
    }

}

