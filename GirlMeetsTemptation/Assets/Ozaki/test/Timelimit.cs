using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timelimit : MonoBehaviour
{
    public static Timelimit Instance;

    //カウントダウン
    //public float countdown;
    public Image nizigauge;
    public TextMeshProUGUI gaugeText;
    private float gaugeDuration = 20f;  // ゲージが増加する時間
    public Image tempgauge;
    public Material customSkyboxMaterial; // InspectorでセットできるカスタムSkyBox用のマテリアル
    public Camera mainCamera; // mainCameraの参照
    private int displayTime;
 
    //時間を表示するText型の変数
    public Text timeText;
    private PlayerMovement PlayerMovement;
 
    void Start()
    {
        nizigauge.gameObject.SetActive(false);
        tempgauge.fillAmount = 0;
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        
    }
    void Update()
    {
        //Timelimits();
        UpdateGauge();
    }

    /*private void Timelimits(){
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
            GameOver.SetMessage("時間が切れて死んだ");
            Scene.GetInstance().EndGame();
        }
    }*/

    private void UpdateGauge()
    {
        if(tempgauge.fillAmount == 1){
            nizigauge.gameObject.SetActive(true);
            StartCoroutine(EndGameAfterDelay(10f));
        }else{
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
        gaugeDuration = Mathf.Clamp(gaugeDuration, 0, 40);

        // ゲージのfillAmountを更新
        tempgauge.fillAmount = Mathf.Clamp01(gaugeDuration / 40f);
        float num = tempgauge.fillAmount * 100;
        gaugeText.text = num.ToString("F0");
        }
    }
    private IEnumerator EndGameAfterDelay(float delay)
    {
        Audio.GetInstance().PlaySound(6);
        mainCamera.GetComponent<Skybox>().material = customSkyboxMaterial;
        PlayerMovement.setphoneOn(true);
        PlayerMovement.setkyouran(true);
        yield return new WaitForSeconds(delay);
        MGameOver.SetMessage("踊り狂って死んだ");
        Scene.GetInstance().EndGame();
    }

    public int getTime(){
        return displayTime;
    }

    public float getTemp()
    {
        return tempgauge.fillAmount;
    }
}
