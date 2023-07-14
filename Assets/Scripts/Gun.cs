using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    void Update()
    {
        var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
