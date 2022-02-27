using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints;
	

	public float minDelay = .1f;
	public float maxDelay = 1.5f;


	// Use this for initialization
	void Start () {
		GameConstants.gameState = GameConstants.GameState.STARTED;
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits ()
	{
		while (GameConstants.gameState == GameConstants.GameState.STARTED)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];
			
			GameObject spawnedFruit = ObjectPool.sharedInstance.GetPooledObject();   //Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			if (spawnedFruit != null)
			{
				spawnedFruit.transform.position = spawnPoint.position;
				spawnedFruit.transform.rotation = spawnPoint.rotation;
				spawnedFruit.SetActive(true);
				//Destroy(spawnedFruit, 4f);
			}
		}
	}

}
