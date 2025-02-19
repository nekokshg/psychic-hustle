using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Characters/Enemy")]
public class EnemyBase : CharacterBase
{
    [SerializeField] Sprite frontSprite;
    [SerializeField] List<EnemyLearnableMoves> enemyLearnableMoves;
    [SerializeField] bool isSmall;

    public Sprite FrontSprite { get { return frontSprite; } }
    public List<EnemyLearnableMoves> EnemyLearnableMoves { get { return enemyLearnableMoves; } }

    public bool IsSmall { get { return isSmall; } }
}

[System.Serializable]
public class EnemyLearnableMoves
{
    [SerializeField] EnemyMoveBase enemyMoveBase;
    [SerializeField] int level; //level that the move will be learned

    public EnemyMoveBase EnemyMoveBase { get { return enemyMoveBase; } }
    public int Level { get { return level; } }
}

