using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBattleHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI HPText;
    [SerializeField] TextMeshProUGUI MPText;

    public void SetData(Player player)
    {
        nameText.text = player.PlayerBase.Name;
        HPText.text = "HP: " + player.HP;
        MPText.text = "MP: " + player.MP;
    }
}
