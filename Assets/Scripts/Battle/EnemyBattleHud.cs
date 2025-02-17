using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBattleHud : MonoBehaviour
{
    [SerializeField] HPBar hpBar;

    public void SetData(Enemy enemy)
    {
        hpBar.SetHP((float)enemy.HP / enemy.MaxHp);
    }
}
