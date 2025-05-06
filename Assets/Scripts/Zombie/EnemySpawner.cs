using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        Transform spawnLocation = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Randomly choose between SlowZombie and FastZombie
        // string zombieType = Random.value > 0.5f ? "SlowZombie" : "FastZombie";
        string[] zombieTypes = { "SlowZombie", "FastZombie", "AdaptedZombie" };
        string zombieType = zombieTypes[Random.Range(0, zombieTypes.Length)];

        SpawnZombie(zombieType, spawnLocation.position);
    }

    private void SpawnZombie(string type, Vector3 position)
    {
        GameObject enemy = objectPool.GetObject(type);

        if (enemy != null)
        {
            enemy.transform.position = position;
            enemy.SetActive(true);

            Zombie zombieComponent = enemy.GetComponent<Zombie>();

            if (type == "SlowZombie")
                zombieComponent.SetBehavior(new SlowZombieBehavior(), 0.8f, 10);
            else if (type == "FastZombie")
                zombieComponent.SetBehavior(new FastZombieBehavior(), 1.5f, 20);
            else if (type == "AdaptedZombie")
                zombieComponent.SetBehavior(new ZombieAdapter(), 1.2f, 15);
        }
        else
        {
            Debug.LogWarning($"No available objects in pool for: {type}");
        }
    }
}
