# 채팅방 메시지 시스템

채팅방에서 메시지를 보내면 구독자들이 각자의 방식으로 처리하는 시스템을 구현하세요.

**요구사항**

1. `ChatRoom` 클래스
   - `event Action<string, string> MessageReceived` 이벤트 선언 (매개변수: 발신자, 메시지)
   - `SendMessage(string sender, string message)` 메서드: 메시지 전송 시 이벤트 발생

2. `ChatLogger` 클래스 (구독자)
   - 모든 메시지를 "[로그] {sender}: {message}" 형식으로 출력

3. `NotificationService` 클래스 (구독자)
   - 메시지에 "긴급" 키워드가 포함된 경우에만 "[알림] 긴급 메시지 수신!" 출력

4. Main에서 테스트
   - `ChatRoom`, `ChatLogger`, `NotificationService` 인스턴스 생성
   - 이벤트 구독 후 메시지 3건 전송

## 예상 실행 결과

```
[로그] 철수: 안녕하세요
[로그] 영희: 긴급 회의가 있습니다
[알림] 긴급 메시지 수신!
[로그] 민수: 점심 뭐 먹을까요?
```
