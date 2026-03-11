# 이벤트 매니저 시스템

게임에서 사용할 수 있는 범용 이벤트 매니저 시스템을 구현하세요.

**요구사항**

- `GameEventArgs` 클래스 (EventArgs 상속)
  - `EventName` 속성: 이벤트 이름 (string)
  - `Data` 속성: 추가 데이터 (object)

- `EventManager` 클래스 (static)
  - `OnGameEvent` 이벤트: EventHandler\<GameEventArgs\> 타입
  - `TriggerEvent(string eventName, object data = null)` 메서드

- `ScoreSystem` 클래스 (구독자)
  - "ScoreChanged" 이벤트 수신 시 "점수 변경: {data}점" 출력

- `AchievementSystem` 클래스 (구독자)
  - "Achievement" 이벤트 수신 시 "업적 달성: {data}" 출력

- `SoundSystem` 클래스 (구독자)
  - 모든 이벤트 수신 시 "[Sound] 이벤트: {eventName}" 출력

**테스트 시나리오**

1. 세 시스템 인스턴스 생성 및 이벤트 구독
2. "ScoreChanged" 이벤트 발생 (data: 100)
3. "Achievement" 이벤트 발생 (data: "첫 번째 적 처치")
4. "GameOver" 이벤트 발생 (data: null)

## 예상 실행 결과

```
[Sound] 이벤트: ScoreChanged
점수 변경: 100점
[Sound] 이벤트: Achievement
업적 달성: 첫 번째 적 처치
[Sound] 이벤트: GameOver
```
