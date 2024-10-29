using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class FameManager : MonoBehaviour
{
    public Image Fgauge; //名声ゲージ画像
    private float Fscore = 0f; //名声ゲージ増加分用変数

    void Start()
    {
        Fgauge.fillAmount = Fscore;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpFgauge(10);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            DownFgauge(10);
        }
        
        Fgauge.fillAmount += Fscore;
        Fscore = 0f;
    }

    //操作用関数

    //Fgaugeを引数で指定した割合だけ増やす(引数0～100)
    public void UpFgauge(int score)
    {
        Fscore = score * 0.01f;
    }

    //Fgaugeを引数で指定した割合だけ減らす(引数0～100)
    public void DownFgauge(int score)
    {
        Fscore = score * -0.01f;
    }
}
