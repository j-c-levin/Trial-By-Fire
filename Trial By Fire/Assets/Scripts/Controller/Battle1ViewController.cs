﻿using UnityEngine;
using System.Collections;

public class Battle1ViewController : MonoBehaviour
{
    private Battle1Squads squadView;

    // Use this for initialization
    void Start()
    {
        squadView = GetComponent<Battle1Squads>();
        squadView.PlayerSquad = new Squad();
        squadView.MobSquad = new Squad();
        CreatePlayerSquad(squadView.PlayerSquad);
        CreatePlayerSquad(squadView.MobSquad);
        squadView.UpdateSquadTiles();
    }

    void CreatePlayerSquad(Squad squad)
    {
        squad.Initialize();
        Character newChar;
        #region create characters
        for (int i = 0; i < 6; i++)
        {
            //Create a new character with some random base stats
            newChar = new Character();
            newChar.setStat(TrialByFire.CharacterStats.ACCURACY, Random.Range(40, 70));
            newChar.setStat(TrialByFire.CharacterStats.ARMOUR, Random.Range(20, 50));
            newChar.setStat(TrialByFire.CharacterStats.CHANNELLING, Random.Range(40, 70));
            newChar.setStat(TrialByFire.CharacterStats.HEALTH, 100);
            newChar.setStat(TrialByFire.CharacterStats.SPEED, Random.Range(20, 70));
            newChar.setStat(TrialByFire.CharacterStats.STRENGTH, Random.Range(40, 70));
            newChar.setStat(TrialByFire.CharacterStats.SYNC, Random.Range(20, 70));
            int num1 = Random.Range(0, 26);
            int num2 = Random.Range(0, 26);
            int num3 = Random.Range(0, 26);
            char let1 = (char)('a' + num1);
            char let2 = (char)('a' + num2);
            char let3 = (char)('a' + num3);
            newChar.Name = let1.ToString() + let2.ToString() + let3.ToString();
            squad.setCharacterAtPosition
                (newChar, (TrialByFire.SquadPosition)i);
        }
        #endregion
    }
}
