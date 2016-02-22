using TrialByFire;

public class Squad
{
    private string name;
    private Character[] members;

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

    public Character getCharacterAtPosition(SquadPosition pos)
    {
        return members[(int) pos];
    }

    public void setCharacterAtPosition(Character character, SquadPosition pos)
    {
        members[(int)pos] = character;
    }
}
