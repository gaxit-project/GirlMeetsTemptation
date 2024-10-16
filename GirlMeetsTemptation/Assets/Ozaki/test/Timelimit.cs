using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timelimit : MonoBehaviour
{
    //カウントダウン
    public float countdown;
    private float gaugeDuration = 20f;  // ゲージが増加する時間
    public Image tempgauge;
    private int displayTime;
 
    //時間を表示するText型の変数
    public Text timeText;
    private PlayerMovement PlayerMovement;
 
    void Start()
    {
        tempgauge.fillAmount = 0;
        PlayerMovement = FindObjectOfType<PlayerMovement>();
    }
    void Update()
    {
        Timelimits();
        UpdateGauge();
    }

    private void Timelimits(){
        //時間をカウントダウンする
        countdown -= Time.deltaTime;
 
        // 表示用にカウントダウン時間を整数に変換して表示する
        displayTime = Mathf.CeilToInt(countdown); // 小数点以下を切り上げて整数に
        // 時間を表示する
        if (displayTime > 0)
        {
            timeText.text = displayTime.ToString();
        }
        else
        {
            Scene.GetInstance().EndGame();
        }
    }

    private void UpdateGauge()
    {
        
        // ゲージのfillAmountを更新 (0から1の範囲)
        if (PlayerMovement.getphoneOn())
        {
            // プレイヤーが「phoneOn」のときゲージは減少する
            gaugeDuration -= Time.deltaTime;
        }
        else
        {
            // プレイヤーが「phoneOff」のときゲージは増加する
            gaugeDuration += Time.deltaTime;
        }

        // ゲージの値を範囲内に制限する
        gaugeDuration = Mathf.Clamp(gaugeDuration, 0, 30);

        // ゲージのfillAmountを更新
        tempgauge.fillAmount = Mathf.Clamp01(gaugeDuration / 20f);
    }

    public int getTime(){
        return displayTime;
    }
}
