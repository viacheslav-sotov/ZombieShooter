//by Viacheslav Sotov
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 _input;

    private IShootingStrategy shootingStrategy;
    private IPlayerMovement movementStrategy;
    private Commands invoker;

    public float speed;
    public Transform GunPoint;
    public GameObject bulletPrefab;

    
    private int maxHealth = 100;
    private int currentHealth;

    public TMP_Text deathMessage;

    
    private List<IObserver> observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnHealthChanged(currentHealth);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        invoker = new Commands();
        shootingStrategy = new SingleShot();
        movementStrategy = new BasePlayerMovement();

        currentHealth = maxHealth;

        
        HealthBar healthBar = FindObjectOfType<HealthBar>();
        if (healthBar != null)
        {
            AddObserver(healthBar);
        }

        NotifyObservers(); 
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.W)) invoker.ExecuteCommand(new MoveUpCommand(this));
        if (Input.GetKey(KeyCode.S)) invoker.ExecuteCommand(new MoveDownCommand(this));
        if (Input.GetKey(KeyCode.A)) invoker.ExecuteCommand(new MoveLeftCommand(this));
        if (Input.GetKey(KeyCode.D)) invoker.ExecuteCommand(new MoveRightCommand(this));

        
        transform.up = (MouseUtils.GetMousePosition2d() - (Vector2)transform.position).normalized;

        
        if (Input.GetButtonDown("Fire1"))
            shootingStrategy.Shoot(GunPoint, bulletPrefab);

        
        if (Input.GetKeyDown(KeyCode.Alpha1)) shootingStrategy = new SingleShot();
        if (Input.GetKeyDown(KeyCode.Alpha2)) shootingStrategy = new ShotgunShot();

        _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        movementStrategy.Move(this, _input);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SetMovementStrategy(new SpeedBoostDecorator(new BasePlayerMovement(), 2f, 5f));
        }

    }

    public void SetVelocity(Vector2 dir)
    {
        rb.velocity = dir.normalized * speed;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        NotifyObservers();

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        if (deathMessage != null)
            deathMessage.enabled = true;

        
        GetComponent<Player>().enabled = false;

        
        rb.velocity = Vector2.zero;

        
        StartCoroutine(BackToMenu());
    }

    public void SetMovementStrategy(IPlayerMovement strategy)
    {
        movementStrategy = strategy;
    }

    private IEnumerator BackToMenu()
{
    yield return new WaitForSeconds(1f); 
    SceneManager.LoadScene("StartScreen"); 
}

}
