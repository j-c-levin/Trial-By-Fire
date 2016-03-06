using System;
using System.Collections.Generic;
using TrialByFire;

public class ActionController
{
    private List<Character> characters;
    private Character source;
    Random random;

    public delegate void ActiveCharacter(Character activeCharacter);
    public ActiveCharacter activeCharacter;

    public ActionController()
    {
        Initialize();
    }

    public void Initialize()
    {
        characters = new List<Character>();
        random = new Random();
    }

    public void AddCharactersToTurnList(Character character)
    {
        characters.Add(character);
    }

    public void RemoveCharacterFromTurnList(Character character)
    {
        for (int i = 0; i < characters.Count; i++)
        {
            if (characters[i] == character)
            {
                characters.RemoveAt(i);
                break;
            }
        }
    }

    public void Begin()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        characters.Sort((a, b) => a.TurnSpeed.CompareTo(b.TurnSpeed));
        source = characters[0];
        activeCharacter(source);
    }

    public bool calculateHit(Character source, Character destination, Move action)
    {
        int hitChance = action.BaseHitChance + source.getStat(action.HitIncreaseModifier) - destination.getStat(action.HitDecreaseModifier);

        return hitChance > random.Next(0, 101);
    }

    public void calculateEffect(Character destination, Move action)
    {
        int result = action.BaseEffectValue;

        destination.setStat(action.EffectStat, result);
    }

    public void calculateEffect(Character destination, Modifier modifier)
    {
        int result = modifier.Move.BaseEffectValue;

        destination.setStat(modifier.Move.EffectStat, result);
    }

    public List<Character> setTargets(AoE area, Squad squad, SquadPosition target)
    {
        List<Character> targets = new List<Character>();
        switch (area)
        {
            case AoE.SINGLE:
                targets.Add(squad.getCharacterAtPosition(target));
                break;

            case AoE.SINGLE_PENETRATING:
                targets.Add(
                    squad.getCharacterAtPosition(target)
                    );

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterBehindPosition(target)
                        ));
                break;
            case AoE.DOUBLE:
                targets.Add(
                    squad.getCharacterAtPosition(target)
                    );

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterNextToPosition(target)
                        ));
                break;

            case AoE.DOUBLE_PENETRATING:
                targets.Add(
                    squad.getCharacterAtPosition(target)
                    );

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterBehindPosition(target)
                        ));

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterNextToPosition(target)
                        ));

                targets.Add(
                    squad.getCharacterAtPosition(
                    squad.getCharacterBehindPosition(
                        squad.getCharacterNextToPosition(target)
                        )));
                break;

            case AoE.TRIPLE:
                targets.Add(
                    squad.getCharacterAtPosition(target)
                    );

                targets.Add(
                    squad.getCharacterAtPosition(
                    squad.getCharacterNextToPosition(target)
                    ));

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterNextToPosition(
                            squad.getCharacterNextToPosition(target)
                            )));
                break;

            case AoE.TRIPLE_PENETRATING:
                targets.Add(
                    squad.getCharacterAtPosition(target)
                    );

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterBehindPosition(target)
                        ));

                targets.Add(
                    squad.getCharacterAtPosition(
                    squad.getCharacterNextToPosition(target)
                    ));

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterBehindPosition(
                            squad.getCharacterNextToPosition(target)
                            )));

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterNextToPosition(
                            squad.getCharacterNextToPosition(target)
                            )));

                targets.Add(
                    squad.getCharacterAtPosition(
                        squad.getCharacterBehindPosition(
                            squad.getCharacterNextToPosition(
                                squad.getCharacterNextToPosition(target
                                )))));
                break;

            case AoE.ALL:
                targets.Add(squad.getCharacterAtPosition(SquadPosition.FRONT_LEFT));
                targets.Add(squad.getCharacterAtPosition(SquadPosition.FRONT_MIDDLE));
                targets.Add(squad.getCharacterAtPosition(SquadPosition.FRONT_RIGHT));
                targets.Add(squad.getCharacterAtPosition(SquadPosition.BACK_LEFT));
                targets.Add(squad.getCharacterAtPosition(SquadPosition.BACK_MIDDLE));
                targets.Add(squad.getCharacterAtPosition(SquadPosition.BACK_RIGHT));
                targets.Add(squad.getCharacterAtPosition(SquadPosition.UTILITY));
                break;
            default:
                break;
        }
        return targets;
    }
}
