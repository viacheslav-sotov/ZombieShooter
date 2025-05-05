//// by Viacheslav Sotov
using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public float lifetime = 4f;
    private Coroutine returnCoroutine;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 direction)
    {
        
        if (returnCoroutine != null)
            StopCoroutine(returnCoroutine);

        
        rb.velocity = direction.normalized * speed;
        returnCoroutine = StartCoroutine(ReturnToPoolAfterTime());
    }

    IEnumerator ReturnToPoolAfterTime()
    {
        yield return new WaitForSeconds(lifetime);
        BulletPool.Instance.ReturnBullet(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var enemy = other.collider.GetComponent<Zombie>();
        if (enemy != null)
        {
            enemy.Die();
        }
        BulletPool.Instance.ReturnBullet(gameObject); 
    }
}


