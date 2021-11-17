using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

enum HandGrabState { 
    notGrabing,
    tryingToGrab,
    grabing
}

public class BackHandBehaviour : MonoBehaviour {
    public PlayerManager playerManager;
    [SerializeField] HandRiggingController handRiggingController;
    HandGrabState handGrabState = HandGrabState.notGrabing;

    [Header("Points")]
    [SerializeField] GameObject aimPoint;
    [SerializeField] GameObject restingPoint;
    [SerializeField] GameObject radiusLimitCenterPoint;
    [Header("Limits")]
    [SerializeField] float maxGrabDistance;
    [SerializeField] [Range(-1, 1)] float grabPositionOffset = -1;
    float handRadiusLimit;
    [Header("Speed")]
    [SerializeField] float moveSpeed;
    [SerializeField] float speedToRestPoint;
    [SerializeField] float handRotationSpeed;
    [Header("Timer")]
    [SerializeField] float timeToRest;
    Vector3 targetPoint;
    Vector3 moveDirection;
    SoftBodyControl softBodyControl = null;

    private void Start() {
        StartCoroutine("MoveToTheRestPoint", 0);
        handRadiusLimit = handRiggingController.HandLenght;
    }

    void FixedUpdate() {

      switch (handGrabState){
          case HandGrabState.notGrabing:
            //DoSomething
            HandRotation();
            HandMoviment();
            targetPoint = aimPoint.transform.position + (aimPoint.transform.forward * maxGrabDistance);
            break;
          case HandGrabState.tryingToGrab:
            //DoSomething
            break;
          case HandGrabState.grabing:
            //DoSomething
            HandMoviment();
            radiusLimitCenterPoint.transform.position = softBodyControl.AnchorPoint;
            softBodyControl.SetHandlePosition(handRiggingController.Pointer.transform.position + (handRiggingController.Pointer.transform.forward * grabPositionOffset));
            break;
      }
    }

    void LateUpdate() {
        switch (handGrabState){
            case HandGrabState.notGrabing:
                ClampedMoviment();
                break;
            case HandGrabState.tryingToGrab:
                //DoSomething
                break;
            case HandGrabState.grabing:
                ClampedMoviment();
                playerManager.MovimentMamager.ClampPlayerMoviment(handRiggingController.HandLenght + softBodyControl.MaxStretchDistance, softBodyControl.AnchorPoint);
                break;
        }
    }

    void HandMoviment() {
        aimPoint.transform.position = Vector3.Lerp(aimPoint.transform.position, handRiggingController.HandPosition, moveSpeed * Time.fixedDeltaTime);
        moveDirection = transform.up * playerManager.InputManager.rightStick.y + Camera.main.transform.right * playerManager.InputManager.rightStick.x;
        if (moveDirection != Vector3.zero) 
            aimPoint.transform.position += moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;   
    }

    void HandRotation() {
        Vector3 direction = Vector3.ProjectOnPlane(Camera.main.transform.forward, transform.up);
        Quaternion newRotation = Quaternion.LookRotation(direction.normalized, transform.up);
        aimPoint.transform.rotation = Quaternion.Lerp(aimPoint.transform.rotation, newRotation, handRotationSpeed * Time.fixedDeltaTime);
    }

    void ClampedMoviment() {
        Vector3 offset = aimPoint.transform.position - radiusLimitCenterPoint.transform.position;
        aimPoint.transform.position = radiusLimitCenterPoint.transform.position + Vector3.ClampMagnitude(offset, handRadiusLimit);
    }

    IEnumerator MoveToTheRestPoint(float timeToRest) {
        yield return new WaitForSeconds(timeToRest);
        while (aimPoint.transform.position != restingPoint.transform.position && moveDirection == Vector3.zero && handGrabState == HandGrabState.notGrabing){
            aimPoint.transform.position = Vector3.Lerp(aimPoint.transform.position, restingPoint.transform.position, speedToRestPoint * Time.fixedDeltaTime);
            yield return null;
        }
    }

    public void TryGrabSomething(bool state) {
        
        if (state){
            handGrabState = HandGrabState.tryingToGrab;
            StartCoroutine("MoveToTargetPoint");
            handRiggingController.GrabAnimation(true);
            //Do more things
        }
        else {
            if (handGrabState == HandGrabState.grabing){
                ReleaseGrab();
            }
            handGrabState = HandGrabState.notGrabing;
            StartCoroutine("MoveToTheRestPoint", 0);
            handRiggingController.GrabAnimation(false);
            //Do more things
        }
    }

    IEnumerator MoveToTargetPoint(){
        while (aimPoint.transform.position != targetPoint && handGrabState == HandGrabState.tryingToGrab){
            aimPoint.transform.position = Vector3.Lerp(aimPoint.transform.position, targetPoint, moveSpeed * Time.fixedDeltaTime);
            Debug.DrawLine(aimPoint.transform.position, targetPoint, Color.green);
            yield return null;
        }
    }

    public void BackHandMovimentHasStoped() {
       if (handGrabState == HandGrabState.notGrabing){
            StopCoroutine("MoveToTheRestPoint");
            StartCoroutine("MoveToTheRestPoint", timeToRest);
        }
    }

    RaycastHit StretchPoint(Vector3 direction, Vector3 startPosition) {
        RaycastHit hit;
        Physics.Raycast(startPosition, direction, out hit, maxGrabDistance);
        return hit;
    }

    void Grab(Vector3 hitPoint) {
        if (softBodyControl.AddMeshDeformation(hitPoint)){
            handRadiusLimit = softBodyControl.MaxStretchDistance;
            radiusLimitCenterPoint.transform.position = hitPoint;
            softBodyControl.SetGrabbed(true);
            handGrabState = HandGrabState.grabing;
        }
    } 

    void ReleaseGrab() {
        radiusLimitCenterPoint.transform.position = transform.position;
        handRadiusLimit = handRiggingController.HandLenght;
        softBodyControl.SetGrabbed(false);
        softBodyControl = null;
    }

    void OnTriggerEnter(Collider other){
        if (handGrabState == HandGrabState.tryingToGrab && other.gameObject.TryGetComponent(out softBodyControl)){
            //DoSomething
            Vector3 hitPoint = StretchPoint(handRiggingController.Pointer.transform.forward, handRiggingController.Pointer.transform.position).point;
            Grab(hitPoint);
        }
    }

    void OnDrawGizmos(){
        Color color = Color.blue + Color.green;
        color.a = 0.2f;
        Gizmos.color = color;
        if (handGrabState != HandGrabState.tryingToGrab) Gizmos.DrawSphere(radiusLimitCenterPoint.transform.position, handRadiusLimit);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPoint, 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(aimPoint.transform.position, 0.3f);
        color = Color.red;
        color.a = 0.2f;
        Gizmos.color = color;
        if (handGrabState == HandGrabState.grabing) Gizmos.DrawSphere(softBodyControl.AnchorPoint, handRiggingController.HandLenght + softBodyControl.MaxStretchDistance);
    }

}
   