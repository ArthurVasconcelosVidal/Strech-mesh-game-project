using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentMamager : MonoBehaviour{
    public PlayerManager playerManager;

    [Header("Movimentation")]
    [SerializeField] float velocity;
    [SerializeField] float rotationSpeed;

    void FixedUpdate(){
        Vector3 direction = RelativeToCamDirection();
        playerManager.rigidbody.MovePosition(transform.position + direction.normalized * velocity * Time.fixedDeltaTime);
        if(direction != Vector3.zero) RotateMeshObject(direction);
    }

    void RotateMeshObject(Vector3 direction) {
        Quaternion newRotation = Quaternion.LookRotation(direction.normalized, transform.up);
        playerManager.meshObject.transform.rotation = Quaternion.Lerp(playerManager.meshObject.transform.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    Vector3 RelativeToCamDirection() {
        Vector3 camF = Vector3.ProjectOnPlane(Camera.main.transform.forward, transform.up);
        Vector3 camR = Vector3.ProjectOnPlane(Camera.main.transform.right, transform.up);
        Vector3 finalDirection = camF * playerManager.inputManager.rightStick.y + camR * playerManager.inputManager.rightStick.x;
        return finalDirection;
    }

}
