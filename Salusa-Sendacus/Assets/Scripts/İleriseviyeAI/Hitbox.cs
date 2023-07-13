using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Health health;

    public void OnRaycastHit(ThirdPersonShooterController gun, Vector3 direction)
    {
        health.TakeDamage(gun.Hasar, direction);
    }
}
