using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public float launchForce;
    public Transform shotPoint;
    float nextAttackTime = 0f;

    Vector2 direction;

    void Update()
    {
        Vector2 cannonPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - cannonPosition;
        transform.right = direction;

        if (Input.GetMouseButton(0) & Time.time >= nextAttackTime)
        {
            Shoot();
            nextAttackTime = Time.time + 0.4f;
        }


    }

    void Shoot()
    {
        GameObject newBall = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        newBall.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
        FindObjectOfType<AudioManager>().Play("Shoot");
    }

}
