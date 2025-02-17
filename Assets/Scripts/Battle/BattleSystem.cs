using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    [SerializeField] PlayerBattleUnit playerUnit;
    [SerializeField] PlayerBattleHud playerHud;
    [SerializeField] EnemyBattleUnit enemyUnit;
    [SerializeField] EnemyBattleHud enemyHud;

    private void Start()
    {
        SetupBattle();
    }

    public void SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Player);
        enemyHud.SetData(enemyUnit.Enemy);
    }
}
