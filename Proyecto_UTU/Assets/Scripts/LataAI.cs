using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class LataAI : MonoBehaviour
{

    public Transform target;
    SpriteRenderer playerColor;

    int vidas = 9;
    public float speed = 200f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;
    bool agro = false;

    Seeker seeker;
    Rigidbody2D rb;

    void Start()
    {
        playerColor = GetComponent<SpriteRenderer>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    void FixedUpdate()
    {
        playerColor.color = Color.Lerp(playerColor.color, Color.white, Time.deltaTime / 0.2f);
        Vector2 enemyPosition = transform.position;
        Vector2 playerPosition = target.position;
        float diference = Vector3.Distance(playerPosition, enemyPosition);
        if (diference <= 14f)
        {
            agro = true;
        }
        if (agro)
        {
            if (path == null)
                return;

            if (currentWayPoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

            if (distance < nextWayPointDistance)
            {
                currentWayPoint++;
            }
        }


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
