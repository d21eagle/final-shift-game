using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 8.0f;
    
    private Rigidbody2D body;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    
    public Joystick joystick;
    public ControlType controlType;
    public enum ControlType{PC, Android}

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    void Update()
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

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        
        if (horizontal != 0 || vertical != 0)
        {
            if (horizontal > 0)
                spriteRenderer.flipX = false;
            
            else if (horizontal < 0)
                spriteRenderer.flipX = true;
            
            animator.SetInteger("State", 1);
        } else
        {
            animator.SetInteger("State", 0);
        }
    }
}
