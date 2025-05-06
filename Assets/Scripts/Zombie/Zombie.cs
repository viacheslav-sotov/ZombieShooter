
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    //private Player _player;
    private float _speed;
    private ObjectPool objectPool;
    private IZombieBehavior _zombieBehavior;
    private string _zombieType;
    private int _damage;
    private Transform _player;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        //_player = FindObjectOfType<Player>();
        _player = FindObjectOfType<Player>().transform;
        objectPool = FindObjectOfType<ObjectPool>();
    }

    public void SetBehavior(IZombieBehavior behavior, float speed, int damage)
{
    _zombieBehavior = behavior;
    _speed = speed;
    _damage = damage;

    _zombieType = gameObject.CompareTag("SlowZombie") ? "SlowZombie" : "FastZombie";
}

    void Update()
    {
        if (_player == null)
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        Vector2 direction = (_player.transform.position - transform.position).normalized;
        transform.up = direction;

        _zombieBehavior?.Move(transform, _player.transform, _rigidbody, _speed);
    }

    void OnDisable()
    {
        if (objectPool != null)
        {
            objectPool.ReturnObject(_zombieType, gameObject);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (player != null)
            {
                int damage = gameObject.CompareTag("FastZombie") ? 20 : 10;
                player.TakeDamage(damage);

                gameObject.SetActive(false);
            }
        }
    }

    public void SetPlayerTransform(Transform player)
    {
        _player = player;
    }


}
