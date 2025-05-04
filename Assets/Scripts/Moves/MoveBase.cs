using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : ScriptableObject
{
    [SerializeField] string mName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power; //Move strength
    [SerializeField] int accuracy; //0 - 100%
    [SerializeField] int pp; //How many times it can be used

    [SerializeField] MoveType moveType;
    [SerializeField] TargetType targetType;

    public string MName { get { return mName; } }
    public string Description { get { return description; } }
    public int Power { get { return power; } }
    public int Accuracy { get { return accuracy; } }
    
    public int Pp { get { return pp; } }

    public MoveType MoveType { get { return moveType; } }

    public TargetType TargetType { get { return targetType; } }

    public bool IsSpecial
    {
        get
        {
            if (MoveType == MoveType.Psychic || 
                MoveType == MoveType.Wit ||
                MoveType == MoveType.Cursed ||
                MoveType == MoveType.Weird)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}

public enum TargetType { Single, AoE, Self } //Note: AoE is area of effect