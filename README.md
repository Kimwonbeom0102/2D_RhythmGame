#  리듬게임 데모 (Unity 2D)

음악에 맞춰 떨어지는 노트를 타이밍에 맞게 눌러 점수를 얻는 **간단한 리듬게임 데모**입니다.  
Unity의 기본적인 기능을 활용해 제작한 **개인 연습 프로젝트**로,  
UI, 노트 판정, 효과 시스템 등을 구현했습니다.  

 [시연 영상 바로 보기](https://youtu.be/FInCm2hxfJc)

---

##  프로젝트 목적 및 회고

- Unity 2D 기능 전반에 대한 이해 및 실습  
- 수업에서 배운 2D 무기 조작, 점프 등을 바탕으로  
  **직접 리듬게임을 기획하고 참고 자료 기반으로 구현**  
- 단순 구현이 아닌, **노트 판정, 이펙트, 점수 시스템 등 게임의 흐름 구성 능력** 키움  
- Prefab, Rigidbody, Collider, Canvas 등 엔진 주요 기능 직접 사용

---

##  주요 기능

###  노트 생성 시스템
- 음악에 맞춰 일정한 간격으로 노트 생성
- `Instantiate()`로 프리팹을 생성하여 스폰 위치에서 떨어지게 처리

###  노트 이동
- `Rigidbody2D`로 자연스러운 중력 이동 처리

###  판정 로직
- `Collider2D`와 위치 계산으로 판정 구간 체크
- 거리에 따라 `Perfect`, `Good`, `Miss`로 구분

###  입력 감지 및 노트 제거
- 키 입력 시 해당 라인 노트 판정 후 `Destroy()`로 제거

###  점수 및 콤보 시스템
- 판정에 따라 점수 차등 부여
- 연속 성공 시 콤보 수치에 따라 배수 점수 적용

###  이펙트 시스템
- 판정 결과에 따른 텍스트 이펙트 출력
- UI Canvas에서 애니메이션 처리

###  UI 및 게임 설정
- Start Scene → Game Scene 전환 구성

---

##  사용한 Unity 기능

| Unity 기능       | 사용 목적                            |
|------------------|---------------------------------------|
| `Rigidbody2D`     | 노트 이동                             |
| `Collider2D`      | 판정 영역 감지                         |
| `Prefab`         | 반복 오브젝트 (노트, 이펙트 등) 관리    |
| `UI Canvas`      | 점수판, 판정 텍스트 출력               |
| `Scene 전환`      | 시작 → 게임 흐름 구성                  |
| `AudioSource`    | 음악 재생 및 타이밍 기준               |

---

##  프로젝트 목적

- Unity 2D 기능 전반에 대한 이해 및 실습
- Prefab, Rigidbody, Collider, Canvas 등 엔진 주요 기능 직접 구현 경험
- 게임 흐름 및 상태 관리 (Scene, 점수 시스템 등) 연습
- 기초 문법 및 구조를 활용한 **C# 실습 경험 축적**

---

## **
이 프로젝트는  **기초 학습용 데모 프로젝트**입니다.  
상업적 목적이나 완성된 게임이 아니며, Unity의 기능을 익히는 데 중점을 두었습니다.

---

