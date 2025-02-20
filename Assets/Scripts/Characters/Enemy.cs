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

    public EnemyDamageDetails TakeDamage(PlayerMove move, Player attacker)
    {
        float critical = 1f;
        if (Random.value * 100f <= 6.25) critical = 2f;

        var enemyDamageDetails = new EnemyDamageDetails()
        {
            Critical = critical,
            Fainted = false,
        };

        float modifiers = Random.Range(0.85f, 1f) * critical;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.PMBase.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            enemyDamageDetails.Fainted= true;
        }
        return enemyDamageDetails;
    }

    public EnemyMove GetRandomMove()
    {
        int r = Random.Range(0, EnemyMoves.Count);
        return EnemyMoves[r];
    }
}
public class EnemyDamageDetails
{
    public bool Fainted { get; set; }
    public float Critical { get; set; }
}