using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSoftbodyManipulator : MonoBehaviour{
    bool initialized = false;

    GameObject anchorObject; //Will provide the resting position of the pulling point
    GameObject handleObject; //Will provide the new point for the deformation
    Rigidbody handleRb;

    float stretchResistenceForce = 2;

    Renderer renderer; //Provide acess to the material information
    [Range(0, 1)] public float hardness; //Set the hardness of the object
    public float radius; //The radious of the affected area

    public float maxDistanceToTheObject = 10;

    //Set the information from the shader properties
    static readonly int TransformationMatrixId = Shader.PropertyToID("_TransformationMatrix");
    static readonly int AnchorPositionId = Shader.PropertyToID("_AnchorPosition");
    static readonly int HardnessId = Shader.PropertyToID("_Hardness");
    static readonly int RadiusId = Shader.PropertyToID("_Radius");

    public Vector3 AnchorPoint { 
        get {
            if (anchorObject) return anchorObject.transform.position;
            else return Vector3.zero;
        } 
    }

    public Vector3 HandlePoint { 
        get {
            if (handleObject) return handleObject.transform.position;
            else return Vector3.zero;
        } 
    }

    public float StretchResistenceForce { get { return stretchResistenceForce; } }
    public float DistanceHandleAnchor { get { return Vector3.Distance(anchorObject.transform.position, handleObject.transform.position); } }
    public float MaxStretchDistance { get { return maxDistanceToTheObject; } }

    void FixedUpdate(){
        if (initialized) 
            DeformateBody(handleObject.transform);
    }

    void LateUpdate(){
        if (initialized)
            ClampedMoviment();
    }

    void DeformateBody(Transform handle){
        var transformationMatrix = handle.localToWorldMatrix * anchorObject.transform.worldToLocalMatrix;

        var softbodyMaterial = renderer.sharedMaterial;

        softbodyMaterial.SetMatrix(TransformationMatrixId, transformationMatrix);
        softbodyMaterial.SetVector(AnchorPositionId, anchorObject.transform.position);
        softbodyMaterial.SetFloat(HardnessId, hardness);
        softbodyMaterial.SetFloat(RadiusId, radius);
    }

    public void InitializeMeshDeformation(Vector3 strechPoint, GameObject anchorPrefab, GameObject handlePrefab, float hardness = 0, float radius = 0, float maxDistance = 10, float stretchResistenceForce = 2){
        anchorObject = Instantiate(anchorPrefab, transform);
        handleObject = Instantiate(handlePrefab, transform);
        handleObject.GetComponent<SpringJoint>().connectedBody = anchorObject.GetComponent<Rigidbody>();
        
        renderer = GetComponent<Renderer>();
        handleRb = handleObject.GetComponent<Rigidbody>();

        this.stretchResistenceForce = stretchResistenceForce;

        anchorObject.transform.position = strechPoint;
        handleObject.transform.position = strechPoint;

        this.hardness = Mathf.Clamp01(hardness);
        this.radius = radius;
        maxDistanceToTheObject = maxDistance;

        initialized = true;
    }

    public void MoveHandle(Vector3 position){
        handleObject.transform.position = position;
    }

    void ClampedMoviment(){
        Vector3 offset = handleObject.transform.position - anchorObject.transform.position;
        Vector3 finalPosition = anchorObject.transform.position + Vector3.ClampMagnitude(offset, maxDistanceToTheObject);
        handleObject.transform.position = Vector3.Lerp(handleObject.transform.position, finalPosition, stretchResistenceForce * Time.fixedDeltaTime);
    }

    public void ReleassingBehaviour() {
        var handleSpringJoint = handleObject.GetComponent<SpringJoint>();
        handleSpringJoint.spring = 100;
        handleSpringJoint.damper = 1;
    }

    public void TimeToClearForcesAndDestroy(float time) {
        StartCoroutine("DestroyWhenStop", time);
    }

    IEnumerator DestroyWhenStop(float time) {
        yield return new WaitForSeconds(time);
        float value = 0;
        while (handleRb.position != anchorObject.transform.position){
            value += Time.fixedDeltaTime;
            value = Mathf.Clamp01(value);
            handleRb.rotation = Quaternion.Lerp(handleRb.rotation, anchorObject.transform.rotation, value);
            handleRb.position = Vector3.Lerp(handleRb.position, anchorObject.transform.position, value);
            yield return null;
        }
        BehaviourDestroyer();
    }

    void BehaviourDestroyer() {
        Destroy(handleObject);
        Destroy(anchorObject);
        Destroy(this);
    }
}
