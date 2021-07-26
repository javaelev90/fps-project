using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    public Transform playerBody;
    public float sensitvity = 2f;

    float xRotation = 0f;

    Vector2 inputRotation = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
         
        float xValue = inputRotation.x * sensitvity * Time.deltaTime;
        float yValue = inputRotation.y * sensitvity * Time.deltaTime;
        xRotation -= yValue;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * xValue);
    }

    public void OnLook(InputAction.CallbackContext value)
    {
        inputRotation = value.ReadValue<Vector2>();
    }
}
