using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleUnit : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase;
    [SerializeField] int level;

    public Player Player { get; set; }
    public void Setup()
    {
        Player = new Player(playerBase, level);
        GetComponent<Image>().sprite = Player.PlayerBase.FrontSprite;
    }
}
