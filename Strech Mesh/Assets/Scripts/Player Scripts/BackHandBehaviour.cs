using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BackHandBehaviour : MonoBehaviour {
    public PlayerManager playerManager;
    [SerializeField] HandRiggingController handRiggingController;

    [Header("Points")]
    [SerializeField] GameObject aimPoint;
    [SerializeField] GameObject restingPoint;
    [SerializeField] GameObject grabPoint;
    [Header("Limits")]
    [SerializeField] float handRadiusLimit;
    [SerializeField] float maxGrabDistance;
    [Header("Speed")]
    [SerializeField] float moveSpeed;
    [SerializeField] float speedToRestPoint;
    [SerializeField] float handRotationSpeed;
    [Header("Timer")]
    [SerializeField] float timeToRest;
    Vector3 targetPoint;
    Vector3 moveDirection;
    bool isGrabing;//Debug
    SoftBodyControl softBodyControl = null;

    private void Start() {
        StartCoroutine("MoveToTheRestPoint", 0);
    }

    void FixedUpdate() {

        if (!isGrabing) {
            HandRotation();
            HandMoviment();
            targetPoint = aimPoint.transform.position + (aimPoint.transform.forward * maxGrabDistance);
        }
        else{
            grabPoint.transform.position = handRiggingController.Pointer.transform.position;
        }

        if (softBodyControl) {
            softBodyControl.SetHandlePosition(aimPoint.transform.position);
        }
    }

    void LateUpdate() {
        if (!isGrabing) {
            ClampedMoviment();
        }
    }

    void HandMoviment() {
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
        Vector3 centerPosition = transform.position;
        Vector3 offset = aimPoint.transform.position - centerPosition;
        aimPoint.transform.position = centerPosition + Vector3.ClampMagnitude(offset, handRadiusLimit);
    }

    IEnumerator MoveToTheRestPoint(float timeToRest) {
        yield return new WaitForSeconds(timeToRest);
        while (aimPoint.transform.position != restingPoint.transform.position && moveDirection == Vector3.zero && !isGrabing) {
            aimPoint.transform.position = Vector3.Lerp(aimPoint.transform.position, restingPoint.transform.position, speedToRestPoint * Time.fixedDeltaTime);
            yield return null;
        }
    }

    public void TryGrabSomething(bool state) {
        isGrabing = state;
        if (state){
            StartCoroutine("MoveToTargetPoint");
            handRiggingController.GrabAnimation(true);
            //Do more things
        }
        else {
            StartCoroutine("MoveToTheRestPoint", 0);
            handRiggingController.GrabAnimation(false);
            //Do more things
        }
    }

    IEnumerator MoveToTargetPoint(){
        Debug.Log("starto");
        while (aimPoint.transform.position != targetPoint && isGrabing){
            aimPoint.transform.position = Vector3.Lerp(aimPoint.transform.position, targetPoint, moveSpeed * Time.fixedDeltaTime);
            Debug.DrawLine(aimPoint.transform.position, targetPoint, Color.green);
            yield return null;
        }
        Debug.Log("fecho");
    }

    public void BackHandMovimentHasStoped() {
        if (!isGrabing){
            StopCoroutine("MoveToTheRestPoint");
            StartCoroutine("MoveToTheRestPoint", timeToRest);
        }
    }

    //Not Used
    RaycastHit StretchPoint(Vector3 direction, Vector3 startPosition) {
        RaycastHit hit;
        Physics.Raycast(startPosition, direction, out hit, maxGrabDistance);
        return hit;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("entro meu baum");
    }
    private void OnTriggerExit(Collider other){
        Debug.Log("Saiu meu bom");
    }

    void OnDrawGizmos(){
        Color color = Color.blue + Color.green;
        color.a = 0.2f;
        Gizmos.color = color;
        if(!isGrabing) Gizmos.DrawSphere(transform.position, handRadiusLimit);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(targetPoint, 0.5f);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(aimPoint.transform.position, 0.3f);
    }

}
   