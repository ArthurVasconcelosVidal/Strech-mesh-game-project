using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovimentState { 
    normalMoviment,
    backHandMoviment
}

public class MovimentMamager : MonoBehaviour{
    public PlayerManager playerManager;

    [Header("Movimentation")]
    [SerializeField] MovimentState movimentState = MovimentState.normalMoviment;
    [SerializeField] float velocity;
    [SerializeField] float rotationSpeed;

    void FixedUpdate(){
        switch (movimentState){
            case MovimentState.normalMoviment:
                NormalMoviment();
                break;
            case MovimentState.backHandMoviment:
                BackHandActiveMoviment();
                break;
        }

    }

    void NormalMoviment() {
        Vector3 direction = RelativeToCamDirection();
        playerManager.rigidbody.MovePosition(transform.position + direction.normalized * velocity * Time.fixedDeltaTime);
        if (direction != Vector3.zero) RotateObject(direction, playerManager.meshObject, rotationSpeed);
    }

    void BackHandActiveMoviment() {
        Vector3 LSDirection = transform.forward * playerManager.inputManager.leftStick.y + transform.right * playerManager.inputManager.leftStick.x;
        playerManager.rigidbody.MovePosition(transform.position + LSDirection.normalized * velocity * Time.fixedDeltaTime);

        float selfRotationSpeed = 1;
        Vector3 RSDirection = transform.right * playerManager.inputManager.rightStick.x;
        if (RSDirection != Vector3.zero)  RotateObject(RSDirection, this.gameObject, selfRotationSpeed);
    }

    public void RotateObject(Vector3 direction, GameObject objectToBeRotated, float rotationSpeed) {
        Quaternion newRotation = Quaternion.LookRotation(direction.normalized, transform.up);
        objectToBeRotated.transform.rotation = Quaternion.Lerp(objectToBeRotated.transform.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime);
    }

    Vector3 RelativeToCamDirection() {
        Vector3 camF = Vector3.ProjectOnPlane(Camera.main.transform.forward, transform.up);
        Vector3 camR = Vector3.ProjectOnPlane(Camera.main.transform.right, transform.up);
        Vector3 finalDirection = camF * playerManager.inputManager.leftStick.y + camR * playerManager.inputManager.leftStick.x;
        return finalDirection;
    }

    public void SwitchMovimentState(MovimentState movimentState) {
        this.movimentState = movimentState;
    }

    public MovimentState GetMovimentState() {
        return movimentState;
    }
         

}
