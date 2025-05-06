using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    public GameObject slowZombiePrefab;
    public GameObject fastZombiePrefab;

    // public GameObject CreateZombie(string type, Vector3 position)
    // {
    //     GameObject zombieObject;
    //     IZombieBehavior behavior;
    //     float baseSpeed = Random.Range(0.9f, 1.1f); 

    //     if (type == "SlowZombie")
    //     {
    //         zombieObject = Instantiate(slowZombiePrefab, position, Quaternion.identity);
    //         behavior = new SlowZombieBehavior();
    //     }
    //     else if (type == "FastZombie")
    //     {
    //         zombieObject = Instantiate(fastZombiePrefab, position, Quaternion.identity);
    //         behavior = new FastZombieBehavior();
    //     }
    //     else
    //     {
    //         throw new System.ArgumentException("Invalid zombie type");
    //     }

    //     Zombie zombie = zombieObject.GetComponent<Zombie>();
    //     zombie.SetBehavior(behavior, baseSpeed, type == "SlowZombie" ? 10 : 20);

    //     return zombieObject;
    // }

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
