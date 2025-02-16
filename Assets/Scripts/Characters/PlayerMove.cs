using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains data of the moves that will change during the battle for the player
public class PlayerMove
{
    public PlayerMoveBase PMBase { get; set; }
    public int PP { get; set; }
    public int MP { get; set; }

    public PlayerMove(PlayerMoveBase pBase)
    {
        PMBase = pBase;
        PP = pBase.Pp;
        MP = pBase.MPCost;
    }
}
