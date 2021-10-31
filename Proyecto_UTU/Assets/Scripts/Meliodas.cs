using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meliodas : MonoBehaviour
{

    public GameObject player;
    public GameObject ball;
    public Transform shotPoint;

    public float launchForce = 20f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public int vidas;
    SpriteRenderer playerColor;


    private void Start()
    {
        playerColor = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = playerPosition - enemyPosition;
        float distance = Vector3.Distance(playerPosition, enemyPosition);
        shotPoint.right = direction;

        if (Time.time >= nextAttackTime)
        {
            if (distance <= 15f)
            {
                Attack();
                nextAttackTime = Time.time + 2f / attackRate;

            }
        }

        playerColor.color = Color.Lerp(playerColor.color, Color.white, Time.deltaTime / 0.2f);

    }

    void Attack()
    {
        GameObject newBall = Instantiate(ball, shotPoint.position, shotPoint.rotation);
        newBall.GetComponent<Rigidbody2D>().velocity = shotPoint.right * launchForce;
        FindObjectOfType<AudioManager>().Play("Sword");
        Destroy(newBall, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("arrow"))
        {
            playerColor.color = new Color(2, 0, 0);
            vidas--;
            FindObjectOfType<AudioManager>().Play("Enemy_Hurt");
            if (vidas < 1)
            {
                FindObjectOfType<AudioManager>().Play("Explosion");
                Destroy(this.gameObject);
            }
        }
    }
}

