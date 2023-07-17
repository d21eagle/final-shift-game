using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);

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
        transform.position = Vector2.MoveTowards(
            transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
