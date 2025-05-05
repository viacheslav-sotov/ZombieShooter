using UnityEngine;

public class SlowZombieBehavior : IZombieBehavior
{
    public void Move(Transform zombie, Transform player, Rigidbody2D rigidbody, float speed)
    {
        Vector2 direction = (player.position - zombie.position).normalized;
        rigidbody.velocity = direction * speed * 0.5f; // Moves at half speed
    }
}
