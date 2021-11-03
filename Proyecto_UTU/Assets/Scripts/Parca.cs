using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parca : MonoBehaviour
{

	public Transform player;
	public Animator animator;
	public Animator transition;
	public GameObject ball;
	public Transform shotPoint;
	SpriteRenderer playerColor;

	public bool isFlipped = false;

	public float launchForce = 40f;
	public float attackRate = .5f;
	public int vidas = 80;

    private void Start()
    {
		playerColor = GetComponent<SpriteRenderer>();
		InvokeRepeating("Atacar", 0f, attackRate);
	}

    private void Update()
    {
		playerColor.color = Color.Lerp(playerColor.color, Color.white, Time.deltaTime / 0.2f);

	}

	void Atacar()
    {
		animator.SetTrigger("Attack");
		Vector2 enemyPosition = shotPoint.position;
		Vector2 playerPosition = player.transform.position;
		Vector2 direction = playerPosition - enemyPosition;
		shotPoint.right = direction;
		GameObject newBall = Instantiate(ball, shotPoint.position, shotPoint.rotation);
		newBall.GetComponent<Rigidbody2D>().velocity = shotPoint.right * launchForce;
		FindObjectOfType<AudioManager>().Play("Enemy_Shoot");
		Destroy(newBall, 2f);
    }
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
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
				ScoreManager.puntuacionFinal += TimeManager.x;
				FindObjectOfType<LevelLoader>().LoadNextLevel();
				FindObjectOfType<AudioManager>().Play("Explosion");
				Destroy(this.gameObject);
			}
		}
	}

}