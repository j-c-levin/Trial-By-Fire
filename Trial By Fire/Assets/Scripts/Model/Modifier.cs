public class Modifier
{
    private Move move;
    private Character source;

    public Modifier(Move move, Character source)
    {
        this.move = move;
        this.source = source;
    }

    public Move Move
    {
        get
        {
            return move;
        }

        set
        {
            move = value;
        }
    }

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
}
