using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarepiLineChat : MonoBehaviour
{
    [SerializeField] private LineContent contentManager;
    [SerializeField] private ScrollLine ScrollManager;
    public static bool LineTaskFlagON = false;
    int LineRndCnt;
    string LineText;

    public Stack<string> SelectStack = new Stack<string>();


    private void Start()
    {
        // テスト用に複数のテキストと画像を追加
        //contentManager.AddToLeftText("Contikuwa");
        //Debug.Log("Cintkuwa");
        //contentManager.AddToLeftText("Contikuwa\nkonnbanntiasdifjasdfljdslfjdlaasdfklasdjfjasdfjasdklf");
        //Debug.Log("Cinbanntikuwa");
        //contentManager.AddToRightText("hsdajasdfjgkadfjklsajfklasjkfaslfsklfksda");
        //Debug.Log("fjkasdf");

        LineButtom.TextRndFlag = true;
        LineTaskFlagON = false;
    }

    public void Update()
    {
        //マネージャーのライン起動
        if (/*ラインのフラグオン &&*/ LineButtom.ManeChanFlag)
        {
            //ラインタスクがオンになったとき
            if (LineTaskFlagON)
            {

            }
            else
            {
                if (LineButtom.TextRndFlag)
                {
                    //通常時のラインテキストランダム表示
                    LineRndCnt = Random.Range(1, 10);
                    LineRndCnt = 1;
                    //LineRndCnt = 1;
                    if (LineRndCnt < 5)
                    {
                        LineButtom.SelectKey(LineRndCnt, LineRndCnt + 2, LineRndCnt + 4);
                    }
                    else
                    {
                        LineButtom.SelectKey(LineRndCnt, LineRndCnt - 2, LineRndCnt - 4);
                    }
                    LineButtom.SelectFlag = true;
                    LineButtom.TextRndFlag = false;
                }
                if (LineButtom.Text1)
                {
                    if (LineButtom.FirstText)
                    {
                        Debug.Log("テキスト1表示");
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("それいいね！\n実はあのカフェ、今めちゃくちゃ\n人気らしいよ。予約しないと入れないかも");
                        SelectStack.Push("ねぇ、明日の撮影、頑張ったらご褒美で甘いもの食べに行きたいな！🍰 前から気になってた〇〇のケーキ、食べてみたいかも～");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("OK！今から予約しとくから、撮影も気合い入れていこう！");
                        SelectStack.Push("えーっ、じゃあ今から予約お願い！全種類食べるからねっ✨");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("確かに。じゃあ撮影の後、軽くコンビニでお腹満たしてから行く？");
                        SelectStack.Push("え～おしゃれなカフェって、ちょっと映えはするけど量が少ないのが残念だよね😕");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("ファミレスでも全然いいけど…せっかくのご褒美だし、もう少し贅沢してもいいんじゃない？");
                        SelectStack.Push("うーん…それならファミレスでガッツリパフェ食べたほうがよくない？");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text2)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        Debug.Log("テキスト2表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text3)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("i");
                        SelectStack.Push("i");
                        Debug.Log("テキスト3表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text4)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        Debug.Log("テキスト4表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text5)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("u");
                        SelectStack.Push("u");
                        Debug.Log("テキスト5表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text6)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        Debug.Log("テキスト6表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text7)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        Debug.Log("テキスト7表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text8)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        Debug.Log("テキスト8表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text9)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        Debug.Log("テキスト9表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("a");
                        SelectStack.Push("a");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
            }
        }
    }

    private IEnumerator Text()
    {
        LineText = SelectStack.Pop();
        contentManager.AddToRightText(LineText);
        ScrollManager.scrollValueUp();

        for (int i = 0; i < 3; i++)
        {
            ScrollManager.scrollValueUp();
            contentManager.AddToLeftText("＊・・");
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・＊・");
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・・＊");
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
        }
        LineText = SelectStack.Pop();
        contentManager.AddToLeftText(LineText);
        ScrollManager.scrollValueUp();

        LineButtom.ButtonOFFFlag = false;
    }
    private IEnumerator Text2()
    {

        LineText = SelectStack.Pop();
        contentManager.AddToRightText(LineText);
        ScrollManager.scrollValueUp();

        for (int i = 0; i < 3; i++)
        {
            ScrollManager.scrollValueUp();
            contentManager.AddToLeftText("＊・・");
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・＊・");
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・・＊");
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
        }
        LineText = SelectStack.Pop();
        contentManager.AddToLeftText(LineText);
        ScrollManager.scrollValueUp();

        LineButtom.TextRndFlag = true;
        LineButtom.ButtonOFFFlag = false;
        FlagOFF();
    }

    public void FlagOFF()
    {
        LineButtom.Text1 = false;
        LineButtom.Text2 = false;
        LineButtom.Text3 = false;
        LineButtom.Text4 = false;
        LineButtom.Text5 = false;
        LineButtom.Text6 = false;
        LineButtom.Text7 = false;
        LineButtom.Text8 = false;
        LineButtom.Text9 = false;
    }

}
