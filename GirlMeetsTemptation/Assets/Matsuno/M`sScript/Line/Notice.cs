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

    // Start is called before the first frame update
    void Start()
    {
        FirstTaskText = false;
        Phone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (/*スマホが開いていないとき && NoticeFlag &&*/ !ManeLineTaskFlagON && !test)
        {
            // 現在のコルーチンが実行中なら停止する
            if (ActiveCoroutine == null)
            {
                Debug.Log("コルーチン開始");
                // 新しいコルーチンを開始し、その参照を保存する
                ActiveCoroutine = StartCoroutine(Timer());
            }
        }
        else
        {
            // 現在のコルーチンが実行中なら停止する
            if (ActiveCoroutine != null)
            {
                StopCoroutine(ActiveCoroutine);
            }
            //Phone.SetActive(false);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(7.5f);
        Debug.Log("のーちすフラグオン！");
        //テストのため後で絶対にフラグを消す必要あり
        test = true;
        NoticeFlag = true;
        NoticeCnt = Random.Range(1, 2);
        FirstTaskText = true;

        Phone.SetActive(true);

        if (NoticeCnt == 1)
        {
            ManeLineTaskFlagON = true;
            TaskNoticeText.text = "マネージャーからのBYEN通知";
        }
        else if(NoticeCnt == 2)
        {
            Tomodati1TaskFlagON = false;
            TaskNoticeText.text = "友達からのBYEN通知";
        }
        else if (NoticeCnt == 3)
        {
            ManeLineTaskFlagON = true;
            TaskNoticeText.text = "マネージャーからのBYEN通知";
        }
        else if (NoticeCnt == 4)
        {
            //友達ラインタスクフラグ
        }
        else if (NoticeCnt == 5)
        {
            //友達ラインタスクフラグ
        }
        else if (NoticeCnt == 6)
        {
            //友達ラインタスクフラグ
        }
        else if (NoticeCnt == 7)
        {
            
        }
        else if (NoticeCnt == 8)
        {
            
        }
        else if (NoticeCnt == 9)
        {

        }
    }
}
