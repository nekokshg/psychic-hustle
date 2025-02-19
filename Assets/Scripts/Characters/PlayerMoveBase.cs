using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player Move", menuName ="Moves/Create new player move")]
public class PlayerMoveBase : MoveBase
{
    [SerializeField] int mpCost; //Amount of psychic power needed to do the move
    [SerializeField] int moneyCost; //Amount of money needed to do the move
    public int MPCost { get { return mpCost; }}

    public int MoneyCost { get { return moneyCost; }}
}
