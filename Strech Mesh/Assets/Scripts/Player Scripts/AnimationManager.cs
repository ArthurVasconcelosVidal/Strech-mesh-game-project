using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour{
    [SerializeField] Animator animatorController;
    public void SetIdleToRunBlendTree(float value) {
        animatorController.SetFloat("velocity", value);
    }

}
