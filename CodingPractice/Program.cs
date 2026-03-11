using System;
using System.Net.Http;

class CodPrac
{
    static void Main()
    {
        //Prac_1();
        //Prac_2();
        //Prac_3();
        //Prac_4();
        //Prac_5();
        Prac_6();
        Prac_7();
        Prac_8();
        Prac_9();
        Prac_10();
    }


    static void Prac_1()
    {
        Notify notify = SayHello;
        notify += SayGoodbye;

        notify();

        //notify -= SayGoodbye;

        static void SayHello()
        {
            Console.WriteLine("안녕하세요!");
        }

        static void SayGoodbye()
        {
            Console.WriteLine("안녕히 가세요!");
        }
    }
    static void Prac_2() 
    {
        Button button = new Button();
        button.Click += HandleClick;
        button.Click += HandleClickAgain;

        button.OnClick();

        //button.Click -= HandleClick;  
        //button.Click -= HandleClickAgain;
        static void HandleClick()
        {
            Console.WriteLine("버튼이 클릭되었습니다!");
        }

        static void HandleClickAgain()
        {
            Console.WriteLine("클릭 처리 완료");
        }
    }
    static void Prac_3() 
    {
        Player player = new Player();
        HealthBar healthBar = new HealthBar();
        SoundManager soundManager = new SoundManager();

        player.DamageTaken += healthBar.OnPlayerDamged;
        player.DamageTaken += soundManager.OnPlayerDamged;

        player.TakeDamage(30);
        
    }
    static void Prac_4() 
    {
        Timer timer = new Timer();
        Logger logger = new Logger();

        timer.Tick += logger.OnTick;
        Console.WriteLine("=== 구독 상태 ===");
        timer.Start();

        timer.Tick -= logger.OnTick;
        Console.WriteLine("=== 구독 해제 후 ===");
        timer.Start();
    }
    static void Prac_5() 
    {
        Sensor sensor = new Sensor();
        sensor.Alert += message =>
        {
            Console.WriteLine($"[경보] {message}");
        };
        sensor.Alert += message =>
        {
            Console.WriteLine($"[로그] {DateTime.Now}: {message}");
        };

        sensor.Detect("움직임 감지됨");
        sensor.Detect("온도 상승");
    }
    static void Prac_6() 
    {
        GameCharacter hero = new GameCharacter("용사");

        hero.OnDeath += () => Console.WriteLine("캐릭터가 사망했습니다");

        hero.OnDamaged += health => Console.WriteLine($"남은 체력: {health}");

        hero.OnAttack += (damage, target) => Console.WriteLine($"{target}에게 {damage} 데미지!");

        hero.Attack(50, "슬라임");
        hero.TakeDamage(30);
        hero.TakeDamage(80);
    }
    static void Prac_7() 
    {
        Car car = new Car(50);
        Dashboard dashboard = new Dashboard();

        dashboard.Subscribe(car);
        for (int i = 0; i < 7; i++)
        {
            car.Drive();
            Console.WriteLine();
        }

        dashboard.Unsubscribe(car);

    }
    static void Prac_8() 
    {
    
    }
    static void Prac_9() 
    {
    
    }
    static void Prac_10() 
    {
    
    }


}
