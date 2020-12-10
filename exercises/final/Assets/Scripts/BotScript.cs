using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BotScript : MonoBehaviour
{
	public float lookradius = 10f;
	public NavMeshAgent agent;
	Transform target;
	public GameObject bullet;
	bool waitingToShoot = false;
	public float health = 80f;

	public MeterScript meter;

	public Image healthImage;

	public GameObject healthBox;

	public GameManager gm;


	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(NavigationBehavior());
		target = PlayerController.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
		healthBox.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		float distance = Vector3.Distance(target.position, transform.position);
		if(distance <= lookradius)
        {
			agent.SetDestination(target.position);
			if(distance <= agent.stoppingDistance)
            {
				faceTarget();
            }
        }

		if (Vector3.Distance(transform.position, target.transform.position) < 5f)
		{
			faceTarget(); 
				if (!waitingToShoot)
				{					
					waitingToShoot = true;
					GameObject bulletEgg = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
					Rigidbody eggRB = bulletEgg.GetComponent<Rigidbody>();
					eggRB.AddForce(transform.forward * 2000);
					StartCoroutine(wait());
					Destroy(bulletEgg, 5);
				}
		}
	}

	

	IEnumerator wait()
    {
		yield return new WaitForSeconds(1);
		waitingToShoot = false;
	}

	void faceTarget()
    {
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(direction);
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime);
	}

    private void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookradius);
    }

    IEnumerator NavigationBehavior()
	{
		while (true)
		{
			Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
			agent.SetDestination(pos);

			yield return new WaitForSeconds(4);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Egg"))
		{
			healthBox.SetActive(true);
			takeDamage();
			if (health == 0)
            {
				healthBox.SetActive(false);
				Destroy(this.gameObject);
				gm.botCount--;
			}
			
		}
	}

	public void takeDamage()
	{
		this.health -= 10;
		updateUI();
	}

	void updateUI()
    {
		healthImage.fillAmount = health / 100f;
		Debug.Log(healthImage.fillAmount);
	}
}
