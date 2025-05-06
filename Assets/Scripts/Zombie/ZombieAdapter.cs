using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAdapter : IZombieBehavior
{
    private AdaptedZombieBehavior adaptedZombieBehavior = new AdaptedZombieBehavior();
    public void Move(Transform zombie, Transform player, Rigidbody2D rigidbody, float speed)
    {
        adaptedZombieBehavior.Chase(zombie, player, rigidbody, speed);
    }
}
