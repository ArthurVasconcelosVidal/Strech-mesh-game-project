using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSoftbodyManipulator : MonoBehaviour{
    [HideInInspector] public GameObject anchor; //Will provide the resting position of the pulling point

    public Renderer renderer; //Provide acess to the material information
    [Range(0, 1)] public float hardness; //Set the hardness of the object
    public float radius; //The radious of the affected area

    public float maxDistanceToTheObject = 10;

    //Set the information from the shader properties
    static readonly int TransformationMatrixId = Shader.PropertyToID("_TransformationMatrix");
    static readonly int AnchorPositionId = Shader.PropertyToID("_AnchorPosition");
    static readonly int HardnessId = Shader.PropertyToID("_Hardness");
    static readonly int RadiusId = Shader.PropertyToID("_Radius");

    void Awake(){
        anchor = new GameObject("AnchorGameObject");
        anchor.transform.SetParent(transform);
        renderer.material = Instantiate(renderer.material);
    }

    public void DeformateBody(Transform handle){
        var transformationMatrix = handle.localToWorldMatrix * anchor.transform.worldToLocalMatrix;

        var softbodyMaterial = renderer.sharedMaterial;

        softbodyMaterial.SetMatrix(TransformationMatrixId, transformationMatrix);
        softbodyMaterial.SetVector(AnchorPositionId, anchor.transform.position);
        softbodyMaterial.SetFloat(HardnessId, hardness);
        softbodyMaterial.SetFloat(RadiusId, radius);
    }
}
