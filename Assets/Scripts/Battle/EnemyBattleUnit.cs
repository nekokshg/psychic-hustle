using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleUnit : MonoBehaviour
{
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] int level;

    public Enemy Enemy { get; set; }
    public void Setup()
    {
        Enemy = new Enemy(enemyBase, level);
        GetComponent<Image>().sprite = Enemy.EnemyBase.FrontSprite;
    }
}
