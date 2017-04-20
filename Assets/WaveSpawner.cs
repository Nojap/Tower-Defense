using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public Transform enemyPrefab;
	public float timeBetweenWaves = 5f;
	private float countdown = 2f;
	private int waveNumber = 1;
	public Transform SpawnPoint;
	public float WaitForSeconds;
	public Text WaveCountdownText;

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update ()
	{
		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			SpawnWave();
			countdown = timeBetweenWaves;
		}

		countdown -= Time.deltaTime;

		WaveCountdownText.text = Mathf.Round(countdown).ToString();
	}

	IEnumerator SpawnWave ()
	{
		for (int i = 0; i < waveNumber; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(WaitForSeconds);
		}


		waveNumber++;
	}

	void SpawnEnemy ()
	{
		Instantiate(enemyPrefab, SpawnPoint.position, SpawnPoint.rotation);
	}
}
