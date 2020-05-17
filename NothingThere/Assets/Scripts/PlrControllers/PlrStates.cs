public class PlrStates
{
    public enum StatesForMove
    {
        onGround,
        inAir
    }

    public enum PerspectiveStates
    {
        firstPerson,
        TopDawn,
        Perspective,
        Platformer
    }

    public StatesForMove stateForMove = new StatesForMove();
    public PerspectiveStates perspectiveState = new PerspectiveStates();
}
