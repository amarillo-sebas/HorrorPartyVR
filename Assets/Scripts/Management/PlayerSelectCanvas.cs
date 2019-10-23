using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectCanvas : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public MonsterList monsters;
	public PlayerMonsterSelector[] players;

	private GameObject[] _monsterSpawns;

	void Start () {
		Time.timeScale = 1f;
		_monsterSpawns = GameObject.FindGameObjectsWithTag("MonsterSpawn");

		switch (PlayerManager.playerManager.numberOfPlayers) {
			case 1:
				players[1].gameObject.SetActive(false);
				players[1].selected = true;
				players[2].gameObject.SetActive(false);
				players[2].selected = true;
				players[3].gameObject.SetActive(false);
				players[3].selected = true;
			break;
			case 2:
				players[2].gameObject.SetActive(false);
				players[2].selected = true;
				players[3].gameObject.SetActive(false);
				players[3].selected = true;
			break;
			case 3:
				players[3].gameObject.SetActive(false);
				players[3].selected = true;
			break;
		}
	}

	private bool _gameStarted = false;
	void Update () {
		if (!_gameStarted) {
			bool ready = true;
			foreach (PlayerMonsterSelector pms in players) {
				if (!pms.selected) {
					ready = false;
					break;
				}
			}

			if (ready) {
				StartCoroutine(StartGame());
			}
		}
	}

	IEnumerator StartGame () {
		_gameStarted = true;
		transform.GetChild(0).gameObject.SetActive(false);
		yield return new WaitForSeconds(0.1f);
		int r;
		if (PlayerManager.playerManager.numberOfPlayers >= 1) {
			r = Random.Range(0, _monsterSpawns.Length);
			GameObject m1 = Instantiate(monsters.monsters[players[0].currentMonsterIndex].monsterPrefab, _monsterSpawns[r].transform.position, _monsterSpawns[r].transform.rotation);
			m1.GetComponent<ControllerPlayerID>().playerNumber = 1;
		}
		if (PlayerManager.playerManager.numberOfPlayers >= 2) {
			r = Random.Range(0, _monsterSpawns.Length);
			GameObject m2 = Instantiate(monsters.monsters[players[1].currentMonsterIndex].monsterPrefab, _monsterSpawns[r].transform.position, _monsterSpawns[r].transform.rotation);
			m2.GetComponent<ControllerPlayerID>().playerNumber = 2;
		}
		if (PlayerManager.playerManager.numberOfPlayers >= 3) {
			r = Random.Range(0, _monsterSpawns.Length);
			GameObject m3 = Instantiate(monsters.monsters[players[2].currentMonsterIndex].monsterPrefab, _monsterSpawns[r].transform.position, _monsterSpawns[r].transform.rotation);
			m3.GetComponent<ControllerPlayerID>().playerNumber = 3;
		}
		if (PlayerManager.playerManager.numberOfPlayers >= 4) {
			r = Random.Range(0, _monsterSpawns.Length);
			GameObject m4 = Instantiate(monsters.monsters[players[3].currentMonsterIndex].monsterPrefab, _monsterSpawns[r].transform.position, _monsterSpawns[r].transform.rotation);
			m4.GetComponent<ControllerPlayerID>().playerNumber = 4;
		}
		yield return new WaitForSeconds(0.1f);
		Destroy(gameObject);
	}
}
