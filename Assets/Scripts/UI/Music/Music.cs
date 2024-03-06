public class Music
{
    private IPersistentData _persistentData;

    public Music(IPersistentData persistentData) => _persistentData = persistentData;

    public int GetCurrentMusicStatus() => _persistentData.PlayerData.PauseMusicStatus;
    public int GetCurrentSFXStatus() => _persistentData.PlayerData.PauseSFXStatus;
    public int GetCurrentSoundLength() => _persistentData.PlayerData.SoundLength;

    public void SetPauseMusicStatus(int pause)
    {
        _persistentData.PlayerData.PauseMusicStatus = pause;
    }

    public void SetPauseSFXStatus(int pause)
    {
        _persistentData.PlayerData.PauseSFXStatus = pause;
    }

    public void SetSoundLength(int length)
    {
        _persistentData.PlayerData.SoundLength = length;
    }
}