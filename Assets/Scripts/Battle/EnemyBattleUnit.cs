using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyBattleUnit : MonoBehaviour
{
    [SerializeField] EnemyBase enemyBase;
    [SerializeField] int level;
    public Enemy Enemy { get; set; }

    RectTransform rectTransform;

    Image enemyImage;
    float fadeDuration = 1.5f;

    Vector3 originalPos;
    Color originalColor;

    private void Awake()
    {
        enemyImage = GetComponent<Image>();
        originalPos = enemyImage.transform.localPosition;
        originalColor = enemyImage.color;
    }
    public void Setup()
    {
        Enemy = new Enemy(enemyBase, level);

        if (enemyBase.IsSmall)
        {
            rectTransform = GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(64f, 64f);
        }

        enemyImage.sprite = Enemy.EnemyBase.FrontSprite;

        Color tempColor = enemyImage.color;
        tempColor.a = 0f;
        enemyImage.color = tempColor;

        StartCoroutine(FadeInEnemy());
    }

    public IEnumerator FadeInEnemy()
    {
        float elapsedTime = 0f;
        Color tempColor = enemyImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            tempColor.a = Mathf.Lerp(0f, 1f, elapsedTime/fadeDuration);
            enemyImage.color=tempColor;
            yield return null;
        }

        tempColor.a = 1f;
        enemyImage.color = tempColor;
    }

    public void EnemyAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(enemyImage.transform.DOLocalMoveY(originalPos.y - 20f, 0.25f));
        sequence.Append(enemyImage.transform.DOLocalMoveY(originalPos.y, 0.25f));
    }

    public void EnemyHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(enemyImage.DOColor(Color.red, 0.1f));
        sequence.Append(enemyImage.DOColor(originalColor, 0.1f));
    }

    public void EnemyFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(enemyImage.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(enemyImage.DOFade(0f, 0.5f));
    }
}
