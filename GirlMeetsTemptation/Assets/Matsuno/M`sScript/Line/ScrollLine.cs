using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollLine : MonoBehaviour
{
    [SerializeField] Scrollbar Scroll; // UIに表示するテキスト

    float ScrollValue = 0;
    float Yvalue;

    bool ScrollStop = false;

    private void Update()
    {
        float Yvalue = Input.GetAxisRaw("Vertical");
        Debug.Log("ScrollValue: " + ScrollValue); // デバッグ用
        if (Yvalue != 0)
        {
            ScrollValue += Yvalue / 100;
            if (ScrollValue > 1)
            {
                ScrollValue = 1;
            }
            if (ScrollValue < 0)
            {
                ScrollValue = 0;
            }
             Scroll.value = ScrollValue;
       
        }
        
    }
    public void scrollValueUp()
    {
        ScrollStop = true;
                    ScrollValue = 0;
            Scroll.value = ScrollValue;
        
        
    }
    private void OnEnable()
    {
        ScrollValue = 0;
        Scroll.value = ScrollValue;
    }
}

