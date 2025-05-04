using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Player", menuName ="Characters/Player")]
public class PlayerBase : CharacterBase
{
    //Potential player names
    //Danny Debtworth (Rich in spirit, poor in funds)
    //Tommy Tappedout (Mentally and financially exhausted)
    //Timmy Telepay (Can move money with his mind... but only out of his wallet)
    //Chad stral

    [SerializeField] int mp; //PSY (MP) represent's the player's mental energy used for special attacks

    [SerializeField] float money;

    [SerializeField] Sprite frontSprite;

    [SerializeField] List<PlayerLearnableMoves> playerLearnableMoves;

    public int MP { get { return mp; } }
    public float Money { get { return money; } }
    public Sprite FrontSprite { get { return frontSprite;  } }

    public List<PlayerLearnableMoves> PlayerLearnableMoves { get { return playerLearnableMoves; } }
}

[System.Serializable]
public class PlayerLearnableMoves
{
    [SerializeField] PlayerMoveBase playerMoveBase;
    [SerializeField] int level; //level that the move will be learned

    public PlayerMoveBase PlayerMoveBase { get { return playerMoveBase; } }
    public int Level { get { return level; } }
}
