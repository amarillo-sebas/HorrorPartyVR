using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterList", menuName = "Game Stats/Monster List")]
public class MonsterList : ScriptableObject {
	public MonsterInformation[] monsters;
}
