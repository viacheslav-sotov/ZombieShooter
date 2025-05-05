using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IZombieBehavior
{
    void Move(Transform zombie, Transform player, Rigidbody2D rigidbody, float speed);
}


