using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHandBehaviour : MonoBehaviour{
    public PlayerManager playerManager;
    public GameObject backHand;
    public GameObject aimPoint;
    public GameObject cameraObject;
    SoftBodyControl softBodyControl = null; 
    [SerializeField] float maxDistance;

    void FixedUpdate(){
        if (softBodyControl){
            softBodyControl.SetHandlePosition(aimPoint.transform.position);
        }
    }

    public void ActiveHand(bool handState = true) {
        backHand.SetActive(handState);
        if (handState){
            playerManager.movimentMamager.SwitchMovimentState(MovimentState.backHandMoviment);
            cameraObject.transform.localRotation = Quaternion.identity;
        }
        else
            playerManager.movimentMamager.SwitchMovimentState(MovimentState.normalMoviment);
    }

    public void PinchObject(bool grabbing = true){
        if (grabbing){
            RaycastHit objectHit = StretchPoint();
            if (objectHit.transform && objectHit.transform.TryGetComponent(out softBodyControl)){
                if (softBodyControl.AddMeshDeformation(objectHit.point)){
                    softBodyControl.SetGrabbed(true);
                    aimPoint.transform.position = objectHit.point;
                }
                else softBodyControl = null;
            }
        }
        else if (softBodyControl) {
            softBodyControl.SetGrabbed(false);
            softBodyControl = null;
        }
            
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
