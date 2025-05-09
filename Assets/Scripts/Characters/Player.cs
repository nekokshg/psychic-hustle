using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In charge of calculating all the values specific to a level for Player Scriptable Objects
public class Player
{
    public PlayerBase PlayerBase { get; set; }
    public int Level { get; set; }
    public int HP { get; set; } //represents current hp
    public int MP { get; set; }

    public List<PlayerMove> PlayerMoves { get; set; } //The list of all moves that a player has

    public Player(PlayerBase pBase, int pLevel)
    {
        PlayerBase = pBase;
        Level = pLevel;

        HP = MaxHp;
        MP = MaxMp;

        PlayerMoves = new List<PlayerMove>();
        //Loop through learnable moves and add it to Moves depending on the level
        foreach (var move in PlayerBase.PlayerLearnableMoves)
        {
            if (move.Level <= Level)
            {
                PlayerMoves.Add(new PlayerMove(move.PlayerMoveBase));
            }
            if (PlayerMoves.Count >= 4) break;
        }
    }

    /* Cap Values for the Player
     * HP: 300
     * PSY (MP): 150
     * ATK: 100
     * DEF: 80
     * SPATK: 120
     * SPDEF: 90
     * SPD: 75
     */

    //Initial Stat Growth Formula (Exponential Growth) : New Stat = min(Cap, Base Stat * (1 + Growth Rate)^(Level))
    public int MaxHp { get { return Mathf.Min(300, Mathf.FloorToInt(PlayerBase.MaxHp * Mathf.Pow(1.04f, Level))); } }
    public int MaxMp { get { return Mathf.Min(150, Mathf.FloorToInt(PlayerBase.MP * Mathf.Pow(1.04f, Level))); } }
    public int Attack { get { return Mathf.Min(100, Mathf.FloorToInt(PlayerBase.Attack * Mathf.Pow(1.04f, Level))); } }
    public int Defense { get { return Mathf.Min(150, Mathf.FloorToInt(PlayerBase.Defense * Mathf.Pow(1.03f, Level))); } }
    public int SpAttack { get { return Mathf.Min(120, Mathf.FloorToInt(PlayerBase.SpAttack * Mathf.Pow(1.045f, Level))); } }
    public int SpDefense { get { return Mathf.Min(150, Mathf.FloorToInt(PlayerBase.SpDefense * Mathf.Pow(1.035f, Level))); } }
    public int Speed { get { return Mathf.Min(75, Mathf.FloorToInt(PlayerBase.Speed * Mathf.Pow(1.03f, Level))); } }

    public PlayerDamageDetails TakeDamage(EnemyMove move, Enemy attacker) //<= Note: enemies can take money from player factor that in later
    {
        float type = TypeChart.GetEffectiveness(move.EMBase.MoveType, this.PlayerBase.CharacterType);

        float critical = 1f;
        if (Random.value * 100f <= 6.25) critical = 2f;

        var playerDamageDetails = new PlayerDamageDetails()
        {
            TypeEffectiveness = type,
            Critical = critical,
            Fainted = false,
        };

        float attack = (move.EMBase.IsSpecial) ? attacker.SpAttack : attacker.Attack;
        float defense = (move.EMBase.IsSpecial) ? SpDefense : Defense;
        float modifiers = Random.Range(0.85f, 1f) * critical * type;
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.EMBase.Power * ((float)attack / defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0) 
        {
            HP = 0;
            playerDamageDetails.Fainted= true;
        }
        return playerDamageDetails;
    }
}

public class PlayerDamageDetails
{
    public bool Fainted { get; set; }
    public float Critical { get; set; }

    public float TypeEffectiveness { get; set; }
} 