using TrialByFire;
using System.Collections.Generic;

public class Squad
{
    private string name;
    private List<Character> members;

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

    public void Initialize()
    {
        members = new List<Character>();
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
