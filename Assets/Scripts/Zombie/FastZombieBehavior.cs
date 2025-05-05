using UnityEngine;

public class FastZombieBehavior : IZombieBehavior
{
    public void Move(Transform zombie, Transform player, Rigidbody2D rigidbody, float speed)
    {
        Vector2 direction = (player.position - zombie.position).normalized;
        rigidbody.velocity = direction * speed * 2.0f; // Moves faster
    }
}
