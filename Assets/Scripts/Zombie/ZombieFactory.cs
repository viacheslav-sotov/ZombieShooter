//by Richard and Viacheslav
using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    public GameObject slowZombiePrefab;
    public GameObject fastZombiePrefab;

    public Zombie CreateZombie(string type, Transform player)
    {
        GameObject zombieObject = ObjectPool.Instance.GetObject(type);

        if (zombieObject == null) return null;

        Zombie zombie = zombieObject.GetComponent<Zombie>();

        IZombieBehavior behavior;
        float speed;
        int damage;

        switch (type)
        {
            case "SlowZombie":
                behavior = new SlowZombieBehavior();
                speed = 0.8f;
                damage = 10;
                break;
            case "FastZombie":
                behavior = new FastZombieBehavior();
                speed = 1.5f;
                damage = 20;
                break;
            case "AdaptedZombie": // 🆕 Using adapter
                behavior = new ZombieAdapter(); 
                speed = 1.2f;
                damage = 15;
                break;
            default:
                return null;
        }

        zombie.SetBehavior(behavior, speed, damage);
        zombie.SetPlayerTransform(player);
        zombieObject.SetActive(true);

        return zombie;
    }
}
