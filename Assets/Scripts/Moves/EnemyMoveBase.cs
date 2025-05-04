using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Move", menuName = "Moves/Create new enemy move")]
public class EnemyMoveBase : MoveBase
{
    [SerializeField] int moneyToTake;

    public int MoneyToTake { get; set; }
}
