using System;
using System.Collections.Generic;
using System.Text;

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