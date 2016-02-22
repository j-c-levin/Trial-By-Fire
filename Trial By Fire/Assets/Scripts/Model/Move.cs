using TrialByFire;

public class Move
{
    private string name;
    private int duration;
    private AoE shape;
    private int baseHitChance;
    private CharacterStats hitIncreaseModifier;
    private CharacterStats hitDecreaseModifier;
    private CharacterStats effectStat;
    private int baseEffectValue;
    private CharacterStats effectIncreaseModifier;
    private CharacterStats effectDecreaseModifier;

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Duration
    {
        get
        {
            return duration;
        }

        set
        {
            duration = value;
        }
    }

    public AoE Shape
    {
        get
        {
            return shape;
        }

        set
        {
            shape = value;
        }
    }

    public int BaseHitChance
    {
        get
        {
            return baseHitChance;
        }

        set
        {
            baseHitChance = value;
        }
    }

    public CharacterStats HitIncreaseModifier
    {
        get
        {
            return hitIncreaseModifier;
        }

        set
        {
            hitIncreaseModifier = value;
        }
    }

    public CharacterStats HitDecreaseModifier
    {
        get
        {
            return hitDecreaseModifier;
        }

        set
        {
            hitDecreaseModifier = value;
        }
    }

    public int BaseEffectValue
    {
        get
        {
            return baseEffectValue;
        }

        set
        {
            baseEffectValue = value;
        }
    }

    public CharacterStats EffectIncreaseModifier
    {
        get
        {
            return effectIncreaseModifier;
        }

        set
        {
            effectIncreaseModifier = value;
        }
    }

    public CharacterStats EffectDecreaseModifier
    {
        get
        {
            return effectDecreaseModifier;
        }

        set
        {
            effectDecreaseModifier = value;
        }
    }

    public CharacterStats EffectStat
    {
        get
        {
            return effectStat;
        }

        set
        {
            effectStat = value;
        }
    }
}
