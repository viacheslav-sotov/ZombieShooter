using UnityEngine;

public class ZombieFactory : MonoBehaviour
{
    public GameObject slowZombiePrefab;
    public GameObject fastZombiePrefab;

    public GameObject CreateZombie(string type, Vector3 position)
    {
        GameObject zombieObject;
        IZombieBehavior behavior;
        float baseSpeed = Random.Range(0.9f, 1.1f); // Small variation

        if (type == "SlowZombie")
        {
            zombieObject = Instantiate(slowZombiePrefab, position, Quaternion.identity);
            behavior = new SlowZombieBehavior();
        }
        else if (type == "FastZombie")
        {
            zombieObject = Instantiate(fastZombiePrefab, position, Quaternion.identity);
            behavior = new FastZombieBehavior();
        }
        else
        {
            throw new System.ArgumentException("Invalid zombie type");
        }

        Zombie zombie = zombieObject.GetComponent<Zombie>();
        zombie.SetBehavior(behavior, baseSpeed, type == "SlowZombie" ? 10 : 20);

        return zombieObject;
    }
}
