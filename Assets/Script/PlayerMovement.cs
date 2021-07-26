using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float movementSmoothingSpeed = 10f;
    Vector3 movementDirection;
    Vector3 smoothMovement;

    private void Start() {
        InputSystem.onDeviceChange +=
        (device, change) =>
        {
            switch (change)
            {
                case InputDeviceChange.Added:
                    Debug.Log("New device added: " + device);
                    break;

                case InputDeviceChange.Removed:
                    Debug.Log("Device removed: " + device);
                    break;
            }
        };

    }

    void Update()
    {
        Vector3 movement = transform.right * movementDirection.x + transform.forward * movementDirection.z;
        controller.Move(movement * Time.deltaTime * movementSmoothingSpeed); 
    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        movementDirection = new Vector3(inputMovement.x, 0f, inputMovement.y);
    }
}
