using UnityEngine;
using UnityEngine.UI;
using TrialByFire;
using System.Collections;

public class Battle1Squads : MonoBehaviour
{

    public Image[] PlayerSquadTiles;
    public Image[] MobSquadTiles;

    public Squad PlayerSquad;
    public Squad MobSquad;

    public Text characterName;
    public Text characterStats;
    public Text[] moveUI;

    public delegate void MoveSelectedDelegate(Character currentCharacter, Squad targetSquad, SquadPosition destination, Move move);
    public MoveSelectedDelegate moveSelected;

    private Character currentCharacter;
    private Move currentMove;
    private Squad targetSquad;

    public void UpdateSquadTiles()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerSquadTiles[i].GetComponentInChildren<Text>().text = PlayerSquad.getCharacterAtPosition((TrialByFire.SquadPosition)i).Name;

            MobSquadTiles[i].GetComponentInChildren<Text>().text = MobSquad.getCharacterAtPosition((TrialByFire.SquadPosition)i).Name;
        }
    }

    public void UpdateMoves(Character newCharacter)
    {
        characterName.text = newCharacter.Name;
        characterStats.text =
            "Stats:\n"
            + newCharacter.CurrentHealth + " Health\n"
            + newCharacter.CurrentSpeed + " Speed\n"
            + newCharacter.CurrentStrength + " Strength\n"
            + newCharacter.CurrentAccuracy + " Accuracy\n";

        for (int i = 0; i < 6; i++)
        {
            moveUI[i].text = newCharacter.getMove(i).Name;
        }

        currentCharacter = newCharacter;
        StartCoroutine("resetAnimation");
    }

    void activateTile(Character character, Color c)
    {

        SquadPosition sp;
        Image[] i;
        if (character.Side == TrialByFire.SquadSide.LEFT)
        {
            sp = PlayerSquad.findCharacterPosition(character);
            i = PlayerSquadTiles;
        }
        else
        {
            sp = MobSquad.findCharacterPosition(character);
            i = MobSquadTiles;
        }

        if (sp == SquadPosition.NONE)
        {
            Debug.LogError("Position Not Found!");
            return;
        }

        i[(int)sp].color = c;
        i[(int)sp].GetComponent<Button>().interactable = (c == Color.yellow);
    }

    public void OnMoveSelected(int index)
    {
        if (currentMove != null)
        {
            for (int i = 0; i < 6; i++)
            {
                activateTile(MobSquad.getCharacterAtPosition((SquadPosition)i), Color.white);
                activateTile(PlayerSquad.getCharacterAtPosition((SquadPosition)i), Color.white);
            }
            activateTile(currentCharacter, Color.red);
        }

        currentMove = currentCharacter.getMove(index);
        switch (currentMove.Target)
        {
            case MoveTarget.ENEMY:
                targetSquad = (currentCharacter.Side == SquadSide.LEFT) ? MobSquad : PlayerSquad;

                for (int i = 0; i < 6; i++)
                {
                    activateTile(targetSquad.getCharacterAtPosition((SquadPosition)i), Color.yellow);
                }
                break;
            case MoveTarget.FRIENDLY:
                targetSquad = (currentCharacter.Side == SquadSide.LEFT) ? PlayerSquad : MobSquad;
                for (int i = 0; i < 6; i++)
                {
                    activateTile(targetSquad.getCharacterAtPosition((SquadPosition)i), Color.yellow);
                }
                break;
            case MoveTarget.SELF:
                targetSquad = (currentCharacter.Side == SquadSide.LEFT) ? PlayerSquad : MobSquad;
                for (int i = 0; i < 6; i++)
                {
                    activateTile(currentCharacter, Color.yellow);
                }
                break;
        }
    }

    public void OnTargetSelected(int index)
    {
        for (int i = 0; i < 6; i++)
        {
            activateTile(MobSquad.getCharacterAtPosition((SquadPosition)i), Color.white);
            activateTile(PlayerSquad.getCharacterAtPosition((SquadPosition)i), Color.white);
        }

        moveSelected(currentCharacter, targetSquad, (SquadPosition)index, currentMove);
    }

    public void HitAnimation(Squad targetSquad, Character c)
    {
        Image i = (targetSquad == PlayerSquad) ? PlayerSquadTiles[(int)targetSquad.findCharacterPosition(c)] : MobSquadTiles[(int)targetSquad.findCharacterPosition(c)];
        i.color = Color.cyan;
    }

    public void MissAnimation(Squad targetSquad, Character c)
    {
        Image i = (targetSquad == PlayerSquad) ? PlayerSquadTiles[(int)targetSquad.findCharacterPosition(c)] : MobSquadTiles[(int)targetSquad.findCharacterPosition(c)];
        i.color = Color.grey;
    }

    public IEnumerator resetAnimation()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 6; i++)
        {
            activateTile(MobSquad.getCharacterAtPosition((SquadPosition)i), Color.white);
            activateTile(PlayerSquad.getCharacterAtPosition((SquadPosition)i), Color.white);
        }
        activateTile(currentCharacter, Color.red);
    }
}