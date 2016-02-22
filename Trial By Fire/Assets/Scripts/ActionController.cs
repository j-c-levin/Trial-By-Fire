using TrialByFire;

public class ActionController
{
    private Character[] characters;
    private Character source;
    private SquadPosition destination;
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

    public SquadPosition Destination
    {
        get
        {
            return destination;
        }

        set
        {
            destination = value;
        }
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

    public bool calculateHit()
    {
        return true;
    }

    public void calculateEffect()
    {

    }
}
