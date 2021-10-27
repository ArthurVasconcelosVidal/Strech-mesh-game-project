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

    public void AddMeshDeformation(Vector3 deformPosition){
        softBodyManipulator = transform.gameObject.AddComponent<CustomSoftbodyManipulator>();
        softBodyManipulator.InitializeMeshDeformation(deformPosition, anchorPrefab, handlePrefab, bodyHardness, deformationSphereRange);
    }

    public bool isDeforming() {
        if (softBodyManipulator) return true;
        else return false;
    }

    public void SetGrabbed(bool state){
        isGrabed = state;
        if (!isGrabed && softBodyManipulator != null){
            softBodyManipulator.TimeToClearHandleForces(timeToClearForces);
        }
    }

    public void SetHandlePosition(Vector3 position) {
        if (isGrabed && softBodyManipulator != null){
            softBodyManipulator.MoveHandle(position);
        }
    }
}
