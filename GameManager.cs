using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour  
{
    public AudioSource theMusic;  // 음악소스

    public bool startPlaying;     // 게임스타트

    public NoteHolderManager theNH;  //  노트홀더

    public static GameManager instance;  // 인스턴스 생성

    public int currentScore;   // 현재점수 퍼블릭으로 넣어주어서 스코어를 볼 수 있음

    public int scorePerNote = 100;  //  한 노트당 100점으로 계산하여 노트를 칠때마다 NoteHit 함수에 스코어를 저장하여 현재 스코어가 나오게함.  Normal 히트 스코어
    public int scorePerGoodNote = 125;   // Good 히트 스코어
    public int scorePerPerfectNote = 150;  // Perfect 히트 스코어

    public int currentMultiplier;    // 현재 X
    public int multiplierTracker;    // 누적 
    public int[] multiplierThresholds;  

    public Text scoreText;
    public Text multiText;
    

    public float totalNotes;
    public float normalHits;
    public float goodHits;
    public float perfectHits;
    public float missedHIts;

    public GameObject resultsScreen;
    public Text percentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;

    void Start()
    {
        instance = this;  // 싱글턴 

        scoreText.text = "Score: 0";  
        currentMultiplier = 1;  // 1로 고정

        totalNotes = FindObjectsOfType<NoteObject>().Length; // 총 노트
    }

    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown) // 시작할때 키입력
            {
                startPlaying = true;  // 실행
                theNH.hasStarted = true;  

                theMusic.Play();
            }
        }
        else
        {
            if(!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);  //  스크린제거

                normalsText.text = "" + normalHits;
                goodsText.text = goodHits.ToString();
                percentHitText.text = perfectHits.ToString();
                missesText.text = "" + missedHIts;

                float totalHit = normalHits + goodHits + perfectHits; // 총 Hit
                float percentHit = (totalHit / totalNotes) * 100f;   // 백분율로 퍼센티지 구함

                percentHitText.text = percentHit.ToString("F1") + "%"; // 백분율 담고 %

                string rank = "F";  // 기본 랭크 F

                if(percentHit > 50)  
                {
                    rank = "D";
                    if(percentHit > 60)
                    {
                        rank = "C";
                        if(percentHit > 80)
                        {
                            rank = "B";
                            if(percentHit > 90)
                            {
                                rank = "A";
                                if(percentHit > 95)  // 순차적으로 D~S 랭크
                                {
                                    rank = "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rank;
                finalScoreText.text = currentScore.ToString();   
            }
        }
    }

    public void NoteHit()
    {
        //Debug.Log("Hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {

            multiplierTracker++;  // 트래커로 배수의 수를 올려줌

            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;  // 배수는 초기화
                currentMultiplier++;
            }

        }

        multiText.text = "Multiplier: x " + currentMultiplier;
        
        //currentScore += scorePerNote * currentMultiplier;   //  노트 하나당 점수를 더해주어 현재 점수에 저장
        scoreText.text = "Score: " + currentScore;
          
    }

    public void NormalHit()
    {  
        currentScore += scorePerNote * currentMultiplier;  // 현재 배수 x 노트 
        NoteHit();

        normalHits++;
    }
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;  // 현재 배수 x good노트 
        NoteHit();
        goodHits++;
    }
    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;  // 현재 배수  x per노트
        NoteHit();
        perfectHits++;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");

        currentMultiplier = 1;  // 초기화
        multiplierTracker = 0;  // 초기화

        multiText.text = "Multiplier: x " + currentMultiplier;
        missedHIts++;
    }
}
