using TrialByFire;

public class Character
{
    private string name;
    private string className;
    private int currentExperience;
    private int currentLevel;
    private CharacterState currentState;
    private int maxHealth;
    private int maxChannelling;
    private int baseSpeed;
    private int baseStrength;
    private int baseArmour;
    private int baseAccuracy;
    private int baseSync;
    private int currentHealth;
    private int currentChannelling;
    private int currentSpeed;
    private int currentStrength;
    private int currentArmour;
    private int currentAccuracy;
    private int currentSync;
    private Move[] moves;
    private Move[] modifiers;

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

    public string ClassName
    {
        get
        {
            return className;
        }

        set
        {
            className = value;
        }
    }

    public int CurrentExperience
    {
        get
        {
            return currentExperience;
        }

        set
        {
            currentExperience = value;
        }
    }

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
        }
    }

    public int getStat(CharacterStats stat)
    {
        switch (stat)
        {
            case CharacterStats.ACCURACY:
                return CurrentAccuracy;
            case CharacterStats.ARMOUR:
                return CurrentArmour;
            case CharacterStats.SPEED:
                return CurrentSpeed;
            case CharacterStats.STRENGTH:
                return CurrentStrength;
            case CharacterStats.SYNC:
                return CurrentSync;
            default:
                return -1;
        }
    }

    public void setStat(CharacterStats stat, int value)
    {
        //TODO: implement;
    }

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }

        set
        {
            maxHealth = value;
        }
    }

    public int MaxChannelling
    {
        get
        {
            return maxChannelling;
        }

        set
        {
            maxChannelling = value;
        }
    }

    public int BaseSpeed
    {
        get
        {
            return baseSpeed;
        }

        set
        {
            baseSpeed = value;
        }
    }

    public int BaseStrength
    {
        get
        {
            return baseStrength;
        }

        set
        {
            baseStrength = value;
        }
    }

    public int BaseArmour
    {
        get
        {
            return baseArmour;
        }

        set
        {
            baseArmour = value;
        }
    }

    public int BaseAccuracy
    {
        get
        {
            return baseAccuracy;
        }

        set
        {
            baseAccuracy = value;
        }
    }

    public int BaseSync
    {
        get
        {
            return baseSync;
        }

        set
        {
            baseSync = value;
        }
    }

    public int CurrentSpeed
    {
        get
        {
            return currentSpeed;
        }

        set
        {
            currentSpeed = value;
        }
    }

    public int CurrentStrength
    {
        get
        {
            return currentStrength;
        }

        set
        {
            currentStrength = value;
        }
    }

    public int CurrentArmour
    {
        get
        {
            return currentArmour;
        }

        set
        {
            currentArmour = value;
        }
    }

    public int CurrentAccuracy
    {
        get
        {
            return currentAccuracy;
        }

        set
        {
            currentAccuracy = value;
        }
    }

    public int CurrentSync
    {
        get
        {
            return currentSync;
        }

        set
        {
            currentSync = value;
        }
    }

    public int CurrentHealth
    {
        get
        {
            return currentHealth;
        }

        set
        {
            currentHealth = value;
        }
    }

    public int CurrentChannelling
    {
        get
        {
            return currentChannelling;
        }

        set
        {
            currentChannelling = value;
        }
    }

    public CharacterState CurrentState
    {
        get
        {
            return currentState;
        }

        set
        {
            currentState = value;
        }
    }
}