using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportableSoftBodyMoviment : MonoBehaviour{
    CustomSoftbodyManipulator softbodyManipulator;
    float distance01;
    float maxForce;
    AnimationCurve forceBehaviourCurve;
    Rigidbody rigidbody;
    bool initialize = false;
    public AnimationCurve ForceBehaviourCurve { get { return forceBehaviourCurve; } }
    public float MaxMovimentForce { get { return maxForce; } }

    // Update is called once per frame
    void FixedUpdate(){
        if (initialize){
            if (softbodyManipulator){
                PendulumMoviment();
                Vector3 direction = softbodyManipulator.HandlePoint - transform.position;
                ApplyRotation(direction.normalized, 20);
            }
        }
    }

    void PendulumMoviment() {
        float offset = 0;
        Vector3 targetPosition = softbodyManipulator.HandlePoint + (-Vector3.up * (softbodyManipulator.MaxStretchDistance - offset));
        Vector3 direction = targetPosition - transform.position;
        distance01 = Mathf.InverseLerp(0, softbodyManipulator.MaxStretchDistance, Vector3.Distance(transform.position, targetPosition));
        distance01 = Mathf.Clamp01(distance01);
        Debug.DrawRay(transform.position, direction.normalized * 5, Color.red);
        rigidbody.AddForce(direction.normalized * (maxForce * forceBehaviourCurve.Evaluate(distance01)));
    }

    public void Initialize(AnimationCurve forceBehaviourCurve, float maxForce, CustomSoftbodyManipulator softbodyManipulator) {
        this.forceBehaviourCurve = forceBehaviourCurve;
        this.maxForce = maxForce;
        this.softbodyManipulator = softbodyManipulator;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        initialize = true;
    }

    void ApplyRotation(Vector3 direction, float rotationVelocity){
        Debug.DrawRay(transform.position, direction * 5, Color.blue);
        Vector3 anchorDirection = softbodyManipulator.AnchorPoint - transform.position;
        Debug.DrawRay(transform.position, anchorDirection.normalized * 5, Color.green);
        Quaternion newRotation = Quaternion.FromToRotation(anchorDirection.normalized, direction) * transform.rotation;
        rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, newRotation, rotationVelocity * Time.fixedDeltaTime));
    }

    public void OnRelease() {
        rigidbody.useGravity = true;
        Destroy(this);
    }

    private void OnDrawGizmos(){
        Gizmos.DrawSphere(softbodyManipulator.HandlePoint + (-Vector3.up * (softbodyManipulator.MaxStretchDistance - 0)), 0.2f);
        Gizmos.color = Color.green;
        Gizmos.DrawCube(softbodyManipulator.HandlePoint, Vector3.one/3);
    }

}
