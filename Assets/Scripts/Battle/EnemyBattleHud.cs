using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyBattleHud : MonoBehaviour
{
    [SerializeField] HPBar hpBar;
    [SerializeField] TextMeshProUGUI levelVal;

    Enemy _enemy;
    public void SetData(Enemy enemy)
    {
        _enemy = enemy;
        hpBar.SetHP((float)enemy.HP / enemy.MaxHp);
        levelVal.text = (enemy.Level).ToString();
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_enemy.HP / _enemy.MaxHp);
    }
}
