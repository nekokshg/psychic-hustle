using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In charge of calculating all the values specific to a level for Player Scriptable Objects
public class Player
{
    PlayerBase playerBase;
    int level;
    public int HP { get; set; } //represents current hp

    public List<PlayerMove> PlayerMoves { get; set; } //The list of all moves that a player has

    public Player(PlayerBase pBase, int pLevel)
    {
        playerBase = pBase;
        level = pLevel;
        HP = pBase.MaxHp;

        PlayerMoves = new List<PlayerMove>();
        //Loop through learnable moves and add it to Moves depending on the level
        foreach (var move in playerBase.PlayerLearnableMoves)
        {
            if (move.Level <= level)
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
    public int MaxHp { get { return Mathf.Min(300, Mathf.FloorToInt(playerBase.MaxHp * Mathf.Pow(1.04f, level))); } }
    public int Mp { get { return Mathf.Min(150, Mathf.FloorToInt(playerBase.MP * Mathf.Pow(1.04f, level))); } }
    public int Attack { get { return Mathf.Min(100, Mathf.FloorToInt(playerBase.Attack * Mathf.Pow(1.04f, level))); } }
    public int Defense { get { return Mathf.Min(150, Mathf.FloorToInt(playerBase.Defense * Mathf.Pow(1.03f, level))); } }
    public int SpAttack { get { return Mathf.Min(120, Mathf.FloorToInt(playerBase.SpAttack * Mathf.Pow(1.045f, level))); } }
    public int SpDefense { get { return Mathf.Min(150, Mathf.FloorToInt(playerBase.SpDefense * Mathf.Pow(1.035f, level))); } }
    public int Speed { get { return Mathf.Min(75, Mathf.FloorToInt(playerBase.Speed * Mathf.Pow(1.03f, level))); } }

}
