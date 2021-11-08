using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentMamager : MonoBehaviour{
    public PlayerManager playerManager;

    [Header("Movimentation")]
    [SerializeField] float velocity;
    [SerializeField] float rotationSpeed;

    void FixedUpdate(){
        Moviment();
    }

    void Moviment() {
        Vector3 direction = RelativeToDirection(playerManager.inputManager.leftStick, Camera.main.transform.forward, Camera.main.transform.right, transform.up);
        playerManager.rigidbody.MovePosition(transform.position + direction.normalized * velocity * Time.fixedDeltaTime);
        if (direction != Vector3.zero) RotateObject(direction, playerManager.meshObject, rotationSpeed);
    }

    public void RotateObject(Vector3 direction, GameObject objectToBeRotated, float rotationSpeed) {
        Quaternion newRotation = Quaternion.LookRotation(direction.normalized, transform.up);
        objectToBeRotated.transform.rotation = Quaternion.Lerp(objectToBeRotated.transform.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    public Vector3 RelativeToDirection(Vector3 stickDirection, Vector3 directionFoward, Vector3 directionRight, Vector3 normalPlaneProjection) {
        Vector3 dirF = Vector3.ProjectOnPlane(directionFoward, normalPlaneProjection);
        Vector3 dirR = Vector3.ProjectOnPlane(directionRight, normalPlaneProjection);
        Vector3 finalDirection = dirF * stickDirection.y + dirR * stickDirection.x;
        return finalDirection;
    }
         
}
