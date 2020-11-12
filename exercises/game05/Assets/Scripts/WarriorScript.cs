using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WarriorScript : MonoBehaviour
{
	WarriorManagerScript gm;

	public string unitName;
	public int maxHealth = 100;
	public int currentHealth;
	public int currentDefense;
	public HealthBarScript healthBar;

	List<GameObject> path;
	int pathIndex = 0;
	bool moving = false;

	float speed = 5f;
	float rotateSpeed = 4f;

	Vector3 targetPosition;

	public bool selected = false;
	public bool hover = false;

	public Color hoverColor;
	public Color selectedColor;
	public Color defaultColor;

	public Renderer rend;

	public CharacterController cc;

	// Start is called before the first frame update
	void Start()
	{
		UpdateVisuals();

		path = new List<GameObject>();

		targetPosition = transform.position;

		gm = GameObject.Find("WarriorManagerObject").GetComponent<WarriorManagerScript>();
	}

	// Update is called once per frame
	void Update()
	{
		if (selected)
		{
			if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit))
				{
					if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
					{
						GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
						targetPosition = hit.point;

					}
				}
				else
				{
					gm.SelectUnit(null);
				}
			}
		}

		if (Vector3.Distance(transform.position, targetPosition) > 0.5f)
		{
			Vector3 vectorToTarget = targetPosition - transform.position;
			vectorToTarget = vectorToTarget.normalized;

			float step = rotateSpeed * Time.deltaTime;

			Vector3 newDirection = Vector3.RotateTowards(transform.forward, vectorToTarget, step, 1);
			transform.rotation = Quaternion.LookRotation(newDirection);

			cc.Move(transform.forward * speed * Time.deltaTime);
		}
		else
		{
			if (moving && path.Count > 0)
			{

				pathIndex++;
				if (pathIndex == path.Count)
				{
					foreach (GameObject pathObj in path)
					{
						Destroy(pathObj);
					}
					path = new List<GameObject>();
					moving = false;
				}
				else
				{
					targetPosition = path[pathIndex].transform.position;
				}
			}
		}
	}

	public void StartFollowingPath()
	{
		pathIndex = 0;
		if (path.Count > 0)
		{
			targetPosition = path[pathIndex].transform.position;
			moving = true;
		}
	}

	public void UpdateVisuals()
	{
		if (selected)
		{
			rend.material.color = selectedColor;
		}
		else
		{
			if (hover)
			{
				rend.material.color = hoverColor;
			}
			else
			{
				rend.material.color = defaultColor;
			}

		}
	}
	private void OnMouseEnter()
	{
		hover = true;
		UpdateVisuals();
	}

	private void OnMouseExit()
	{
		hover = false;
		UpdateVisuals();
	}

	private void OnMouseDown()
	{
		selected = !selected;
		// If after clicking the unit is selected, tell the GameManager to select it.
		if (selected)
		{
			gm.SelectUnit(this);
		}
	}

	private void takeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.setHealth(currentHealth);
	}
}