using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    
    private Player player;
    private Rigidbody2D body;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        // поворот врага по оси Х
        if (player.transform.position.x > transform.position.x)
            transform.eulerAngles = new Vector3(0, 0, 0);
        else 
            transform.eulerAngles = new Vector3(0, 180, 0);
        
        // движение врага за игроком
        body.velocity = (player.transform.position - transform.position).normalized * speed;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
