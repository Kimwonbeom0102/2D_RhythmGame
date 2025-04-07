using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{ 
    private SpriteRenderer theSR;    // 스프라이트
    public Sprite defaultImage;      // 기본이미지
    public Sprite pressedImage;      // 눌렀을 때 이미지

    public KeyCode keyToPress;       // 키입력

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();  // 유니티 내 스프라이트 가져옴
    }

    void Update()
    {
        if(Input.GetKeyDown(keyToPress))   // 키 누르면
        {
            theSR.sprite = pressedImage;   // 변경된 이미지
        }
        if(Input.GetKeyUp(keyToPress))  
        {  
            theSR.sprite = defaultImage;   // 기본 이미지
        }
        
    }
}
