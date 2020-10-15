using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaneControl : MonoBehaviour
{
	public Rigidbody rb;

	int score = 0;

	public Text scoreText;

	float speed = 10;
	float forwardSpeed = 1;
	float pitchSpeed = 80;
	float pitchModSpeedRate = 8f;
	float rollSpeed = 80;

	public GameObject bulletPrefab;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		float xRot = vAxis * pitchSpeed * Time.deltaTime;
		float yRot = hAxis * rollSpeed / 4 * Time.deltaTime;
		float zRot = -hAxis * rollSpeed * Time.deltaTime;
		transform.Rotate(xRot, yRot, zRot, Space.Self);

		forwardSpeed += -transform.forward.y * pitchModSpeedRate * Time.deltaTime;

		forwardSpeed = Mathf.Clamp(forwardSpeed, 0, 5f);

		transform.Translate(transform.forward * speed * forwardSpeed * Time.deltaTime, Space.World);

		//if (forwardSpeed <= 0.1f)
		//{
		//	rb.isKinematic = false;
		//	rb.useGravity = true;
		//}


		float terrainHeight = Terrain.activeTerrain.SampleHeight(transform.position);
		if (transform.position.y < terrainHeight)
		{
			transform.position = new Vector3(transform.position.x, terrainHeight, transform.position.z);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			speed += 5;

			if (speed > 10)
			{
				speed -= 1 * Time.deltaTime;
			}

			else
			{
				speed = 10;
			}

		}

		if (Input.GetKeyDown(KeyCode.F))
		{
			GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * 3, Quaternion.identity);
			Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
			bulletRb.AddForce(transform.forward * 8000);
			Destroy(bullet, 5);
		}

		Vector3 cameraPosition = transform.position - transform.forward * 12 + Vector3.up * 5;
		Camera.main.transform.position = cameraPosition;
		Vector3 lookAtPos = transform.position + transform.forward * 8;

		Camera.main.transform.LookAt(lookAtPos, Vector3.up);

		if(score == 2)
        {
			SceneManager.LoadScene("FallingScene");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Baloon"))
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
