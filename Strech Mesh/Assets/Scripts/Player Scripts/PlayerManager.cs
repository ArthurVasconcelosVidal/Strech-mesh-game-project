using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour{

    [SerializeField] Rigidbody rigidbody;
    [SerializeField] InputManager inputManager;
    [SerializeField] MovimentMamager movimentMamager;
    [SerializeField] ActionManager actionManager;
    [SerializeField] CameraManager cameraManager;
    [SerializeField] GameObject meshObject;
    [SerializeField] BackHandBehaviour backHandBehaviour;
    [SerializeField] AnimationManager animationManager;

    public BackHandBehaviour BackHandBehaviour { get{ return backHandBehaviour; } }
    public Rigidbody Rigidbody { get{ return rigidbody; } }
    public InputManager InputManager { get{ return inputManager; } }
    public MovimentMamager MovimentMamager { get{ return movimentMamager; } }
    public ActionManager ActionManager { get{ return actionManager; } }
    public CameraManager CameraManager { get{ return cameraManager; } }
    public GameObject MeshObject { get{ return meshObject; } }
    public AnimationManager AnimationManager { get { return animationManager; } }


}
