using UnityEngine;
using System.Collections.Generic;
using TrialByFire;

public class Battle1ViewController : MonoBehaviour
{
    private Battle1Squads squadView;
    ActionController actionController;

    // Use this for initialization
    void Start()
    {
        actionController = new ActionController();
        actionController.activeCharacter = NewTurn;
        squadView = GetComponent<Battle1Squads>();
        squadView.moveSelected = new Battle1Squads.MoveSelectedDelegate(ExecuteMove);
        squadView.PlayerSquad = new Squad();
        squadView.MobSquad = new Squad();
        CreatePlayerSquad(squadView.PlayerSquad);
        CreatePlayerSquad(squadView.MobSquad);
        squadView.UpdateSquadTiles();
        actionController.Begin();
    }

    void NewTurn(Character currentCharacter)
    {
        currentCharacter.activeTurn();
        squadView.UpdateMoves(currentCharacter);
    }

    void ExecuteMove(Character currentCharacter, Squad targetSquad, SquadPosition destination, Move move)
    {
        foreach (Character target in actionController.setTargets(move.Shape, targetSquad, destination))
        {
            if (target == null || target.CurrentState == CharacterState.DOWN)
                continue;

            //int hitChance = move.BaseHitChance + currentCharacter.getStat(move.HitIncreaseModifier) - target.getStat(move.HitDecreaseModifier);
            //int hit = Random.Range(0, 101);
            //Debug.Log("Rolled: " + hit + " from chance: " + hitChance + " from: " + move.BaseHitChance + " + " + currentCharacter.getStat(move.HitIncreaseModifier) + " - " + target.getStat(move.HitDecreaseModifier));

            if (actionController.calculateHit(currentCharacter, target, move))
            //if (hit <= hitChance)
            {
                squadView.HitAnimation(targetSquad, target);
                actionController.calculateEffect(target, move);
                if (target.CurrentHealth <= 0)
                {
                    target.CurrentState = CharacterState.DOWN;
                    actionController.RemoveCharacterFromTurnList(target);
                }
            }
            else
            {
                squadView.MissAnimation(targetSquad, target);
            }
        }

        //Debug.Log(actionController.setTargets(move.Shape, targetSquad, destination).Count);

        actionController.NextTurn();
    }

    void CreatePlayerSquad(Squad squad)
    {
        Character newChar;
        #region create characters
        for (int i = 0; i < 6; i++)
        {
            //Create a new character with some random base stats
            newChar = new Character();

            newChar.Side = (squad == squadView.PlayerSquad) ? TrialByFire.SquadSide.LEFT : TrialByFire.SquadSide.RIGHT;
            newChar.CurrentState = CharacterState.ALIVE;

            newChar.setBaseStat(TrialByFire.CharacterStats.ACCURACY, Random.Range(40, 70));
            newChar.setBaseStat(TrialByFire.CharacterStats.ARMOUR, Random.Range(20, 50));
            newChar.setBaseStat(TrialByFire.CharacterStats.CHANNELLING, Random.Range(40, 70));
            newChar.setBaseStat(TrialByFire.CharacterStats.HEALTH, 100);
            newChar.setBaseStat(TrialByFire.CharacterStats.SPEED, Random.Range(20, 70));
            newChar.setBaseStat(TrialByFire.CharacterStats.STRENGTH, Random.Range(40, 70));
            newChar.setBaseStat(TrialByFire.CharacterStats.SYNC, Random.Range(20, 70));

            //Random name
            int num1 = Random.Range(0, 26);
            int num2 = Random.Range(0, 26);
            int num3 = Random.Range(0, 26);
            char let1 = (char)('a' + num1);
            char let2 = (char)('a' + num2);
            char let3 = (char)('a' + num3);
            newChar.Name = let1.ToString() + let2.ToString() + let3.ToString();
            //Random moves
            for (int j = 0; j < 6; j++)
            {
                newChar.setMove(MoveFactory.generateMove((TrialByFire.MoveList)Random.Range(0, 9)), j);
            }

            squad.setCharacterAtPosition
                (newChar, (TrialByFire.SquadPosition)i);
            actionController.AddCharactersToTurnList(newChar);
        }
        #endregion
    }
}
