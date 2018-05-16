using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour {
	public Transform[] explosionSpawners;
	public GameObject explosionPrefab;
	public int numberOfExplosions;
	public float explosionIntervalMin;
	public float explosionIntervalMax;

	void Start () {
		StartCoroutine(ExplosionTimer(0));
	}
	IEnumerator ExplosionTimer (float t) {
		yield return new WaitForSeconds(t);
		numberOfExplosions--;
		if (numberOfExplosions >= 0) {
			int r = Random.Range(0, explosionSpawners.Length);
			Destroy(Instantiate(explosionPrefab, explosionSpawners[r].position, explosionSpawners[r].rotation), 5f);
			float i = Random.Range(explosionIntervalMin, explosionIntervalMax);
			StartCoroutine(ExplosionTimer(i));
		}
	}
}
