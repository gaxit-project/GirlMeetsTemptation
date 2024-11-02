using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManeChanLineChat : MonoBehaviour
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
        if (ButtonManager.TwiXFlag && LineButtom.ManeChanFlag)
        {
            Debug.Log("らいんひらくよーん");
            //ラインタスクがオンになったとき
            if (Notice.ManeLineTaskFlagON)
            {
                Debug.Log("友達タスクON！");
                int HumanTime = Map.Timer;
                int CarTime = Map.CarTimer;
                if (!Notice.Task1)
                {
                    Debug.Log("タスク1実行！！！");
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
                        Notice.Task1 = true;
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
                        Notice.Task1 = true;
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
                        Notice.Task1 = true;
                    }
                }
                else if (!Notice.Task2)
                {
                    Debug.Log("タスク2実行！！！");
                    if (Notice.FirstTaskText)
                    {
                        contentManager.AddToLeftText("最近よく見てる切り抜きチャンネルがあるんだけどそのチャンネルのエンディングに使われてる「ワンダーランド」って曲めっちゃチルくていいよ！");
                        ScrollManager.scrollValueUp();
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("和楽器\nいいよね");
                        LineStack.Push("ボーカルが\n入るとは...");
                        LineStack.Push("序盤\nめちゃいい");
                        LineButtom.SelectTextUIFlag = true;
                        Notice.FirstTaskText = false;
                    }

                    if (LineButtom.XButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("わかる～！もう私ずっと「てってーてれてててれれ」って頭の中で無限再生されてるもん！");
                        SelectStack.Push("序盤のチルめの感じから音が大集合してくのめっちゃアゲって感じでいいよね！");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.LineNormal = true;
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                        Notice.Task1 = true;
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("私も最初はびっくりしたけど歌詞も曲調も胸にじわっと来る感じめちゃいいよね！");
                        SelectStack.Push("BGMが続くと思ってたんだけどいきなり歌声入ってきてびっくりした！だけどめちゃいい曲！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                        Notice.Task1 = true;
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("あんたが何言ってるかはわかんないけど何も聴いてないのは分かったよ");
                        SelectStack.Push("やっぱりあの和楽器特融の雰囲気というかチルさというか...ああいう雰囲気言葉にいい表しずらいけどいいよね");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                        Notice.Task1 = true;
                    }
                }
                if (!Notice.Task3)
                {
                    if (Notice.FirstTaskText)
                    {
                        contentManager.AddToLeftText("森田交一さんの「アジトへの道」っていう曲がめちゃめちゃいいの！時間あるときにでも気分転換に聴いて！");
                        ScrollManager.scrollValueUp();
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("オーケストラの曲");
                        LineStack.Push("サイバー\nな曲");
                        LineStack.Push("宇宙を\n感じた...");
                        LineButtom.SelectTextUIFlag = true;
                        Notice.FirstTaskText = false;
                    }

                    if (LineButtom.XButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("え？宇宙？？一応サイバーな雰囲気の曲だからそうともいえるのかな...?");
                        SelectStack.Push("なんか、これ聴いてたら宇宙を漂ってる気分になったんだけど…私だけかな？");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.LineNormal = true;
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                        Notice.Task3 = true;
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("おぉ！そうそう、絶対君の好みに合うと思ったんだ。次の撮影BGMにも使えそうだよね！");
                        SelectStack.Push("これ、ヤバいね！サイバーパンクっぽいビートでめっちゃカッコよかった！こういう感じの曲、テンション上がるから私大好きだよ");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                        Notice.Task3 = true;
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("ちょ、違う違う！あの曲にティンパニなんか出てこないって いや、どこでそんな風に聴いたのか謎だけど…");
                        SelectStack.Push("えーっと、あれだよね？あの壮大なストリングスが重なって、ホールで聴くと圧倒されそうな…それにしても、ティンパニの入り方が絶妙だったわ～？");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                        Notice.Task3 = true;
                    }
                }
                else if (!Notice.Task4)
                {
                    if (Notice.FirstTaskText)
                    {
                        contentManager.AddToLeftText("企業からの案件が今来て〇〇っていうゲームを紹介する必要があるから１回どんなゲームか実際に遊んでみて～！");
                        ScrollManager.scrollValueUp();
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("敵を避ける\nやつ");
                        LineStack.Push("鏡の世界");
                        LineStack.Push("炎消すやつ");
                        LineButtom.SelectTextUIFlag = true;
                        Notice.FirstTaskText = false;
                    }

                    if (LineButtom.XButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("いや全然別物だから！それ「カジバカ！」だから！");
                        SelectStack.Push("あれだよね！自分が消防隊になって燃え盛ってる家事現場から炎を消火して人を10人以上救う東京ゲームショウにも展示されたゲームだよね！");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.LineNormal = true;
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                        Notice.Task4 = true;
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("いや全然別物だから！それ「鏡子」だから！");
                        SelectStack.Push("あれだよね！化け物が襲ってくる謎の鏡の世界を解明していくホラーゲームだよね！");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                        Notice.Task4 = true;
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("そうそう！案件配信の内容はコインをどれだけ稼げるか！稼げたコイン分プレゼント企画！だから頑張って練習してね！");
                        SelectStack.Push("あれだよね！敵をよけながらコインを集めるゲームだよね！");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                        Notice.Task4 = true;
                    }
                }
            }
            else
            {
                if (LineButtom.TextRndFlag)
                {
                    //スタックの中身をリセット
                    LineStack.Clear();
                    //通常時のラインテキストランダム表示
                    LineRndCnt = Random.Range(1, 19);
                    if (LineRndCnt < 10)
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
                        SelectStack.Push("それいいね！実はあのカフェ、今めちゃくちゃ人気らしいよ。予約しないと入れないかも");
                        SelectStack.Push("ねぇ、明日の撮影、頑張ったらご褒美で甘いもの食べに行きたいな！前から気になってた駅前のカフェで食べてみたいかも～");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("ファミレスがいい");
                        LineStack.Push("映えるけど量少ない");
                        LineStack.Push("全種類食べたい！");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("OK！今から予約しとくから、撮影も気合い入れていこう！");
                        SelectStack.Push("えーっ、じゃあ今から予約お願い！全種類食べるからねっ！");
                        Debug.Log("ボタンのフラグがオンになりました:" + LineButtom.XButtonFlag);
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("確かに。じゃあ撮影の後、軽くコンビニでお腹満たしてから行く？");
                        SelectStack.Push("え～おしゃれなカフェって、ちょっと映えはするけど量が少ないのが残念だよね");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("ファミレスでも全然いいけど…せっかくのご褒美だし、もう少し贅沢してもいいんじゃない？");
                        SelectStack.Push("うーん…それならファミレスでガッツリパフェ食べたほうがよくない？");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text2)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("いいね！リップクリーチャーのリップなら映えそうだし、衣装とも合いそう。どう？撮影で実際に使ってみる？");
                        SelectStack.Push("最近さ、リップクリーチャーの新作リップ買っちゃったんだ！ もうね、発色が良すぎて最高なの！これ、次の撮影で使いたいな～");
                        Debug.Log("テキスト2表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("もちろん使う！");
                        LineStack.Push("無くしそう");
                        LineStack.Push("派手かも…でも好き");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("まぁ、好きなもの使うのが一番だよね。君らしいと思うよ");
                        SelectStack.Push("うーん、ちょっと派手すぎるかなぁ。でも私的にはこのくらい主張強いのも好き！");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("大丈夫、また新しいの買えばいいさ！どんどん使おう！");
                        SelectStack.Push("どうしよう…気に入りすぎて、無くすの怖いからやっぱりやめとこうかな");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("もちろん使う！衣装との組み合わせも完璧だから、絶対バッチリ映えると思う！");
                        SelectStack.Push("OK！メイクさんにも伝えておくよ。これは間違いなく映えるね！");
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
                        SelectStack.Push("わかるよ。でも今回はVIP枠で君を招待してるから、注目されるチャンスだよ？参加するだけでかなり大きな話題になるはず");
                        SelectStack.Push("ねぇ、マネージャー。今度のイベント、正直行くの面倒だなぁ… 行ったほうがいいのは分かってるけど、ちょっと気分が乗らないかも");
                        Debug.Log("テキスト3表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("映え狙って行く");
                        LineStack.Push("疲れたら帰る");
                        LineStack.Push("行かない");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("うーん…まあ仕方ないけど、少しもったいない気もするな");
                        SelectStack.Push("やっぱり行かない！家でゴロゴロしたいの…");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("無理は禁物だからね。楽しめる範囲で参加しよう");
                        SelectStack.Push("ん～行くけど、疲れたら途中で帰ってもいい？");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("それがいい！映えスポットも調べておくから、準備は任せて！");
                        SelectStack.Push("それなら行こうかな！映えを狙って、バッチリ決めていく");
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
                        SelectStack.Push("今週はちょっと忙しいけど、来週ならなんとか調整できそうだよ");
                        SelectStack.Push("ねぇ、たまにはしっかり休みたいんだけど、次の休暇っていつ取れるかな？ちょっとリフレッシュしたくて…");
                        Debug.Log("テキスト4表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("今週がいいのに");
                        LineStack.Push("来週はのんびりする");
                        LineStack.Push("それでもいいかな");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("まぁ、仕方ないな。来週を楽しみにしておこう！");
                        SelectStack.Push("来週かぁ…まぁ、それでもいいかな。仕方ないよね");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("了解！来週は仕事の連絡もなしで、しっかりリフレッシュして");
                        SelectStack.Push("やったー！じゃあ来週は思いっきりのんびりするね～");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("今週は無理だけど、ごめんね。来週を楽しみにしてて！");
                        SelectStack.Push("え～今週がいいのにー！なんとかしてくれない？");
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
                        SelectStack.Push("それなら雑談配信とかどう？ファンと直接コミュニケーションを取るいい機会だと思うよ");
                        SelectStack.Push("最近、フォロワーとの距離がちょっと気になってて…もう少し距離を縮めたほうがいいのかな？");
                        Debug.Log("テキスト5表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("準備が面倒");
                        LineStack.Push("他の方法ない？");
                        LineStack.Push("週末に配信やる");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("いいね！サポートは任せて。きっと盛り上がるよ！");
                        SelectStack.Push("それいいかも！週末に配信やっちゃおうかな");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("楽な方法も探してみるけど、やっぱり配信が一番だと思う");
                        SelectStack.Push("いや、配信はやりたくない…もっと楽な方法ない？");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まぁ、少し大変だけどやってみる価値はあると思うよ");
                        SelectStack.Push("配信って準備がちょっと面倒なんだよなぁ");
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
                        SelectStack.Push("うーん、今のトレンド的にはこっちが良さそうかな。でも、君が着て心地いいほうが一番だよ");
                        SelectStack.Push("今度の撮影で着る服なんだけど、どっちにするか迷ってるんだよね。これとこれ、どっちがいいと思う？");
                        Debug.Log("テキスト6表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("着てみて決める");
                        LineStack.Push("これにする");
                        LineStack.Push("別の服にしようかな");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("まぁ、どれを選んでも似合うから安心して！");
                        SelectStack.Push("そっか。でも準備もあるし、別の服にしちゃおうかな");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("それだね！映える準備、こっちでしっかり整えておくよ");
                        SelectStack.Push("じゃあこれにする！当日バッチリ決めていくね");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("もちろん、当日試してから決めても大丈夫だよ");
                        SelectStack.Push("うーん…着てみてから決めてもいい？");
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
                        SelectStack.Push("国内も楽で良いけど、海外だと映える写真がたくさん撮れるかもね");
                        SelectStack.Push("次の案件で旅行に行けるらしいんだけど、国内か海外か選べるんだって。どっちがいいと思う？");
                        Debug.Log("テキスト7表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("どっちもパス");
                        LineStack.Push("国内が楽でいい");
                        LineStack.Push("海外行きたい");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("決まりだね！いい観光地をリストアップしておくよ");
                        SelectStack.Push("海外がいい！映えスポットたくさんあるし、写真もいっぱい撮りたい");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("そうだよね。温泉とかもいいし、リラックスできる場所探そう");
                        SelectStack.Push("うーん…国内のほうが移動が楽で助かるなぁ");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まぁ、疲れるのもわかるけど、仕事だし頑張ろうよ");
                        SelectStack.Push("どっちもパスで。旅行は疲れるから嫌だな");
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
                        SelectStack.Push("そういうのが出てくるとしんどいよね。でも、どう対応するかで印象も変わるよ");
                        SelectStack.Push("最近、アンチコメント増えてる気がするんだよね…どうしたらいいかな？");
                        Debug.Log("テキスト8表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("少し反応しようかな？");
                        LineStack.Push("無視する");
                        LineStack.Push("全部消してほしい");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("気持ちはわかるけど、無視するほうが効果的なことも多いんだ");
                        SelectStack.Push("もう嫌だ…全部消してほしい");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("その意気だよ！アンチに負けずに進もう");
                        SelectStack.Push("無視するのが一番だよね。私は私のままでいく");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まあ、反応するなら冷静にね。感情的になると良くないから");
                        SelectStack.Push("少しくらい反応したほうがいいのかな？");
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
                        SelectStack.Push("LITLITの新作コスメが今人気みたいだよ。レビューも結構いいって！");
                        SelectStack.Push("最近さ、新しいコスメが欲しいんだけど、何かおすすめないかな？");
                        Debug.Log("テキスト9表示");
                        StartCoroutine(Text());
                        // 選択肢のスタックの準備
                        LineStack.Clear();
                        LineStack.Push("見るだけかな");
                        LineStack.Push("コスメ興味ないかも");
                        LineStack.Push("買ってみる");
                        LineButtom.SelectTextUIFlag = true;
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("レビュー楽しみにしてるよ！絶対似合うと思う");
                        SelectStack.Push("買ってみる！試してみるのが楽しみだな");
                        LineButtom.XButtonFlag = false;
                        LineButtom.LinePerfect = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("そっか…でも、興味が出たらいつでも試してみて！");
                        SelectStack.Push("うーん、コスメにはあんまり興味ないかも");
                        LineButtom.CButtonFlag = false;
                        LineButtom.LineBad = true;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まぁ、無理して買わなくてもいいよね");
                        SelectStack.Push("見るだけにしとこうかな…");
                        LineButtom.VButtonFlag = false;
                        LineButtom.LineNormal = true;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text10)
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
                else if (LineButtom.Text11)
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
                else if (LineButtom.Text12)
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
                else if (LineButtom.Text13)
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
                else if (LineButtom.Text14)
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
                else if (LineButtom.Text15)
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
                else if (LineButtom.Text16)
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
                else if (LineButtom.Text17)
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
                else if (LineButtom.Text18)
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
            TopicSelectText = "甘いもの\n食べたい";
        }
        else if (ButtonNumber == "2")
        {
            TopicSelectText = "いい口紅\n見つけた";
        }
        else if (ButtonNumber == "3")
        {
            TopicSelectText = "イベント\nつらたん";
        }
        else if (ButtonNumber == "4")
        {
            TopicSelectText = "来週\n休める？";
        }
        else if (ButtonNumber == "5")
        {
            TopicSelectText = "フォロワーと...";
        }
        else if (ButtonNumber == "6")
        {
            TopicSelectText = "撮影の服\nについて";
        }
        else if (ButtonNumber == "7")
        {
            TopicSelectText = "旅行案件\nについて";
        }
        else if (ButtonNumber == "8")
        {
            TopicSelectText = "アンチ増えてない？";
        }
        else if (ButtonNumber == "9")
        {
            TopicSelectText = "おすすめ\nコスメ";
        }
        else if (ButtonNumber == "10")
        {
            TopicSelectText = "ランチ\n行かない";
        }
        else if (ButtonNumber == "11")
        {
            TopicSelectText = "リフレッシュの仕方";
        }
        else if (ButtonNumber == "12")
        {
            TopicSelectText = "ヨガ始めた";
        }
        else if (ButtonNumber == "13")
        {
            TopicSelectText = "ドラマ\n面白い";
        }
        else if (ButtonNumber == "14")
        {
            TopicSelectText = "旅行\n行こうよ！";
        }
        else if (ButtonNumber == "15")
        {
            TopicSelectText = "リップ\n知ってる？";
        }
        else if (ButtonNumber == "16")
        {
            TopicSelectText = "加工アプリ\n良い感じ";
        }
        else if (ButtonNumber == "17")
        {
            TopicSelectText = "スダパの\n新作飲んだ";
        }
        else if (ButtonNumber == "18")
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

        LineButtom.TextRndFlag = true;
        LineButtom.ButtonOFFFlag = false;
        if (Notice.ManeLineTaskFlagON)
        {
            Notice.ManeLineTaskFlagON = false;
            Notice.FirstTaskText = true;
        }
        FlagOFF();

        yield return new WaitForSeconds(1f);
        // 選択肢の評価関連
        LineButtom.Evaluation = true;
        yield return new WaitForSeconds(3f);
        EvaluationCanvas.SetActive(false);
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