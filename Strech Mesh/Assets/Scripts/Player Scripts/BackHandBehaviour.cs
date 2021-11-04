using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackHandBehaviour : MonoBehaviour{
    public PlayerManager playerManager;
    [SerializeField] GameObject backHandObject; //Provisorio
    [SerializeField] GameObject aimPoint;
    [SerializeField] GameObject restingPoint;
    [SerializeField] Vector3 handMovimentLimits;
    [SerializeField] float maxDistance;
    [SerializeField] float moveSpeed;
    [SerializeField] float speedToRestPoint;
    [SerializeField] float handRotationSpeed;
    SoftBodyControl softBodyControl = null;

    void FixedUpdate(){
        HandMoviment();
        HandRotation();
        if (softBodyControl){
            softBodyControl.SetHandlePosition(aimPoint.transform.position);
        }
    }

    void LateUpdate(){
        ClampedMoviment();
    }

    void HandMoviment() {
        Vector3 direction = transform.up * playerManager.inputManager.rightStick.y + Camera.main.transform.right * playerManager.inputManager.rightStick.x;
        if (direction != Vector3.zero)
            aimPoint.transform.position += direction.normalized * moveSpeed * Time.fixedDeltaTime;
        else
            aimPoint.transform.position = Vector3.Lerp(aimPoint.transform.position, restingPoint.transform.position, speedToRestPoint * Time.fixedDeltaTime);
    }

    void HandRotation() {
        Vector3 direction = Vector3.ProjectOnPlane(Camera.main.transform.forward, transform.up);
        Quaternion newRotation = Quaternion.LookRotation(direction.normalized, transform.up);
        aimPoint.transform.rotation = Quaternion.Lerp(aimPoint.transform.rotation, newRotation, handRotationSpeed * Time.fixedDeltaTime);
    }

    void ClampedMoviment() {
        Vector3 objectPosition = aimPoint.transform.localPosition;
        objectPosition.x = Mathf.Clamp(objectPosition.x, -handMovimentLimits.x, handMovimentLimits.x);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -handMovimentLimits.y, handMovimentLimits.y);
        objectPosition.z = Mathf.Clamp(objectPosition.z, -handMovimentLimits.z, handMovimentLimits.z);
        aimPoint.transform.localPosition = objectPosition;
    }

    public void ActiveHand(bool handState = true) {
        if (handState) StartCoroutine("HandPinchBehaviour");
    }

    IEnumerator HandPinchBehaviour() {
        yield return null;
    }
    /*
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
    */
    RaycastHit StretchPoint(Vector3 direction, Vector3 startPosition) {
        RaycastHit hit;
        Physics.Raycast(startPosition, direction, out hit, maxDistance);
        return hit;
    }

    void OnDrawGizmos(){
        Color color = Color.blue;
        color.a = 0.2f;
        Gizmos.color = color;
        Gizmos.DrawCube(backHandObject.transform.position, handMovimentLimits*2);

    }

}
   