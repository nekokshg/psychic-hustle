using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerBattleUnit : MonoBehaviour
{
    [SerializeField] PlayerBase playerBase;
    [SerializeField] int level;
    Vector3 originalPos;

    public Player Player { get; set; }

    Image playerImage;
    Color originalColor;

    private void Awake()
    {
        playerImage = GetComponent<Image>();
        originalPos = playerImage.transform.localPosition;
        originalColor= playerImage.color;
    }
    public void Setup()
    {
        Player = new Player(playerBase, level);
        playerImage.sprite = Player.PlayerBase.FrontSprite;
        PlayerEnterAnimation();
    }
    public void PlayerEnterAnimation()
    {
        playerImage.transform.localPosition = new Vector3(originalPos.x, -143f);

        playerImage.transform.DOLocalMoveY(originalPos.y, 1f);
    }

    public void PlayerAttackAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(playerImage.transform.DOLocalMoveY(originalPos.y + 20f, 0.25f));
        sequence.Append(playerImage.transform.DOLocalMoveY(originalPos.y, 0.25f));
    }

    public void PlayerHitAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(playerImage.DOColor(Color.red, 0.1f));
        sequence.Append(playerImage.DOColor(originalColor, 0.1f));
    }

    public void PlayerFaintAnimation()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(playerImage.transform.DOLocalMoveY(originalPos.y - 150f, 0.5f));
        sequence.Join(playerImage.DOFade(0f, 0.5f));
    }
}
