using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Contains data of the moves that will change during the battle for the enemies
public class EnemyMove
{
    public EnemyMoveBase EMBase { get; set; }
    public int PP { get; set; }

    public EnemyMove(EnemyMoveBase eBase)
    {
        EMBase = eBase;
        PP = eBase.Pp;
    }
}
