using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleUnit : MonoBehaviour
{
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] int level;
    public Enemy Enemy { get; set; }

    RectTransform rectTransform;
    public void Setup()
    {
        Enemy = new Enemy(enemyBase, level);

        if (enemyBase.IsSmall)
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(64f, 64f);
        }

        GetComponent<Image>().sprite = Enemy.EnemyBase.FrontSprite;
    }
}
