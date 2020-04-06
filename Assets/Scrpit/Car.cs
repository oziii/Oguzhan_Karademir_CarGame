using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
	[Header("Gameobject")]
	[SerializeField] GameObject gm;

	[Header("Rigidbody2D")]
	Rigidbody2D rb;

	[Header("Float")]
	[SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	public float steeringAmount, speed, direction;

	[Header("Bool")]
	public bool gasButton = false;

	private void Awake()
	{
		gm = GameObject.Find("GameManager");
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		carMove();
	}

	void carMove()
	{
		if (gasButton)
		{
			gm.GetComponent<GameManager>().timeStart = true;
			speed = accelerationPower;
			rb.AddRelativeForce(Vector2.up * speed);
		}
		direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;
		rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("obstacle"))
		{
			Destroy(this.gameObject);
			gm.GetComponent<GameManager>().CarRestart();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("target"))
		{
			Destroy(this.gameObject);
			gm.GetComponent<GameManager>().NewCarEntance();
		}
	}
}
