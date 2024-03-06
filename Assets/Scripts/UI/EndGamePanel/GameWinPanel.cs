public class GameWinPanel : EndGamePanel
{
    public override string AnimationName => "Win";

    protected override void OnEnable()
    {
        Victory.LevelFinised += OpenPanel;
    }

    protected override void OnDisable()
    {
        Victory.LevelFinised -= OpenPanel;
    }
}