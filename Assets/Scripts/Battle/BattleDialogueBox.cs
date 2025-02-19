using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleDialogueBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;

    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] GameObject speaker;
    [SerializeField] TextMeshProUGUI speakerText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<TextMeshProUGUI> actionTexts;
    [SerializeField] List<TextMeshProUGUI> moveTexts;

    [SerializeField] TextMeshProUGUI PPText;
    [SerializeField] TextMeshProUGUI MPText;
    [SerializeField] TextMeshProUGUI MoneyText;

    public void SetDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }

    public IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach (var letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            //yield return new WaitForSeconds(1f / 30); //Wait for 30th of a second after adding a letter; 1 second will show 30 letters
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void EnableDialogueText(bool enabled) //<= add speaker game object enable code later
    {
        dialogueText.enabled = enabled;
    }

    public void EnableActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void EnableMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for (int i = 0; i < actionTexts.Count; ++i)
        {
            if (i == selectedAction) actionTexts[i].color = highlightedColor;
            else actionTexts[i].color = Color.white;
        }
    }

    public void UpdateMoveSection(int selectedMove, PlayerMove move)
    {
        for (int i = 0; i < moveTexts.Count; ++i)
        {
            if (i == selectedMove) moveTexts[i].color = highlightedColor;
            else moveTexts[i].color = Color.white;
        }

        PPText.text = $"PP: {move.PP}/{move.PMBase.Pp}";
        MoneyText.text = $"$: {move.Money}";
        MPText.text = $"MP: {move.MP}";
    }

    public void SetMoveNames(List<PlayerMove> pMoves)
    {
        for (int i = 0; i < moveTexts.Count; ++i)
        {
            if (i < pMoves.Count)
            {
                moveTexts[i].text = pMoves[i].PMBase.MName;
            } else
            {
                moveTexts[i].text = "-";
            }
        }
    }
}
