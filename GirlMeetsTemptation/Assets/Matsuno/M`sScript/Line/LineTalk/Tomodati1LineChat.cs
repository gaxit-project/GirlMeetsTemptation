using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tomodati1LineChat : MonoBehaviour
{
    [SerializeField] private LineContent contentManager;
    [SerializeField] private ScrollLine ScrollManager;
    int LineRndCnt;
    string LineText;

    public Stack<string> SelectStack = new Stack<string>();
    public Stack<string> LineStack = new Stack<string>();

    [SerializeField] private TextMeshProUGUI TmpX;
    [SerializeField] private TextMeshProUGUI TmpA;
    [SerializeField] private TextMeshProUGUI TmpB;
    public GameObject SelectTextUI;

    bool TopicSelectFlag = false;
    string TopicSelectText;

    // 選択肢の評価用の処理
    [SerializeField] GameObject EvaluationCanvas;
    [SerializeField] GameObject EvaluationImage;
    [SerializeField] TextMeshProUGUI EvaluationText;

    public FameManager FMManeger;

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
    }

    public void Update()
    {
        //マネージャーのライン起動
        if (ButtonManager.TwiXFlag && LineButtom.Tomodati1Flag)
        {
            //ラインタスクがオンになったとき
            if (Notice.Tomodati1TaskFlagON)
            {
                int HumanTime = Map.Timer;
                int CarTime = Map.CarTimer;
                int number1 = Notice.NoticeCnt;
                Debug.Log("ラインタスクのフラグ:" + number1);
                if (number1 == 2)
                {
                    if (Notice.FirstTaskText)
                    {
                        contentManager.AddToLeftText("あとどれくらいで付きそう？めっちゃ待ってるんだけど");
                        ScrollManager.scrollValueUp();
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push(CarTime + "分くらい");
                        LineStack.Push("あと30分");
                        LineStack.Push(HumanTime + "分くらい");
                        LineButtom.SelectTextUIFlag = true;
                        Notice.FirstTaskText = false;
                    }

                    if (LineButtom.XButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("全然いいよもう少しでつきそうだし！近くのカフェにいるから着いたらまた連絡ちょーだい");
                        SelectStack.Push("あと" + HumanTime + "くらいかな...おくれてめちゃめちゃごめん！！");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.LinePerfect = true;
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("あんたすごいね...カフェでゆっくり待っとくわ");
                        SelectStack.Push("いまメイク中！あと30分くらいで家出れると思う！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("あんた車なんか持ってないでしょ！冗談はいいから早めに来てね");
                        SelectStack.Push("のこり1分位でつく！なんせ私は今車で向かってるからね！");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (number1 == 5)
                {
                    SelectStack.Clear();
                }
                else if (number1 == 6)
                {
                    SelectStack.Clear();
                }
            }
            else
            {
                if (LineButtom.TextRndFlag)
                {
                    //スタックの中身をリセット
                    LineStack.Clear();
                    //通常時のラインテキストランダム表示
                    LineRndCnt = Random.Range(1, 10);
                    if (LineRndCnt < 5)
                    {
                        LineButtom.SelectKey(LineRndCnt, LineRndCnt + 2, LineRndCnt + 4);
                        int A = LineRndCnt;
                        int B = LineRndCnt + 2;
                        int C = LineRndCnt + 4;
                        LineStack.Push(C.ToString());
                        LineStack.Push(B.ToString());
                        LineStack.Push(A.ToString());
                    }
                    else
                    {
                        LineButtom.SelectKey(LineRndCnt, LineRndCnt - 2, LineRndCnt - 4);
                        int A = LineRndCnt;
                        int B = LineRndCnt - 2;
                        int C = LineRndCnt - 4;
                        LineStack.Push(C.ToString());
                        LineStack.Push(B.ToString());
                        LineStack.Push(A.ToString());
                    }
                    TopicSelectFlag = true;
                    LineButtom.SelectFlag = true;
                    LineButtom.TextRndFlag = false;
                    LineButtom.SelectTextUIFlag = true;
                }
                if (LineButtom.Text1)
                {
                    if (LineButtom.FirstText)
                    {
                        Debug.Log("テキスト1表示");
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("いいね！どこ行くか決めてる？");
                        SelectStack.Push("ねえ、週末ランチ行かない？");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("安いとこ\nがいい");
                        LineStack.Push("映える\nカフェ行こ");
                        LineStack.Push("やっぱ\nやめとく");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("なにそれ（笑）じゃあまた次の機会に行こうよ");
                        SelectStack.Push("えー、行くの面倒くさいからやっぱやめようかな");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("わかる～！あそこずっと行きたかったの！楽しみすぎる！");
                        SelectStack.Push("最近できたカフェ行こうよ！映えるメニューあるらしいんだよね");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まあ、確かに安いの大事だよね（笑）じゃあ私のバ先にしようか！");
                        SelectStack.Push("うーん、どこでもいいけど、やっぱり安いとこがいいなー");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text2)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("わかる！私も週末はだいたいおうちでゴロゴロしてるよ");
                        SelectStack.Push("最近忙しすぎて疲れちゃった…どうやってリフレッシュしてる？");
                        Debug.Log("テキスト2表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("それ最高！");
                        LineStack.Push("刺激が\n欲しい");
                        LineStack.Push("つい外\n出ちゃう");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("それもわかる！でもたまには休んで、家でのんびりするのも良いよ！");
                        SelectStack.Push("私もそうしたいんだけど、ついつい外に出ちゃうんだよね～");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("まぁ、刺激も大事だけど…たまにはゆっくりするのも良いかもね");
                        SelectStack.Push("家にいるのは飽きるなー　もっと刺激欲しくない？");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("うん、たまにはゆっくり休むのも大事だよ！ドラマとか観ようよ！");
                        SelectStack.Push("それ最高だね！私も週末はのんびりしようかな");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text3)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("へぇ、いいじゃん！私もやってみようかな～");
                        SelectStack.Push("最近、ヨガ始めてみたんだ！リフレッシュにもなるし、意外と楽しいよ");
                        Debug.Log("テキスト3表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("一緒に\n行こう！");
                        LineStack.Push("動画で\n試して");
                        LineStack.Push("思ったより\nキツい");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("え、そんなにキツいの？じゃあちょっと考えようかな…");
                        SelectStack.Push("いや、思ったよりキツいから覚悟して");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("なるほどね。じゃあ動画でまずは試してみるよ！");
                        SelectStack.Push("興味あるなら動画で試してみるのも良いかも！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("ほんと？行く行く！一緒にやったら楽しそう！");
                        SelectStack.Push("一緒に行こうよ！初心者でも大丈夫だからさ！");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text4)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("私も観てる！次の展開が気になりすぎる！");
                        SelectStack.Push("最近「詐欺師たち」ってドラマ観てるんだけど、めちゃくちゃ面白いよ！観たことある？");
                        Debug.Log("テキスト4表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("読めない\nよね");
                        LineStack.Push("伏線が最高");
                        LineStack.Push("ストーリー\n複雑");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("そう？でも慣れればすごくハマるよ！");
                        SelectStack.Push("うーん、ちょっとストーリーがわかりにくいんだよなぁ");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("わかるわかる！早く次が観たくて待ちきれない！");
                        SelectStack.Push("だよね！あのキャラの伏線とか最高すぎ！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("ほんとそれ！予想がつかないから面白いんだよね～");
                        SelectStack.Push("次どうなるか全然読めないよね～");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text5)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("いいね～！リラックスできそうだし行きたい！");
                        SelectStack.Push("今度、旅行行こうよ！温泉とかどぉ？");
                        Debug.Log("テキスト5表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("他の候補は？");
                        LineStack.Push("温泉は\nやめよう");
                        LineStack.Push("無馬温泉\nにしよ！");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("無馬温泉いいよね！お肌にも良さそうだし楽しみ～！");
                        SelectStack.Push("じゃあ、無馬温泉にしよう！あそこずっと気になってたんだよね！");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("じゃあまた次に行く計画立てようか");
                        SelectStack.Push("やっぱ温泉は寒いしやめようかな…");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("他にもいろいろ候補探してみようか！");
                        SelectStack.Push("温泉以外にどこかおすすめある？");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text6)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("見た見た！SNSでも話題になってるよね！");
                        SelectStack.Push("最近新しいリップ出たの知ってる？リップクリーチャーのやつなんだけど、可愛すぎてやばい");
                        Debug.Log("テキスト6表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("売り切れてるかも");
                        LineStack.Push("もう買った");
                        LineStack.Push("リップって同じでしょ");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("なにそれ　リップにもいろいろあるのよ！");
                        SelectStack.Push("リップなんてどれも同じでしょ");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("さすが！今度見せて～！やっぱりきみぃ、トレンド早いね！");
                        SelectStack.Push("もう買っちゃったんだ～！色味も可愛いし絶対使えるよ！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("かもね～　でも見つけたら即ゲットだよ！");
                        SelectStack.Push("私も欲しいんだけど、もう売り切れてるかもね～");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text7)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("え、なになに？教えてほしい！");
                        SelectStack.Push("最近使ってる加工アプリ、めっちゃ良い感じなの！色味がすごく自然で映えるんだ～");
                        Debug.Log("テキスト7表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("企業秘密");
                        LineStack.Push("インスタで見た");
                        LineStack.Push("pigart\nってアプリ");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("ありがとう！ダウンロードするわ！やっぱ君に聞くと早いね～！");
                        SelectStack.Push("pigartってアプリだよ！インスタでも人気だし、加工も簡単！");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("探してみる！インスタで調べてみようかな");
                        SelectStack.Push("えっとね、pigなんちゃらだった気がする！たしかインスタで見つけたやつ");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("なんだそれ～！秘密にしないで教えてよ");
                        SelectStack.Push("いやー、企業秘密だから教えられない");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text8)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("まだ飲んでないけど、めっちゃ気になってる！");
                        SelectStack.Push("ねぇ、スダパの新作飲んだ？見た目もかわいいし、絶対映えるやつ！");
                        Debug.Log("テキスト8表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("久々に\n行こう");
                        LineStack.Push("映え狙いで\n行こう！");
                        LineStack.Push("甘すぎた");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("えー、甘すぎた？私、甘党だからちょっと挑戦してみる！");
                        SelectStack.Push("あれ、甘すぎて無理だったわ");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("行く行く！写真いっぱい撮ろうね！");
                        SelectStack.Push("れ、飲むだけでインスタ映えするよ～！一緒に飲みに行こう！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("わかる～！じゃあ久しぶりに一緒に行く？");
                        SelectStack.Push("私も気になってた！でもスタバ行くの久々だな～");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text9)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("すごいじゃん！めちゃくちゃ頑張ってるもんね！");
                        SelectStack.Push("見て見て！フォロワー数がついに10万人超えたの！嬉しすぎる！");
                        Debug.Log("テキスト9表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("まだまだ\nだけど");
                        LineStack.Push("管理が大変");
                        LineStack.Push("もっと\n頑張る！");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("応援してるよ！これからもどんどん伸びるね！");
                        SelectStack.Push("ありがとう！これからももっと頑張る！");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("でも嬉しい悲鳴ってやつじゃない？");
                        SelectStack.Push("いや、でも多すぎて管理が大変かも");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("うんうん、でもまずは今を喜ぼう！");
                        SelectStack.Push("まぁ、まだまだだけどね。でも嬉しい！");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
            }
            if (LineButtom.ButtonOFFFlag)
            {
                //選択肢を非表示
                SelectTextUI.SetActive(false);
            }
            else
            {
                if (LineStack.Count >= 3)  // スタックに最低3つの要素があることを確認
                {
                    string XButton = LineStack.Pop();
                    string AButton = LineStack.Pop();
                    string BButton = LineStack.Pop();

                    // 選択肢を表示
                    if (TopicSelectFlag)
                    {
                        TopicSelectFlag = false;
                        TopicSelect(XButton, 1);
                        TopicSelect(AButton, 2);
                        TopicSelect(BButton, 3);
                    }
                    else
                    {
                        TmpX.text = XButton;
                        TmpA.text = AButton;
                        TmpB.text = BButton;
                    }

                    SelectTextUI.SetActive(true);
                }
            }

            // 選択肢の評価を表示する
            if (LineButtom.Evaluation)
            {
                EvaluationCanvas.SetActive(true);
                Image EvaluationImageComponent = EvaluationImage.GetComponent<Image>();
                if (LineButtom.LinePerfect)
                {
                    EvaluationText.text = "パーフェクト";
                    EvaluationImageComponent.color = new Color(240f / 255f, 255f / 255f, 110f / 255f);
                    FMManeger.UpFgauge(5);
                    LineButtom.LinePerfect = false;
                }
                else if (LineButtom.LineNormal)
                {
                    EvaluationText.text = "ノーマル";
                    EvaluationImageComponent.color = new Color(180f / 255f, 240f / 255f, 170f / 255f);
                    FMManeger.UpFgauge(3);
                    LineButtom.LineNormal = false;
                }
                else if (LineButtom.LineBad)
                {
                    EvaluationText.text = "バッド";
                    EvaluationImageComponent.color = new Color(100f / 255f, 200f / 255f, 250f / 255f);
                    FMManeger.DownFgauge(5);
                    LineButtom.LineBad = false;
                }
                LineButtom.Evaluation = false;
            }
        }
    }

    void TopicSelect(string ButtonNumber, int Cnt)
    {
        // ボタンの中身
        if (ButtonNumber == "1")
        {
            TopicSelectText = "ランチ\n行かない";
        }
        else if (ButtonNumber == "2")
        {
            TopicSelectText = "どうリフレッシュしてる";
        }
        else if (ButtonNumber == "3")
        {
            TopicSelectText = "ヨガ始めた";
        }
        else if (ButtonNumber == "4")
        {
            TopicSelectText = "ドラマ\n面白い";
        }
        else if (ButtonNumber == "5")
        {
            TopicSelectText = "旅行\n行こうよ！";
        }
        else if (ButtonNumber == "6")
        {
            TopicSelectText = "リップ\n知ってる？";
        }
        else if (ButtonNumber == "7")
        {
            TopicSelectText = "加工アプリ\n良い感じ";
        }
        else if (ButtonNumber == "8")
        {
            TopicSelectText = "スダパの\n新作飲んだ";
        }
        else if (ButtonNumber == "9")
        {
            TopicSelectText = "フォロワー\n1万人!";
        }
        // ボタンの種類
        if (Cnt == 1)
        {
            TmpX.text = TopicSelectText;
        }
        else if (Cnt == 2)
        {
            TmpA.text = TopicSelectText;
        }
        else if (Cnt == 3)
        {
            TmpB.text = TopicSelectText;
        }
    }

    // 一回目のテキスト表示
    private IEnumerator Text()
    {
        LineText = SelectStack.Pop();
        contentManager.AddToRightText(LineText);
        ScrollManager.scrollValueUp();

        for (int i = 0; i < 3; i++)
        {
            contentManager.AddToLeftText("＊・・");
            ScrollManager.scrollValueUp();
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・＊・");
            ScrollManager.scrollValueUp();
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・・＊");
            ScrollManager.scrollValueUp();
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
        }
        LineText = SelectStack.Pop();
        contentManager.AddToLeftText(LineText);
        ScrollManager.scrollValueUp();

        LineButtom.ButtonOFFFlag = false;
    }
    // 二回目のテキスト表示
    private IEnumerator Text2()
    {

        LineText = SelectStack.Pop();
        contentManager.AddToRightText(LineText);
        ScrollManager.scrollValueUp();

        for (int i = 0; i < 3; i++)
        {
            contentManager.AddToLeftText("＊・・");
            ScrollManager.scrollValueUp();
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・＊・");
            ScrollManager.scrollValueUp();
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
            contentManager.AddToLeftText("・・＊");
            ScrollManager.scrollValueUp();
            yield return new WaitForSeconds(0.5f);
            contentManager.RemoveLastText();
        }
        LineText = SelectStack.Pop();
        contentManager.AddToLeftText(LineText);
        ScrollManager.scrollValueUp();

        yield return new WaitForSeconds(1f);
        // 選択肢の評価関連
        LineButtom.Evaluation = true;
        yield return new WaitForSeconds(3f);
        EvaluationCanvas.SetActive(false);

        LineButtom.TextRndFlag = true;
        LineButtom.ButtonOFFFlag = false;
        if (Notice.ManeLineTaskFlagON)
        {
            Notice.ManeLineTaskFlagON = false;
            Notice.FirstTaskText = true;
        }
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
