using UnityEngine;
using UnityEngine.UI;
using System;

public class Battle1Squads : MonoBehaviour {

    public Image[] PlayerSquadTiles;
    public Image[] MobSquadTiles;

    public Squad PlayerSquad;
    public Squad MobSquad;

    public Text[] moveUI;

    public delegate void MoveSelectedDelegate(int index);
    public MoveSelectedDelegate moveSelected;

    public void UpdateSquadTiles()
    {
        for (int i = 0; i < 6; i++)
        {
            PlayerSquadTiles[i].GetComponentInChildren<Text>().text = PlayerSquad.getCharacterAtPosition((TrialByFire.SquadPosition)i).Name;

            MobSquadTiles[i].GetComponentInChildren<Text>().text = MobSquad.getCharacterAtPosition((TrialByFire.SquadPosition)i).Name;
        }
    }

    public void UpdateMoves(Character character)
    {
        for (int i = 0; i < 6; i++)
        {
            moveUI[i].text = character.getMove(i).Name;
        }
    }

    public void OnMoveSelected(int index)
    {
        moveSelected(index);
    }
}
