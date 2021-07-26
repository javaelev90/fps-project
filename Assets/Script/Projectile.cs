using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speedMultiplier = 10f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speedMultiplier;
    }
}
