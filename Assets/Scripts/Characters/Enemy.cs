using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In charge of calculating all the values specific to a level for a Enemy Scriptable Object
public class Enemy
{
    public EnemyBase EnemyBase { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public List<EnemyMove> EnemyMoves { get; set; } //The list of all moves that each enemy has 

    public Enemy(EnemyBase eBase, int eLevel)
    {
        EnemyBase = eBase;
        Level = eLevel;
        HP = MaxHp;

        EnemyMoves = new List<EnemyMove>();
        foreach (var move in EnemyBase.EnemyLearnableMoves)
        {
            if (move.Level <= Level)
            {
                EnemyMoves.Add(new EnemyMove(move.EnemyMoveBase));
            }
            if (EnemyMoves.Count >= 4) break;
        }
    }

    //Initial Stat Growth Formula (Linear Growth): Base Stat + (Level * Growth Factor)
    public int MaxHp { get { return EnemyBase.MaxHp + (Level * 4); } }
    public int Attack { get { return EnemyBase.Attack + (Level * 2); } }
    public int Defense { get { return EnemyBase.Defense + Mathf.FloorToInt(Level * 1.5f); } }
    public int SpAttack { get { return EnemyBase.SpAttack + Mathf.FloorToInt(Level * 2.5f); } }
    public int SpDefense { get { return EnemyBase.SpDefense + Mathf.FloorToInt(Level * 1.8f); } }
    public int Speed { get { return EnemyBase.Speed + Mathf.FloorToInt(Level * 1.2f); } }
}
