using System;

class Program
{
    static void Main()
    {
        ChatRoom chat = new ChatRoom();
        ChatLogger logger = new ChatLogger();
        NotificationService notifi = new NotificationService();

        chat.MessageReceived += logger.SendMessage;
        chat.MessageReceived += notifi.SendMessage;

        chat.SendMessage("철수", "안녕하세요");
        chat.SendMessage("영희", "긴급 회의가 있습니다");
        chat.SendMessage("민수", "점심 뭐 먹을까요?");


    }
}
