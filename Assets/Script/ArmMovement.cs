using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MonoBehaviour
{

    [SerializeField] Camera fpsCamera = default;
    [SerializeField] LayerMask rayCollidesWith = default;
    [SerializeField] float armSmoothMotion = 4f;
    [SerializeField] float shootRange = 4f;

    void Update()
    {
        MoveArm();
    }

    void MoveArm()
    {
        Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, shootRange, rayCollidesWith))
        {
            transform.LookAt(rayOrigin + (fpsCamera.transform.forward * (Vector3.Distance(rayOrigin, hit.point))));
        }
        else
        {
            transform.LookAt(rayOrigin + (fpsCamera.transform.forward * shootRange));
        }
        // transform.rotation = Quaternion.Lerp(transform.rotation, fpsCamera.transform.rotation, Time.deltaTime * armSmoothMotion);
    }
}
