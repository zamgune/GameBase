public static class SceneConfigs
{
    public enum eSceneName
    {
        Splash,
        Loading,
        Lobby,
    }

    public enum eLobbyScenePage
    {
        None,
        Garage,
        Rune,
        Battle,
        Support,
        Shop,
        MAX
    }

    public enum eBattleSceneState
    {
        None,
        Ready,
        GameStart,
        WaveStart,
        WavePlaying,
        WaveEnd,
        ChoiceAbility,
        GameEnd,
        MAX
    }
}
