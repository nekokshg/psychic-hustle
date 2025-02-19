using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBattleHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI HPVal;
    [SerializeField] TextMeshProUGUI MPVal;
    [SerializeField] TextMeshProUGUI levelVal;

    Player _player;
    public void SetData(Player player)
    {
        _player = player;
        nameText.text = player.PlayerBase.Name;
        levelVal.text = (player.Level).ToString();
        HPVal.text = (player.HP).ToString();
        MPVal.text = (player.MP).ToString();
    }

    public void UpdateHP()
    {
        HPVal.text = (_player.HP).ToString();
    }

    public void UpdateMP()
    {
        MPVal.text = (_player.MP).ToString();
    }
}
