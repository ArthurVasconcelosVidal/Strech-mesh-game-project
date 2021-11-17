using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SoftBodyControl : MonoBehaviour{

    bool isGrabed;
    CustomSoftbodyManipulator softBodyManipulator;
    [Header("Body Softiness controler")]
    [SerializeField][Range(0,1)] float bodyHardness;
    [SerializeField] float deformationSphereRange;
    [SerializeField] GameObject anchorPrefab;
    [SerializeField] GameObject handlePrefab;
    [SerializeField] float timeToClearForces;
    [SerializeField] float maxStrechDistance;
    Vector3 anchorPoint;

    public Vector3 AnchorPoint { 
        get {
            if (softBodyManipulator) return anchorPoint;
            else return Vector3.zero;
        } 
    }

    public float MaxStretchDistance { get { return maxStrechDistance; } }

    public bool AddMeshDeformation(Vector3 deformPosition){
        if (!softBodyManipulator){
            softBodyManipulator = transform.gameObject.AddComponent<CustomSoftbodyManipulator>();
            anchorPoint = deformPosition;
            softBodyManipulator.InitializeMeshDeformation(deformPosition, anchorPrefab, handlePrefab, bodyHardness, deformationSphereRange, maxStrechDistance);
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
        }
    }

    public void SetHandlePosition(Vector3 position) {
        if (isGrabed && softBodyManipulator != null){
            softBodyManipulator.MoveHandle(position);
        }
    }
}
