using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSoftbodyManipulator : MonoBehaviour{
    bool initialized = false;

    GameObject anchorObject; //Will provide the resting position of the pulling point
    GameObject handleObject; //Will provide the new point for the deformation
    
    Renderer renderer; //Provide acess to the material information
    [Range(0, 1)] public float hardness; //Set the hardness of the object
    public float radius; //The radious of the affected area

    public float maxDistanceToTheObject = 10;

    //Set the information from the shader properties
    static readonly int TransformationMatrixId = Shader.PropertyToID("_TransformationMatrix");
    static readonly int AnchorPositionId = Shader.PropertyToID("_AnchorPosition");
    static readonly int HardnessId = Shader.PropertyToID("_Hardness");
    static readonly int RadiusId = Shader.PropertyToID("_Radius");

    void FixedUpdate(){
        if (initialized)
            DeformateBody(handleObject.transform);
    }

    void ClearForces(){
        var handleRb = handleObject.GetComponent<Rigidbody>();
        handleRb.velocity = Vector3.zero;
        handleRb.angularVelocity = Vector3.zero;
    }

    void DeformateBody(Transform handle){
        var transformationMatrix = handle.localToWorldMatrix * anchorObject.transform.worldToLocalMatrix;

        var softbodyMaterial = renderer.sharedMaterial;

        softbodyMaterial.SetMatrix(TransformationMatrixId, transformationMatrix);
        softbodyMaterial.SetVector(AnchorPositionId, anchorObject.transform.position);
        softbodyMaterial.SetFloat(HardnessId, hardness);
        softbodyMaterial.SetFloat(RadiusId, radius);
    }

    public void InitializeMeshDeformation(Vector3 strechPoint, GameObject anchorPrefab, GameObject handlePrefab, float hardness = 0, float radius = 0){
        anchorObject = Instantiate(anchorPrefab, transform);
        handleObject = Instantiate(handlePrefab, transform);
        handleObject.GetComponent<SpringJoint>().connectedBody = anchorObject.GetComponent<Rigidbody>();
        
        renderer = GetComponent<Renderer>();
        renderer.material = Instantiate(renderer.material);

        anchorObject.transform.position = strechPoint;
        handleObject.transform.position = strechPoint;

        this.hardness = Mathf.Clamp01(hardness);
        this.radius = radius;

        initialized = true;
    }

    public void MoveHandle(Vector3 position) {
        handleObject.transform.position = position;
    }

    public void TimeToClearHandleForces(float time) {
        Invoke("ClearForces", time);
        StartCoroutine("DestroyWhenStop", time);
    }

    IEnumerator DestroyWhenStop(float time) {
        yield return new WaitForSeconds(time + 0.1f);
        yield return new WaitUntil(() => handleObject.GetComponent<Rigidbody>().velocity == Vector3.zero);
        BehaviourDestroyer();
    }

    void BehaviourDestroyer() {
        Destroy(handleObject);
        Destroy(anchorObject);
        Destroy(this);
    }
}
