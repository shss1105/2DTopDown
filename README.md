# 유니티 심화과정 프로젝트(19조 김승현)

## 👨‍🏫 프로젝트 소개
- 프로젝트 소개 : 2D 탑다운 게임의 기능들을 구현
## ⏲️ 개발 기간 
- 2024.02.26 ~ 2024.02.29
  
## 💻 개발환경
- **유니티 버전** : 2022.3.2f
- **커밋 컨벤션 규칙**
![image](https://github.com/sda0503/tengai/assets/43924035/80329813-274b-4957-831b-16188df42a7e)

## 🧡 트러블 슈팅
1.  11, 12웨이브에 적이 스폰되지 않는 문제 [해결]

- GameManager.cs 의 StartNextWave()와 관련이 있을 것이라고 추측함
- 실제로 웨이브는 0에서 시작 -> 텍스트에 +1 을 한 것 실제로 문제가 되는 웨이브는 10, 11웨이브
- currentWaveIndex 가 10이 되면은 waveSpawnPosCount는 2가 되고 waveSpawnCount = 0 으로 초기화가 된다
<br/>문제는 currentWaveIndex 가 3의 배수일 때마다 waveSpawnCount 를 1씩 늘려주는데 <br/>currentWaveIndex가 10,11이면 3의 배수가 아니여서 waveSpawnCount = 0이므로 몬스터가 나오지 않는 것
- 웨이브스폰 카운트를 늘리는 곳의 조건에 10의 배수일 경우를 추가하여 해결

2. 구르기 기능 추가 [미해결]

- 트랜스폼과 마우스가 향하고 있는 방향(벡터)를 구해서 해당 방향으로 트랜스폼을 변화시켜야 겠다고 생각함
- 컨트롤러에 OnRoll을 추가하고 TopDownCharacterController에 OnRollEvent를 추가하여 기능을 구현하려 했으나 어떻게 해야할지 방향을 잡지 못하겠고 시간도 모자를 것 같아서 점멸 기능으로 대체함
