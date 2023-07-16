using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public float startTimeBtwShots;
    public Joystick gunRotJoystick;
    public Joybutton fireJoyButton;

    private float timeBtwShots;
    private float rotZ;
    private Vector3 difference;
    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        if (player.controlType == Player.ControlType.PC)
            fireJoyButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        // вращение оружия
        if (player.controlType == Player.ControlType.PC)
        {
            difference = Camera.main!.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        }
        else if (player.controlType == Player.ControlType.Android)
        {
            rotZ = Mathf.Atan2(gunRotJoystick.Vertical, gunRotJoystick.Horizontal) * Mathf.Rad2Deg;
        }
        
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        // механика стрельбы
        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0) && player.controlType == Player.ControlType.PC)
            {
                Shoot();
            }
            else if (player.controlType == Player.ControlType.Android)
            {
                if (fireJoyButton.pressed) Shoot();
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, shotPoint.position, transform.rotation);
        timeBtwShots = startTimeBtwShots;
    }
}
