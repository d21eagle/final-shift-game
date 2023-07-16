using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;

    private void Start()
    {
        // Уничтожение снаряда через время
        Invoke(nameof(DestroyBullet), lifetime);
    }

    private void Update()
    {
        // нанесение урона врагу снарядом
        var hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            DestroyBullet();
        }
        
        // полёт снаряда
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
