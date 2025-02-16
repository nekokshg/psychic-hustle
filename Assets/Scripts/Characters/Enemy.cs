using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In charge of calculating all the values specific to a level for a Enemy Scriptable Object
public class Enemy
{
    EnemyBase enemyBase;
    int level;
    public int HP { get; set; }
    public List<EnemyMove> EnemyMoves { get; set; } //The list of all moves that each enemy has 

    public Enemy(EnemyBase eBase, int eLevel)
    {
        enemyBase = eBase;
        level = eLevel;
        HP = eBase.MaxHp;

        EnemyMoves = new List<EnemyMove>();
        foreach (var move in enemyBase.EnemyLearnableMoves)
        {
            if (move.Level <= level)
            {
                EnemyMoves.Add(new EnemyMove(move.EnemyMoveBase));
            }
            if (EnemyMoves.Count >= 4) break;
        }
    }

    //Initial Stat Growth Formula (Linear Growth): Base Stat + (Level * Growth Factor)
    public int MaxHp { get { return enemyBase.MaxHp + (level * 4); } }
    public int Attack { get { return enemyBase.Attack + (level * 2); } }
    public int Defense { get { return enemyBase.Defense + Mathf.FloorToInt(level * 1.5f); } }
    public int SpAttack { get { return enemyBase.SpAttack + Mathf.FloorToInt(level * 2.5f); } }
    public int SpDefense { get { return enemyBase.SpDefense + Mathf.FloorToInt(level * 1.8f); } }
    public int Speed { get { return enemyBase.Speed + Mathf.FloorToInt(level * 1.2f); } }
}
