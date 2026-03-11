using System;
using static System.Runtime.InteropServices.JavaScript.JSType;


class Program
{
    static void Main()
    {
        ScoreSystem score = new ScoreSystem();
        AchievementSystem achievement = new AchievementSystem();
        SoundSystem sound = new SoundSystem();

        EventManager.OnGameEvent += sound.HandleEvent;
        EventManager.OnGameEvent += score.HandleEvent;
        EventManager.OnGameEvent += achievement.HandleEvent;
        

        EventManager.TriggerEvent("ScoreChanged", 100);
        EventManager.TriggerEvent("Achievement", "첫번째 적 처치");
        EventManager.TriggerEvent("GameOver");

    }
    
}

