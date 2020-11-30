using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotScript : MonoBehaviour
{
	public float lookradius = 10f;
	public NavMeshAgent agent;
	Transform target;

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(NavigationBehavior());
		target = PlayerController.instance.player.transform;
		agent = GetComponent<NavMeshAgent>();
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
	}

	void faceTarget()
    {
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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
}
