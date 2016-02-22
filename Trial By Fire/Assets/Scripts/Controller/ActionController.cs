using System;
using System.Collections.Generic;

public class ActionController
{
    private Squad[] teams;
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

    //TODO: create a setter for targets

    public void NextTurn()
    {
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

    public Squad[] Teams
    {
        get
        {
            return teams;
        }

        set
        {
            teams = value;
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
        int result = action.BaseEffectValue + source.getStat(action.EffectIncreaseModifier) - destination.getStat(action.EffectDecreaseModifier);
        destination.setStat(action.EffectStat, result);
    }

    public void calculateEffect(Character destination, Move move)
    {
        //TODO: Implement.  Do moves need a reference to their source?  It may make some things neater, and it will be essential if modifier effects are variable based on character stats.
    }
}
