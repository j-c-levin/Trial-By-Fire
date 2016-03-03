using System;
using System.Collections.Generic;
using TrialByFire;

public class ActionController
{
    private List<Character> characters;
    private Character source;
    private List<Character> targets;
    private Move action;
    Random random = new Random();

    public void Initialize()
    {
        characters = new List<Character>();
        targets = new List<Character>();
    }

    public void AddCharactersToTurnList(Character[] units)
    {
        foreach (Character c in units)
        {
            c.Initialize();
            characters.Add(c);
        }
    }

    public void Begin()
    {
        NextTurn();
    }

    public void NextTurn()
    {
        //Reset the target list
        targets.RemoveRange(0, targets.Count);

        characters.Sort((a, b) => a.TurnSpeed.CompareTo(b.TurnSpeed));
        source = characters[0];
        source.activeTurn();
    }

    public Move Action
    {
        get
        {
            return action;
        }

        set
        {
            action = value;
        }
    }

    public void execute()
    {
        foreach (Character destination in targets)
        {
            if (calculateHit(destination))
            {
                calculateEffect(destination);
            }
        }
    }

    public bool calculateHit(Character destination)
    {
        int hitChance = action.BaseHitChance + source.getStat(action.HitIncreaseModifier) - destination.getStat(action.HitDecreaseModifier);

        return hitChance > random.Next(0, 101);
    }

    public void calculateEffect(Character destination)
    {
        int result = action.BaseEffectValue;

        destination.setStat(action.EffectStat, result);
    }

    public void calculateEffect(Character destination, Modifier modifier)
    {
        int result = modifier.Move.BaseEffectValue;

        destination.setStat(modifier.Move.EffectStat, result);
    }

    public void setTargets(AoE area, Squad squad, SquadPosition target)
    {
        switch (area)
        {
            case AoE.SINGLE:
                targets.Add(squad.getCharacterAtPosition(target));
                break;

            case AoE.SINGLE_PIERCING:
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

            case AoE.DOUBLE_PIERCING:
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

            case AoE.TRIPLE_PIERCING:
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
    }
}
