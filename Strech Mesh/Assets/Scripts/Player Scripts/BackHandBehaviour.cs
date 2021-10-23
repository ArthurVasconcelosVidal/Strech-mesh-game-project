using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHandBehaviour : MonoBehaviour{
    public PlayerManager playerManager;
    public GameObject backHand;
    public GameObject cameraObject;
    [SerializeField] float maxDistance;

    void FixedUpdate(){
        
    }

    public void ActiveHand(bool handState = true) {
        backHand.SetActive(handState);
        if (handState) {
            playerManager.movimentMamager.SwitchMovimentState(MovimentState.backHandMoviment);
            cameraObject.transform.localRotation = Quaternion.identity;
        } 
        else playerManager.movimentMamager.SwitchMovimentState(MovimentState.normalMoviment);
    }


    RaycastHit StretchPoint() {
        RaycastHit hit;
        Physics.Raycast(cameraObject.transform.position, cameraObject.transform.forward, out hit, maxDistance);
        return hit;
    }


    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(StretchPoint().point, 0.3f);   
    }
}
