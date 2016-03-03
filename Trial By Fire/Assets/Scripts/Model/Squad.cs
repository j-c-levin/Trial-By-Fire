using TrialByFire;

public class Squad
{
    private string name;
    private Character[][] members;

    public Squad()
    {
        Initialize();
    }

    public void Initialize()
    {
        members = new Character[4][];
        for (int i = 0; i < 3; i++)
        {
            members[i] = new Character[2];
        }
        members[3] = new Character[1];
    }

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

    public Character getCharacterAtPosition(SquadPosition position)
    {
        switch (position)
        {
            case SquadPosition.FRONT_LEFT:
                return members[0][0];
            case SquadPosition.FRONT_MIDDLE:
                return members[1][0];
            case SquadPosition.FRONT_RIGHT:
                return members[2][0];
            case SquadPosition.BACK_LEFT:
                return members[0][1];
            case SquadPosition.BACK_MIDDLE:
                return members[1][1];
            case SquadPosition.BACK_RIGHT:
                return members[2][1];
            case SquadPosition.UTILITY:
                return members[3][0];
            case SquadPosition.NONE:
                return null;
            default:
                return null;
        }
    }

    public SquadPosition getCharacterBehindPosition(SquadPosition position)
    {
        switch (position)
        {
            case SquadPosition.FRONT_LEFT:
                return SquadPosition.BACK_LEFT;
            case SquadPosition.FRONT_MIDDLE:
                return SquadPosition.BACK_MIDDLE;
            case SquadPosition.FRONT_RIGHT:
                return SquadPosition.BACK_RIGHT;
            case SquadPosition.BACK_LEFT:
                return SquadPosition.FRONT_LEFT;
            case SquadPosition.BACK_MIDDLE:
                return SquadPosition.FRONT_MIDDLE;
            case SquadPosition.BACK_RIGHT:
                return SquadPosition.FRONT_RIGHT;
            case SquadPosition.UTILITY:
                return SquadPosition.NONE;
            default:
                return SquadPosition.NONE;
        }
    }

    public SquadPosition
        getCharacterNextToPosition(SquadPosition position)
    {
        switch (position)
        {
            case SquadPosition.FRONT_LEFT:
                return SquadPosition.UTILITY;
            case SquadPosition.FRONT_MIDDLE:
                return SquadPosition.FRONT_LEFT;
            case SquadPosition.FRONT_RIGHT:
                return SquadPosition.FRONT_MIDDLE;
            case SquadPosition.BACK_LEFT:
                return SquadPosition.NONE;
            case SquadPosition.BACK_MIDDLE:
                return SquadPosition.BACK_LEFT;
            case SquadPosition.BACK_RIGHT:
                return SquadPosition.BACK_MIDDLE;
            case SquadPosition.UTILITY:
                return SquadPosition.NONE;
            default:
                return SquadPosition.NONE;
        }
    }

    public void setCharacterAtPosition(Character character, SquadPosition position)
    {
        switch (position)
        {
            case SquadPosition.FRONT_LEFT:
                members[0][0] = character;
                break;
            case SquadPosition.FRONT_MIDDLE:
                 members[1][0] = character;
                break;
            case SquadPosition.FRONT_RIGHT:
                 members[2][0] = character;
                break;
            case SquadPosition.BACK_LEFT:
                 members[0][1] = character;
                break;
            case SquadPosition.BACK_MIDDLE:
                 members[1][1] = character;
                break;
            case SquadPosition.BACK_RIGHT:
                 members[2][1] = character;
                break;
            case SquadPosition.UTILITY:
                 members[3][0] = character;
                break;
            case SquadPosition.NONE:
                break;
            default:
                break;
        }
    }
}
