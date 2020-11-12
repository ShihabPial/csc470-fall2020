using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WarriorManagerScript : MonoBehaviour
{
	public WarriorScript selectedUnit;

	public GameObject namePanel;
	public Text nameText;

	public Image healthImage;
	public Image defenseImage;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void GoButtonClicked()
	{
		if (selectedUnit != null)
		{
			selectedUnit.StartFollowingPath();
		}
	}

	public void SelectUnit(WarriorScript toSelect)
	{
		selectedUnit = toSelect;

		GameObject[] units = GameObject.FindGameObjectsWithTag("Warrior");

		for (int i = 0; i < units.Length; i++)
		{
			WarriorScript ws = units[i].GetComponent<WarriorScript>();
			ws.selected = false;
			ws.UpdateVisuals();
		}

		if (toSelect != null)
		{
			selectedUnit.selected = true;

			UpdateUI(toSelect);

			selectedUnit.UpdateVisuals();
		}
		else
		{
			namePanel.SetActive(false);
		}
	}

	public void UpdateUI(WarriorScript unit)
	{
		healthImage.fillAmount = unit.currentHealth / 100f;
		defenseImage.fillAmount = unit.currentDefense / 100f;
		nameText.text = unit.unitName;
		namePanel.SetActive(true);
	}

}
