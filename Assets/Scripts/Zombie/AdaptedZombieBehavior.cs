//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptedZombieBehavior : MonoBehaviour
{
    public void Chase(Transform zombie, Transform target, Rigidbody2D rb, float moveSpeed)
    {
        Vector2 dir = (target.position - zombie.position).normalized;
        rb.velocity = dir * moveSpeed;
    }
}
