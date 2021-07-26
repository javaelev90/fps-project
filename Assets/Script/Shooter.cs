using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Transform firePoint = default;
    [SerializeField] Camera fpsCamera = default;
    [SerializeField] LayerMask rayCollidesWith = default;
    [SerializeField] float shotCooldown = 0.5f;
    [SerializeField] float weaponRange = 4f;
    LineRenderer laserLine = default;  
    float shotCooldownTimer = 0f;

    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
    }
    void Update()
    {
        ShotTimerCount();
    }

    void ShotTimerCount()
    {
        if(shotCooldownTimer < shotCooldown)
        {
            shotCooldownTimer += Time.deltaTime;
        }
    }

    public void OnFire()
    {
        ShootRayCast();
    }

    void ShootRayCast()
    {
       if(shotCooldownTimer >= shotCooldown)
        {
            Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, weaponRange, rayCollidesWith))
            {
                // TODO: Need to point the arm towards the target for this to look right
                laserLine.SetPosition(0, firePoint.position);
                laserLine.SetPosition(1, hit.point);
                Debug.Log(hit.collider.gameObject.name);
            }

            Debug.DrawRay(rayOrigin, fpsCamera.transform.forward * 1000, Color.red);
            shotCooldownTimer = 0f;
        } 
    }

}
