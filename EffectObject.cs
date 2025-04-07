using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour  // 이펙트에 할당
{
    public float deletetime = 1f;
    void Start()
    {
        
    }

    
    void Update()
    {
        Destroy(gameObject, deletetime);  // 1초뒤 이펙트 제거
    }
}
