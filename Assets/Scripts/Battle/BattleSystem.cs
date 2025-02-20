using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { Start, PlayerAction, PlayerMove, EnemyMove, Busy }
public class BattleSystem : MonoBehaviour
{
    [SerializeField] PlayerBattleUnit playerUnit;
    [SerializeField] PlayerBattleHud playerHud;
    [SerializeField] EnemyBattleUnit enemyUnit;
    [SerializeField] EnemyBattleHud enemyHud;
    [SerializeField] BattleDialogueBox dialogueBox;
    [SerializeField] GameObject moneyCounter;

    BattleState state;
    int currentAction;
    int currentMove;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Player);
        enemyHud.SetData(enemyUnit.Enemy);

        dialogueBox.SetMoveNames(playerUnit.Player.PlayerMoves);

        yield return dialogueBox.TypeDialogue($"You are now being harassed by a {enemyUnit.Enemy.EnemyBase.Name}");
        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogueBox.TypeDialogue("Choose an action"));
        dialogueBox.EnableActionSelector(true);
        
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogueBox.EnableActionSelector(false);
        dialogueBox.EnableDialogueText(false);
        dialogueBox.EnableMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        var move = playerUnit.Player.PlayerMoves[currentMove];
        yield return dialogueBox.TypeDialogue($"{playerUnit.Player.PlayerBase.Name} used {move.PMBase.MName}");

        var damageDetails = enemyUnit.Enemy.TakeDamage(move, playerUnit.Player);
        playerHud.UpdateMP();
        yield return enemyHud.UpdateHP();
        yield return ShowEnemyDamageDetails(damageDetails);

        if (damageDetails.Fainted)
        {
            yield return dialogueBox.TypeDialogue($"{enemyUnit.Enemy.EnemyBase.Name} got cleansed by the power of your spiritual energy lol");
        } else
        {
            StartCoroutine(PerformEnemyMove());
        }
    }

    IEnumerator PerformEnemyMove()
    {
        state = BattleState.EnemyMove;
        var move = enemyUnit.Enemy.GetRandomMove();
        yield return dialogueBox.TypeDialogue($"{enemyUnit.Enemy.EnemyBase.Name} used {move.EMBase.MName}");

        var damageDetails = playerUnit.Player.TakeDamage(move, enemyUnit.Enemy);
        playerHud.UpdateHP();
        yield return ShowPlayerDamageDetails(damageDetails);
        //UPDATE MONEY TOO FROM HERE (e.g. enemies can take player money) do later
        if (damageDetails.Fainted)
        {
            yield return dialogueBox.TypeDialogue($"{playerUnit.Player.PlayerBase.Name} got defeated...");
        }
        else
        {
            PlayerAction();
        }
    }

    IEnumerator ShowPlayerDamageDetails(PlayerDamageDetails damageDetails)
    {
        if (damageDetails.Critical > 1f)
        {
            yield return dialogueBox.TypeDialogue($"{enemyUnit.Enemy.EnemyBase.Name} performed a critical hit!!");
        }
    }

    IEnumerator ShowEnemyDamageDetails(EnemyDamageDetails damageDetails)
    {
        if (damageDetails.Critical > 1f)
        {
            yield return dialogueBox.TypeDialogue($"{playerUnit.Player.PlayerBase.Name} performed a critical hit!!");
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1) ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0) --currentAction;
        }

        dialogueBox.UpdateActionSelection(currentAction);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentAction == 0)
            {
                //Fight
                PlayerMove();

            } else if (currentAction == 1)
            {
                //Run
            }
        }
    }

    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerUnit.Player.PlayerMoves.Count - 1) ++currentMove;
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0) --currentMove;
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerUnit.Player.PlayerMoves.Count - 2) currentMove += 2;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMove > 1) currentMove-= 2;
        }

        dialogueBox.UpdateMoveSection(currentMove, playerUnit.Player.PlayerMoves[currentMove]);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            dialogueBox.EnableMoveSelector(false);
            dialogueBox.EnableDialogueText(true);
            StartCoroutine(PerformPlayerMove());
        }
    }

    private void Update()
    {
        if (state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        } else if (state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
}
