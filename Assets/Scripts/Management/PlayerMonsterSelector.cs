using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMonsterSelector : MonoBehaviour {
	[Space(5f)]
	[Header("Dependencies")]
	public MonsterList monsters;
	public Image uiImage;
	public TextMeshProUGUI uiText;
	public GameObject selectedOverlay;
	public PlayerSelectCanvas psc;

	[Space(5f)]
	[Header("Variables")]
	public int playerID;

	public int currentMonsterIndex = 0;

	private float _inputCooldown = 0.25f;
	private float _canReceiveInputCounter = 0f;

	public bool selected = false;

	public MonsterType selectedMonster;
	
	void Start () {
		UpdateMonsterUI(currentMonsterIndex);
	}

	void Update () {
		if (!selected) {
			if (Input.GetButtonDown(playerID + "_attack")) {
				//input_submit
				selected = true;
				selectedOverlay.SetActive(true);
			}

			if (_canReceiveInputCounter < Time.time) {
				if (Input.GetAxis(playerID + "_horizontal") > 0.5f) {
					_canReceiveInputCounter = Time.time + _inputCooldown;
					currentMonsterIndex++;
					if (currentMonsterIndex >= monsters.monsters.Length) currentMonsterIndex = 0;
					UpdateMonsterUI(currentMonsterIndex);
				} else if (Input.GetAxis(playerID + "_horizontal") < -0.5f) {
					_canReceiveInputCounter = Time.time + _inputCooldown;
					currentMonsterIndex--;
					if (currentMonsterIndex < 0) currentMonsterIndex = monsters.monsters.Length - 1;
					UpdateMonsterUI(currentMonsterIndex);
				}
			}
		} else {
			if (Input.GetButtonDown(playerID + "_cancel")) {
				//input_cancel
				selected = false;
				selectedOverlay.SetActive(false);
			}
		}
	}

	void UpdateMonsterUI (int monsterIndex) {
		uiImage.sprite = monsters.monsters[monsterIndex].uiImage;
		uiText.text = monsters.monsters[monsterIndex].name;
	}
}
