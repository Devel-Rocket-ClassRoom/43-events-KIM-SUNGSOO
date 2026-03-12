using System;
using System.Collections.Generic;
using System.Text;

delegate void Notify();

delegate void EventHandler();

class Button
{
    public event EventHandler Click;

    public void OnClick()
    {
        if (Click != null)
        {
            Click();
        }
    }
}

class Player
{
    public event Action<int> DamageTaken;

    public int _health = 100;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Console.WriteLine($"플레이어 체력: {_health}");
        DamageTaken?.Invoke(_health);
    }
}

class HealthBar
{
    public void OnPlayerDamged(int currentHealth)
    {
        Console.WriteLine($"[UI] 체력바 업데이트: {currentHealth}%");
    }
}

class SoundManager
{
    public void OnPlayerDamged(int currentHealth)
    {
        Console.WriteLine($"[Sound] 피격 효과음 재생");
    }
}


class Timer
{
    public event Action Tick;

    public int _count;
    public void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            _count++;
            Console.WriteLine($"타이머: {_count}초");
            Tick?.Invoke();
        }
    }

    
}

class Logger
{
    public void OnTick()
    {
        Console.WriteLine("[Logger] 틱 기록됨");
    }
}

class Sensor
{
    public event Action<string> Alert;

    public void Detect(string message)
    {
        Console.WriteLine($"감지: {message}");
        Alert?.Invoke(message);
    }
}

class GameCharacter
{
    public event Action OnDeath;
    public event Action<int> OnDamaged;
    public event Action<int, string> OnAttack;

    private int _health = 100;
    private string _name;

    public GameCharacter(string name)
    {
        _name = name;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnDamaged?.Invoke(_health);

        if (_health <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    public void Attack(int damage, string targetName)
    {
        OnAttack?.Invoke(damage, targetName);
    }
}

class FuelEventArgs : EventArgs
{
    public int FuelLevel { get; }
    public string Warning { get; }

    public FuelEventArgs(int fuelLevel, string warning)
    {
        FuelLevel = fuelLevel;
        Warning = warning;
    }
}

class Car
{
    private int _fuelLevel;

    public event EventHandler<FuelEventArgs> FuelLow;
    public event Action<int> FuelChanged;

    public Car(int initialFuel)
    {
        _fuelLevel = initialFuel;
    }

    public int FuelLevel => _fuelLevel;

    public void Drive()
    {
        if (_fuelLevel <= 0)
        {
            Console.WriteLine("연료 없음! 운전 불가");
            return;
        }

        _fuelLevel -= 10;
        Console.WriteLine($"운전 중... 연료: {_fuelLevel}%");

        FuelChanged?.Invoke(_fuelLevel);

        if (_fuelLevel <= 0)
        {
            OnFuelLow(new FuelEventArgs(_fuelLevel, "연료가 바닥났습니다!"));
        }
        else if (_fuelLevel <= 20)
        {
            OnFuelLow(new FuelEventArgs(_fuelLevel, "연료가 부족합니다"));
        }
    }

    protected virtual void OnFuelLow(FuelEventArgs e)
    {
        FuelLow?.Invoke(this, e);
    }
}

class Dashboard
{
    public void Subscribe(Car car)
    {
        car.FuelChanged += OnFuelChanged;
        car.FuelLow += OnFuelLow;
    }

    public void Unsubscribe(Car car)
    {
        car.FuelChanged -= OnFuelChanged;
        car.FuelLow -= OnFuelLow;
    }

    private void OnFuelChanged(int fuelLevel)
    {
        string gauge = new string('█', fuelLevel / 10);
        Console.WriteLine($"[대시보드] 연료 게이지: {gauge}");
    }

    private void OnFuelLow(object sender, FuelEventArgs e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[경고!] {e.Warning} (잔량: {e.FuelLevel}%)");
        Console.ResetColor();
    }
}

