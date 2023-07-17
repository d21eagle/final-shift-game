using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public float runSpeed;
    public Joystick joystick;
    public ControlType controlType;
    public enum ControlType{PC, Android}
    
    private float moveLimiter = 0.7f;
    private float horizontal;
    private float vertical;
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private static readonly int State = Animator.StringToHash("State");

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (controlType == ControlType.PC)
        {
            horizontal = Input.GetAxisRaw("Horizontal"); 
            vertical = Input.GetAxisRaw("Vertical"); 
        }
        else if (controlType == ControlType.Android)
        {
            horizontal = joystick.Horizontal; 
            vertical = joystick.Vertical; 
        }
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // замедление игрока при движении по диагонали
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        
        // движение игрока
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
        // поворот игрока по оси Х и переключение анимаций
        if (horizontal != 0 || vertical != 0)
        {
            if (horizontal > 0)
                spriteRenderer.flipX = false;
            
            else if (horizontal < 0)
                spriteRenderer.flipX = true;
            
            animator.SetInteger(State, 1);
        } 
        else
            animator.SetInteger(State, 0);
    }

    public void ChangeHealth(int healthValue)
    {
        health += healthValue;
    }
}
