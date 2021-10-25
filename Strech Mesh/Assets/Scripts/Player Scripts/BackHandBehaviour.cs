using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHandBehaviour : MonoBehaviour{
    public PlayerManager playerManager;
    public GameObject backHand;
    public GameObject aimPoint;
    public GameObject cameraObject;
    CustomSoftbodyManipulator objectManipulator = null; 
    [SerializeField] float maxDistance;

    void FixedUpdate(){
        if (objectManipulator){
            objectManipulator.DeformateBody(aimPoint.transform);
        }
    }

    private void LateUpdate(){
        if (objectManipulator && Vector3.Distance(aimPoint.transform.position, objectManipulator.anchor.transform.position) > objectManipulator.maxDistanceToTheObject){
            Debug.Log("Atingiu max range");
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

    public void PinchObject(bool grabbing = true) {
        if (grabbing){
            RaycastHit objectHit = StretchPoint();
            if (objectHit.transform.TryGetComponent(out objectManipulator)){
                objectManipulator.anchor.transform.position = objectHit.point;
                aimPoint.transform.position = objectHit.point;
            }
        }
        else
            objectManipulator = null;
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
