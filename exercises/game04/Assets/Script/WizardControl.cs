using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WizardControl : MonoBehaviour
{
	public GameObject firePrefab;

	int score = 0;

	public Text scoreText;

	float moveSpeed = 10;
	float rotateSpeed = 85;

	public CharacterController cc;

	bool prevIsGrounded = false;

	float yVelocity = 0;
	float jumpForce = 0.3f;
	float gravityModifier = 0.2f;

	void Start()
	{
		cc = gameObject.GetComponent<CharacterController>();
	}

	void Update()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		transform.Rotate(0, hAxis * rotateSpeed * Time.deltaTime, 0);

		if (!cc.isGrounded)
		{ 
			yVelocity = yVelocity + Physics.gravity.y * gravityModifier * Time.deltaTime;

			if (Input.GetKeyUp(KeyCode.Space) && yVelocity > 0)
			{
				yVelocity = 0;
			}
		}
		else
		{
			if (!prevIsGrounded)
			{
				yVelocity = 0;
			}

			if (Input.GetKeyDown(KeyCode.Space))
			{
				yVelocity = jumpForce;
			}

			if(Input.GetKey(KeyCode.Space))
            {
				yVelocity = jumpForce *  2;
            }

			if(Input.GetKeyDown(KeyCode.LeftShift))
            {
				moveSpeed += 12;
			}

			if(Input.GetKeyUp(KeyCode.LeftShift))
            {
				moveSpeed = 10;

			}
		}

		if(score % 5 == 0 && score > 0)
        {
			GameObject fireBall = Instantiate(firePrefab, transform.position + transform.forward * Time.deltaTime, Quaternion.identity);
			Rigidbody fireBallRb = fireBall.GetComponent<Rigidbody>();
			fireBallRb.AddForce(transform.forward * 8000);
			Destroy(fireBall, 5);

			moveSpeed += 0.1f;
		}

		if(score == 20)
        {
			SceneManager.LoadScene("GameOver");
		}

		Vector3 amountToMove = transform.forward * vAxis * moveSpeed * Time.deltaTime;

		amountToMove.y = yVelocity;

		cc.Move(amountToMove);

		prevIsGrounded = cc.isGrounded;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Zombie"))
		{
			Destroy(other.gameObject);
			score++;
			scoreText.text = score.ToString();
		}
	}
	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
