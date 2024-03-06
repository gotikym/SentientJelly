public class TimeOverPanel : EndGamePanel
{
    public override string AnimationName => "TimeOver";

    protected override void OnEnable()
    {
        _timer.TimeIsUp += OpenPanel;
    }

    protected override void OnDisable()
    {
        _timer.TimeIsUp -= OpenPanel;
    }
}