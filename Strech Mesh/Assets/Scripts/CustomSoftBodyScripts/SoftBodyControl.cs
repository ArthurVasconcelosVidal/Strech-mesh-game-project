using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum SoftBodyType {
    transportable,
    notTransportable
};
public class SoftBodyControl : MonoBehaviour{

    bool isGrabed;
    CustomSoftbodyManipulator softBodyManipulator;
    [SerializeField] SoftBodyType softBodyType = SoftBodyType.notTransportable;
    [SerializeField] AnimationCurve forceBehaviour;
    [SerializeField] float maxForce;
    [Header("Body Softiness controler")]
    [SerializeField][Range(0,1)] float bodyHardness;
    [SerializeField] float deformationSphereRange;
    [SerializeField] GameObject anchorPrefab;
    [SerializeField] GameObject handlePrefab;
    [SerializeField] float timeToClearForces;
    [SerializeField] float maxStrechDistance;
    [SerializeField] float stretchResisteceForce;

    public CustomSoftbodyManipulator SoftbodyManipulator { get { return softBodyManipulator; } }

    public float MaxStretchDistance { get { return maxStrechDistance; } }

    void Awake(){
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = Instantiate(renderer.material);
    }

    public bool AddMeshDeformation(Vector3 deformPosition){
        if (!softBodyManipulator){
            softBodyManipulator = transform.gameObject.AddComponent<CustomSoftbodyManipulator>();
            softBodyManipulator.InitializeMeshDeformation(deformPosition, anchorPrefab, handlePrefab, bodyHardness, deformationSphereRange, maxStrechDistance, stretchResisteceForce);
            if (softBodyType == SoftBodyType.transportable){
                var pendulumBehaviour = transform.gameObject.AddComponent<TransportableSoftBodyMoviment>();
                pendulumBehaviour.Initialize(forceBehaviour, maxForce, softBodyManipulator);
            }
            return true;
        }else 
            return false;
    }

    public bool isDeforming() {
        if (softBodyManipulator) return true;
        else return false;
    }

    public void SetGrabbed(bool state){
        isGrabed = state;
        if (!isGrabed && softBodyManipulator != null){
            softBodyManipulator.TimeToClearForcesAndDestroy(timeToClearForces);
            softBodyManipulator.ReleassingBehaviour();
            if (softBodyType == SoftBodyType.transportable){
                transform.GetComponent<TransportableSoftBodyMoviment>().OnRelease();
            }
        }
    }

    public void SetHandlePosition(Vector3 position) {
        if (isGrabed && softBodyManipulator != null){
            softBodyManipulator.MoveHandle(position);
        }
    }
}
