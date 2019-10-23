using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterInformation", menuName = "Game Stats/Monster Information")]
public class MonsterInformation : ScriptableObject {
	public string name;
	public Sprite uiImage;
	public GameObject monsterPrefab;
	public MonsterType monsterType;
}
