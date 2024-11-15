using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class opening : MonoBehaviour
{
    int StageSize = 15;
    int StageIndex;
    public Transform Target;//Unitychan
    public GameObject[] stagenum;//ステージのプレハブ
    private int aheadStage = 4; //事前に生成しておくステージ
    public int totalStages; // 生成するステージの総数
    private List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト

    public GameObject[] texts;
    public Camera camera;
    private Quaternion targetRotation;
    private float gaugeDuration = 25f;
    public Image tempgauge;
    private bool on = false;
    public CanvasGroup panelCanvasGroup;
    public CanvasGroup panelCanvasGroup1;
    public GameObject RuleCanvas;

    //ルール説明用
    //public ShowRule rule;
    //public GameObject RuleCanvas;

    void Start()
    {
        RuleCanvas.SetActive(false);
        targetRotation = camera.transform.rotation;
        StageManager(aheadStage);
        //RuleCanvas.SetActive(false);
        StartCoroutine(FadeOutPanel(2f, 3f));
        StartCoroutine(DisplayTexts(0, 6f, true));
        StartCoroutine(DisplayTexts(0, 8f, false));
        StartCoroutine(DisplayTexts(2, 10f, true));
        StartCoroutine(DisplayTexts(2, 12f, false));
        StartCoroutine(DisplayCamera(12f, 55));
        StartCoroutine(DisplayTexts(1, 12f, true));
        StartCoroutine(DisplayTexts(3, 14f, true));
        StartCoroutine(DisplayTexts(3, 15f, false));
        StartCoroutine(DisplayTexts(4, 17f, true));
        StartCoroutine(DisplayTexts(4, 18f, false));
        StartCoroutine(FadeInPanel(20f, 3f));
        
    }

    IEnumerator DisplayTexts(int index,float delay, bool isVisible)
    {
        yield return new WaitForSeconds(delay);
        
        texts[index].SetActive(isVisible);
    }
    IEnumerator DisplayCamera(float delay,int rot)
    {
        yield return new WaitForSeconds(delay);
        on=true;
        Audio.GetInstance().PlaySound(1);
        targetRotation = Quaternion.Euler(rot, camera.transform.rotation.eulerAngles.y, camera.transform.rotation.eulerAngles.z);
    }

    // フェードインメソッド
    public IEnumerator FadeInPanel(float delay,float duration)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            panelCanvasGroup1.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
        panelCanvasGroup1.alpha = 1f; // 完全に表示
        Audio.GetInstance().StopLoopSound();
        //Scene.GetInstance().MainGame();
        ShowRule showRuleScript = FindObjectOfType<ShowRule>(); // ShowRule スクリプトのインスタンスを取得
        if (showRuleScript != null){
            showRuleScript.StartShowRule(); // StartShowRule メソッドを呼び出し
        }
    }

    // フェードアウトメソッド
    public IEnumerator FadeOutPanel(float delay, float duration)
    {
        yield return new WaitForSeconds(delay); // フェードアウトまでの待機時間

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            panelCanvasGroup.alpha = Mathf.Clamp01(1f - (elapsed / duration));
            yield return null;
        }
        panelCanvasGroup.alpha = 0f; // 完全に非表示
    }

    private void UpdateGauge()
    {
        // ゲージのfillAmountを更新 (0から1の範囲)
        if (on)
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
    }
    // Update is called once per frame
    void Update()
    {
        UpdateGauge();
        transform.Translate(Vector3.forward * Time.deltaTime * 1F, Space.World);
        int targetPosIndex = (int)(Target.position.z / StageSize);
        if(targetPosIndex + aheadStage > StageIndex)
        {
            StageManager(targetPosIndex + aheadStage);
        }
        if (!Audio.GetInstance().IsPlayingSound(0)){
            Audio.GetInstance().PlaySound(0);
        }
        camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, targetRotation, Time.deltaTime * 2f);
    }
    void StageManager(int maps)
    {
        if(maps <= StageIndex)
        {
            return;
        }


        for(int i = StageIndex + 1;i <= maps; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while(StageList.Count > aheadStage + 1)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = maps;
    }
    GameObject MakeStage(int index)//ステージを生成する
    {
        GameObject stageObject = (GameObject)Instantiate(stagenum[0], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
