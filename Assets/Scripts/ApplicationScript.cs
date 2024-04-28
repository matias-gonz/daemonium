public static class ApplicationScript
{
    public enum GamemodeEnum
    {
        SinglePlayer,
        MultiPlayer
    }
    
    public enum CharacterEnum
    {
        Circe,
        Morgana
    }
    
    public static GamemodeEnum Gamemode { get; set; }
    public static CharacterEnum Character { get; set; }
    
}