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
class GameEventArgs : EventArgs
{
    public string EventName { get; set; }
    public object Data { get; set; }

    public GameEventArgs(string eventName, object data)
    {
        EventName = eventName;
        Data = data;
    }
}

static class EventManager
{
    public static event EventHandler<GameEventArgs> OnGameEvent;

    public static void TriggerEvent(string eventName, object data = null)
    {
        GameEventArgs args = new GameEventArgs(eventName, data);
        OnGameEvent?.Invoke(null, args);
    }
   
}
class SoundSystem
{
    public void HandleEvent(object sender, GameEventArgs e)
    {
        Console.WriteLine($"[Sound] 이벤트: {e.EventName}");
    }
}

class ScoreSystem
{
    public void HandleEvent(object sender, GameEventArgs e)
    {
        if (e.EventName == "ScoreChanged")
        {
            Console.WriteLine($"점수 변경: {e.Data}점");
        }
    }
}

class AchievementSystem
{
    public void HandleEvent(object sender, GameEventArgs e)
    {
        if (e.EventName == "Achievement")
        {
            Console.WriteLine($"업적 달성: {e.Data}");
        }
    }
}
