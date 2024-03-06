public class JellyBlue : Jelly
{
    protected override string Name => "Blue";

    protected override void Start()
    {
        base.Start();

        _mediator.JellyBlueChoiced += BlockIsChoice;
    }

    protected override void OnDestroy()
    {
        _mediator.JellyBlueChoiced -= BlockIsChoice;
    }
}