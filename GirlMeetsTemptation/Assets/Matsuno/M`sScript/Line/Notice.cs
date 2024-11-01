using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public static bool NoticeFlag = false;
    private Coroutine ActiveCoroutine;
    public static int NoticeCnt;
    public static bool FirstTaskText = false;
    public static bool ManeLineTaskFlagON = false;
    public static bool Tomodati1TaskFlagON = false;
    bool test = false;
    [SerializeField] GameObject Phone;
    [SerializeField] TextMeshProUGUI TaskNoticeText;

    public static bool Task1 = true;
    public static bool Task2 = true;
    public static bool Task3 = true;
    public static bool Task4 = true;


    bool TaskFirstFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        FirstTaskText = false;
        Phone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("タスクフラグおん" + TaskFirstFlag);

        if (PlayerMovement.PhoneONTaskFlag && !ManeLineTaskFlagON && TaskFirstFlag)
        {
            // コルーチンが実行中でない場合のみ開始する
            if (ActiveCoroutine == null)
            {
                Debug.Log("コルーチン開始");
                ActiveCoroutine = StartCoroutine(Timer());
                TaskFirstFlag = false;
            }
        }
        else if (!PlayerMovement.PhoneONTaskFlag)
        {
            // いずれかの条件が成立しない場合、コルーチンを停止する
            if (ActiveCoroutine != null)
            {
                StopCoroutine(ActiveCoroutine);
                ActiveCoroutine = null;
                Debug.Log("コルーチンストップ");
                TaskFirstFlag = true;
                Phone.SetActive(false);
            }
        }
    }


    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(7.5f);
        Debug.Log("のーちすフラグオン！");

        // 重複チェックのために、使用済みの通知番号をリストで管理します。
        List<int> usedNoticeCounts = new List<int>();

        // ランダムに生成して重複がないようになるまでループします。
        do
        {
            NoticeCnt = Random.Range(1, 5);
        } while (usedNoticeCounts.Contains(NoticeCnt));

        // 選ばれた通知番号をリストに追加します。
        usedNoticeCounts.Add(NoticeCnt);

        NoticeFlag = true;
        FirstTaskText = true;

        Phone.SetActive(true);

        switch (NoticeCnt)
        {
            case 1:
                Tomodati1TaskFlagON = true;
                Task1 = false;
                TaskNoticeText.text = "友達からのBYEN通知";
                break;
            case 2:
                Tomodati1TaskFlagON = true;
                Task2 = false;
                TaskNoticeText.text = "友達からのBYEN通知";
                break;
            case 3:
                ManeLineTaskFlagON = true;
                Task3 = false;
                TaskNoticeText.text = "マネージャーからのBYEN通知";
                break;
            case 4:
                ManeLineTaskFlagON = true;
                Task4 = false;
                TaskNoticeText.text = "マネージャーからのBYEN通知";
                break;
        }

    }
}
