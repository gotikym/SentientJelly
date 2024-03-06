public class JellyRed : Jelly 
{
    protected override string Name => "Red";

    protected override void Start()
    {
        base.Start();

        _mediator.JellyRedChoiced += BlockIsChoice;
    }

    protected override void OnDestroy()
    {
        _mediator.JellyRedChoiced -= BlockIsChoice;
    }
}