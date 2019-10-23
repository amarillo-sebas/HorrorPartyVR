using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;

public class PlayerSelectManager : MonoBehaviour {
	public GameObject previousGameObject;
	public GameObject nextGameObject;
	public PlayerPanelManager[] playerPanels;
	public bool[] foundPlayers;

	//private PlayerManager _playerManager;
	private int _numberOfPlayers = 0;

	[Header("Team sprites")]
	public Sprite noPlayerSprite;
	public Sprite playerSelectedSprite;

	private string _sceneToLoad;

	void Start () {
		//_playerManager = FindObjectOfType(typeof(PlayerManager)) as PlayerManager;
		if (playerPanels != null) {
			foundPlayers = new bool[playerPanels.Length];
		}
		ResetPanels();
	}
	
	void Update () {
		if (Input.GetButtonDown("Cancel")) {
			if (previousGameObject) {
				if (!foundPlayers[0]) {
					ResetPanels();
					previousGameObject.SetActive(true);
					gameObject.SetActive(false);
				}
			}
		}

		if (Input.GetButtonDown("Start")) {
			/*int humans = 0;

			foreach (bool foundPlayer in foundPlayers) {
				if (foundPlayer) humans++;
			}*/

			PlayerManager.playerManager.numberOfPlayers = _numberOfPlayers;
			//SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Single);

			//Switch to next panel
			nextGameObject.SetActive(true);
			gameObject.SetActive(false);
		}

		for (int i = 0; i < foundPlayers.Length; i++) {
			if (!foundPlayers[i]) {
				if (Input.GetButtonDown((i + 1) + "_attack")) {
					foundPlayers[i] = true;
					playerPanels[i].ButtonState(true);
					playerPanels[i].ChangeTeam(playerSelectedSprite);
					_numberOfPlayers++;
				}
			} else {
				if (Input.GetButtonDown((i + 1) + "_cancel")) {
					ResetPanel(i);
					_numberOfPlayers--;
				}
			}
		}
	}

	void ResetPanel (int ppm) {
		foundPlayers[ppm] = false;
		playerPanels[ppm].ButtonState(false);
		playerPanels[ppm].ChangeTeam(noPlayerSprite);
	}
	void ResetPanels () {
		for (int i = 0; i < playerPanels.Length; i++) {
			foundPlayers[i] = false;
			playerPanels[i].ButtonState(false);
			playerPanels[i].ChangeTeam(noPlayerSprite);
		}
	}
}
