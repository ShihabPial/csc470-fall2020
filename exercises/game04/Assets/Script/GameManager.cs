using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject zombiePrefab;

	public Text scoreText;
	int score = 0;

	void Start()
	{	
		scoreText.text = score.ToString();

		for (int i = 0; i < 100; i++)
		{
			
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 0, z);
			
			float y = Terrain.activeTerrain.SampleHeight(pos);
			pos.y = y;
			
			GameObject zombie = Instantiate(zombiePrefab, pos, Quaternion.identity);
			
			zombie.transform.Rotate(0, Random.Range(0, 360), 0);
		}

		for (int i = 0; i < 100; i++)
		{
			float x = Random.Range(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.x + Terrain.activeTerrain.terrainData.size.x);
			float z = Random.Range(Terrain.activeTerrain.transform.position.z, Terrain.activeTerrain.transform.position.z + Terrain.activeTerrain.terrainData.size.z);
			Vector3 pos = new Vector3(x, 0, z);
			float y = Terrain.activeTerrain.SampleHeight(pos) + Random.Range(10, 80);
			pos.y = y;
		}
	}

	void Update()
	{

	}

	public void IncreaseScore()
	{
		score++;
		scoreText.text = score.ToString();
	}
}
