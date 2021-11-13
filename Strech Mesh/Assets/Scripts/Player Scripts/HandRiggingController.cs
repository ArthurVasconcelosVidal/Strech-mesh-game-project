using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class HandRiggingController : MonoBehaviour {
    [SerializeField] GameObject pointer;
    [SerializeField] GameObject thumbAim, midAim, tinyAim;
    [SerializeField] float currentValue;
    [SerializeField] [Range(0, 1)] float minValue;
    [SerializeField] [Range(0, 1)] float maxValue;
    [SerializeField] [Range(0.1f,5)]float  animVelocity;
    [SerializeField] AnimationCurve grabAnimation;
    public GameObject Pointer { get { return pointer; } }

    public void GrabAnimation(bool state) {
        StopCoroutine("GrabbingAnimation");
        StartCoroutine("GrabbingAnimation", state);
    }

    IEnumerator GrabbingAnimation(bool state) {
        //if (state) currentValue = minValue;
        //else currentValue = maxValue;

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
}
