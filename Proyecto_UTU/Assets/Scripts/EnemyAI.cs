using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public GameObject player;
    public GameObject ball;
    public Transform shotPoint;
    public Animator animator;

    public float launchForce = 20f;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    int vidas = 2;

    void Update()
    {
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = playerPosition - enemyPosition;
        float distance = Vector3.Distance(playerPosition, enemyPosition);
        shotPoint.right = direction;

        if (Time.time >= nextAttackTime)
        {
            if (distance <= 10f)
        {
                animator.SetBool("Agro", true);
            Attack();
                nextAttackTime = Time.time + 2f / attackRate;
                
            }
            else
            {
                animator.SetBool("Agro", false);
            }
        }

        
    }

    void Attack()
    {
        GameObject newBall = Instantiate(ball, shotPoint.position, shotPoint.rotation);
        newBall.GetComponent<Rigidbody2D>().velocity = shotPoint.right * launchForce;
        Destroy(newBall, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("arrow"))
        {
            vidas--;
            if (vidas < 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
