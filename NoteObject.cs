using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class NoteObject : MonoBehaviour
{
    public bool isPressed;
    public KeyCode keyToPress;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    

    


    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))
        {
            if(isPressed)
            {
                gameObject.SetActive(false);  // 버튼을 누르면 버튼이 사라짐 (파괴됨, 활성화 안됨)

                //GameManager.instance.NoteHit();  // 게임매니저에게 지금 노트를 쳤다는걸 넣어줌.  게임매니저에 노트함수를 만들어주어서 노말,굿,퍼펙트를 나누어 사용할것이기에 주석처리하고

                if (Mathf.Abs(transform.position.y) > 0.25)  // 조건을 걸어주어
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();   // 게임매니저내의 노말함수를 호출(인스턴스)
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                    
                    

                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();  // 게임매니저내의 굿함수를 호출(인스턴스)
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    

                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit(); // 게임매니저내의 퍼펙트함수를 호출(인스턴스)
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    

                }



            }
        }
    }

    
    private void OnTriggerEnter2D(Collider2D other) // 노트 들어올 때
    {
        if(other.tag == "Activator")  // 활성화시키면
        {
            isPressed = true;         // 입력가능
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)  // 노트 미스(노트 들어왔다가 나갈 때)
    {
        if(other.tag == "Activator" && isPressed == false)  // 태그하고, 누르지 않은경우
        {
            Debug.Log("지나쳤습니다.");

            GameManager.instance.NoteMissed();  // 놓친것을 게임매니저에게 전달
            Debug.Log("게임매니저 가져옴");
            Instantiate(missEffect, transform.position, missEffect.transform.rotation); // 미스이펙트
            
        }
        else if(other.tag == "Missjudgement") // 그냥 나가는경우
        {
            GameManager.instance.NoteMissed();
            Debug.Log("Die Zone 에 닿았습니다..");
            Instantiate(missEffect, transform.position, missEffect.transform.rotation); // 미스이펙트
        }
        
    }
    

}
