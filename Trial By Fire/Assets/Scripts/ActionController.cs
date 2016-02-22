using TrialByFire;
using System.Collections;

public class ActionController
{
    private Squad[] teams;
    private Character[] characters;
    private Character source;
    private Character[] targets;
    private Move action;

    public Character Source
    {
        get
        {
            return source;
        }

        set
        {
            source = value;
        }
    }

    //TODO: create a setter for destination

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

    public ActionResult execute()
    {
        if (calculateHit())
            return ActionResult.HIT;
        else
            return ActionResult.MISS;
    }

    public bool calculateHit()
    {
        foreach (Character destination in targets)
        {
            int hitChance = action.BaseHitChance + source.getStat(action.HitIncreaseModifier) - destination.getStat(action.HitDecreaseModifier);
            
            //TODO: determine whether the action hit or not and calculate the effect if it did
        }

        return true;
    }

    public void calculateEffect(Character destination)
    {
        int result = action.BaseEffectValue + source.getStat(action.EffectIncreaseModifier) - destination.getStat(action.EffectDecreaseModifier);
        destination.setStat(action.EffectStat, result);
    }
}
