using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class HandRiggingController : MonoBehaviour {
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject handGameObject;
    [SerializeField] GameObject rootGameObject;
    [SerializeField] GameObject thumbAim, midAim, tinyAim;
    [SerializeField] float currentValue;
    [SerializeField] [Range(0, 1)] float minValue;
    [SerializeField] [Range(0, 1)] float maxValue;
    [SerializeField] [Range(0.1f,5)] float animVelocity;
    [SerializeField] [Range(-1, 1)] float grabPositionOffset;
    [SerializeField] string boneTag = "RigBone";
    [SerializeField] AnimationCurve grabAnimation;
    [SerializeField] float handLenght;
    public GameObject Pointer { get { return pointer; } }
    public Vector3 HandPosition { get { return handGameObject.transform.position; } }

    public float HandLenght { get { return handLenght; } }

    void Awake(){
        HandLenghtCount(rootGameObject, handGameObject, 0);
    }

    void Start(){
        currentValue = minValue;
        thumbAim.GetComponent<ChainIKConstraint>().weight = grabAnimation.Evaluate(minValue);
        midAim.GetComponent<ChainIKConstraint>().weight = grabAnimation.Evaluate(minValue);
        tinyAim.GetComponent<ChainIKConstraint>().weight = grabAnimation.Evaluate(minValue);
        thumbAim.GetComponent<MultiAimConstraint>().weight = grabAnimation.Evaluate(minValue);
        midAim.GetComponent<MultiAimConstraint>().weight = grabAnimation.Evaluate(minValue);
        tinyAim.GetComponent<MultiAimConstraint>().weight = grabAnimation.Evaluate(minValue);

    }

    public void GrabAnimation(bool state) {
        StopCoroutine("GrabbingAnimation");
        StartCoroutine("GrabbingAnimation", state);
    }

    IEnumerator GrabbingAnimation(bool state) {
        do {
            thumbAim.GetComponent<ChainIKConstraint>().weight = grabAnimation.Evaluate(currentValue);
            midAim.GetComponent<ChainIKConstraint>().weight = grabAnimation.Evaluate(currentValue);
            tinyAim.GetComponent<ChainIKConstraint>().weight = grabAnimation.Evaluate(currentValue);
            thumbAim.GetComponent<MultiAimConstraint>().weight = grabAnimation.Evaluate(currentValue);
            midAim.GetComponent<MultiAimConstraint>().weight = grabAnimation.Evaluate(currentValue);
            tinyAim.GetComponent<MultiAimConstraint>().weight = grabAnimation.Evaluate(currentValue);

            if (state) currentValue += animVelocity * Time.fixedDeltaTime;
            else currentValue -= animVelocity * Time.fixedDeltaTime;

            currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

            yield return null;
        } while ((state && currentValue != maxValue) || (!state && currentValue != minValue));
    }

    void HandLenghtCount(GameObject actualBone, GameObject endBone, float actualDistance) {
        if (actualBone != endBone){
            foreach (Transform item in actualBone.transform){
                if (item.CompareTag(boneTag)){
                    actualDistance += Vector3.Distance(actualBone.transform.position, item.position);
                    actualBone = item.gameObject;
                }
            }
            HandLenghtCount(actualBone, endBone, actualDistance);
        }
        else{
            handLenght = actualDistance;
        }
    }
}
