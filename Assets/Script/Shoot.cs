using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] Transform firePoint = default;
    [SerializeField] GameObject projectilePrefab = default;
    [SerializeField] float shotCooldown = 0.5f;
    float shotCooldownTimer = 0f;
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
        LaunchProjectile();
    }

    void LaunchProjectile()
    {
       if(shotCooldownTimer >= shotCooldown)
        {
            Destroy(Instantiate(projectilePrefab, transform.position, transform.rotation * projectilePrefab.transform.rotation), 3f);
            shotCooldownTimer = 0f;
        } 
    }
}
