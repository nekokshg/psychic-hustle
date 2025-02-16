using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Sprites;
using UnityEngine;
public class CharacterBase : ScriptableObject
{
    [SerializeField] string _name;

    [TextArea]
    [SerializeField] string description;

    //Base stats
    [SerializeField] int maxHp; //Health points
    [SerializeField] int attack; //Attack, for physical moves
    [SerializeField] int defense; //Defense, reduces damage
    [SerializeField] int speed; //Speed, determines order
    [SerializeField] int spAttack; //Special Attack, used for special attacks; e.g. astral flick, loose change barrage
    [SerializeField] int spDefense; //Special Defense, used for resisting mind-affecting effects; e.g. confusion, possession, etc...

    //Properties
    public string Name { get { return _name; } }
    public string Description { get { return description; } }
    public int MaxHp { get { return maxHp; } }
    public int Attack { get { return attack; } }
    public int Defense { get { return defense; } }
    public int Speed { get { return speed; } }
    public int SpAttack { get { return spAttack; } }
    public int SpDefense { get { return spDefense; } }
}
