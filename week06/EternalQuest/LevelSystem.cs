// CREATIVITY: Level up system
public class LevelSystem
{
    private int[] _thresholds = { 0, 100, 300, 600, 1000, 1500, 2100, 2800, 3600, 4500 };

    public int GetLevel(int score)
    {
        for (int i = _thresholds.Length - 1; i >= 0; i--)
        {
            if (score >= _thresholds[i]) return i + 1;
        }
        return 1;
    }

    public bool LevelUpOccurred(int oldScore, int newScore)
    {
        return GetLevel(newScore) > GetLevel(oldScore);
    }

    public string GetLevelName(int level)
    {
        string[] names = { "Beginner", "Seeker", "Adventurer", "Achiever", "Hero", "Champion", "Master", "Legend", "Mythic", "Eternal" };
        return level <= names.Length ? names[level - 1] : "Eternal";
    }
}