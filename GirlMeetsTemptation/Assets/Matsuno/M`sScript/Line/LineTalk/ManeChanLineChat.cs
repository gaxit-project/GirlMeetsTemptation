using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class ManeChanLineChat : MonoBehaviour
{
    [SerializeField] private LineContent contentManager;
    [SerializeField] private ScrollLine ScrollManager;
    public static bool LineTaskFlagON = false;
    int LineRndCnt;
    string LineText;

    public Stack<string> SelectStack = new Stack<string>();
    public Stack<string> LineStack = new Stack<string>();


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
        if(/*ラインのフラグオン &&*/ LineButtom.ManeChanFlag)
        {
            //ラインタスクがオンになったとき
            if (LineTaskFlagON)
            {

            }
            else
            {
                if(LineButtom.TextRndFlag)
                {
                    //スタックの中身をリセット
                    LineStack.Clear();
                    //通常時のラインテキストランダム表示
                    LineRndCnt = Random.Range(1, 10);
                    //LineRndCnt = 1;
                    if (LineRndCnt < 5)
                    {
                        LineButtom.SelectKey(LineRndCnt, LineRndCnt + 2,LineRndCnt + 4);
                        LineStack.Push("a");
                    }
                    else
                    {
                        LineButtom.SelectKey(LineRndCnt, LineRndCnt - 2, LineRndCnt - 4);
                    }
                    LineButtom.SelectFlag = true;
                    LineButtom.TextRndFlag = false;
                }
                if(LineButtom.Text1)
                {
                    if(LineButtom.FirstText)
                    {
                        Debug.Log("テキスト1表示");
                        //スタックの中身をリセット
                        SelectStack.Clear();
                        SelectStack.Push("それいいね！実はあのカフェ、今めちゃくちゃ人気らしいよ。予約しないと入れないかも");
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
                else if(LineButtom.Text2)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("いいね！リップクリーチャーのリップなら映えそうだし、衣装とも合いそう。どう？撮影で実際に使ってみる？");
                        SelectStack.Push("最近さ、リップクリーチャーの新作リップ買っちゃったんだ💄 もうね、発色が良すぎて最高なの！これ、次の撮影で使いたいな～");
                        Debug.Log("テキスト2表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("まぁ、好きなもの使うのが一番だよね。君らしいと思うよ");
                        SelectStack.Push("うーん、ちょっと派手すぎるかなぁ。でも私的にはこのくらい主張強いのも好き！");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("大丈夫、また新しいの買えばいいさ！どんどん使おう！");
                        SelectStack.Push("どうしよう…気に入りすぎて、無くすの怖いからやっぱりやめとこうかな😅");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("もちろん使う！衣装との組み合わせも完璧だから、絶対バッチリ映えると思う💋");
                        SelectStack.Push("OK！メイクさんにも伝えておくよ。これは間違いなく映えるね！");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text3)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("わかるよ。でも今回はVIP枠で君を招待してるから、注目されるチャンスだよ？参加するだけでかなり大きな話題になるはず");
                        SelectStack.Push("ねぇ、マネージャー。今度のイベント、正直行くの面倒だなぁ…😩 行ったほうがいいのは分かってるけど、ちょっと気分が乗らないかも");
                        Debug.Log("テキスト3表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("うーん…まあ仕方ないけど、少しもったいない気もするな");
                        SelectStack.Push("やっぱり行かない！家でゴロゴロしたいの…😤");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("無理は禁物だからね。楽しめる範囲で参加しよう");
                        SelectStack.Push("ん～行くけど、疲れたら途中で帰ってもいい？");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("それがいい！映えスポットも調べておくから、準備は任せて！");
                        SelectStack.Push("それなら行こうかな！映えを狙って、バッチリ決めていく📸");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text4)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("今週はちょっと忙しいけど、来週ならなんとか調整できそうだよ");
                        SelectStack.Push("ねぇ、たまにはしっかり休みたいんだけど、次の休暇っていつ取れるかな？ちょっとリフレッシュしたくて…😌");
                        Debug.Log("テキスト4表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("まぁ、仕方ないな。来週を楽しみにしておこう！");
                        SelectStack.Push("来週かぁ…まぁ、それでもいいかな。仕方ないよね");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("了解！来週は仕事の連絡もなしで、しっかりリフレッシュして");
                        SelectStack.Push("やったー！じゃあ来週は思いっきりのんびりするね～✨");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("今週は無理だけど、ごめんね。来週を楽しみにしてて！");
                        SelectStack.Push("え～今週がいいのにー！なんとかしてくれない？");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text5)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("uそれなら雑談配信とかどう？ファンと直接コミュニケーションを取るいい機会だと思うよ");
                        SelectStack.Push("最近、フォロワーとの距離がちょっと気になってて…もう少し距離を縮めたほうがいいのかな？");
                        Debug.Log("テキスト5表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("いいね！サポートは任せて。きっと盛り上がるよ！");
                        SelectStack.Push("それいいかも！週末に配信やっちゃおうかな🎥");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("楽な方法も探してみるけど、やっぱり配信が一番だと思う");
                        SelectStack.Push("いや、配信はやりたくない…もっと楽な方法ない？");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まぁ、少し大変だけどやってみる価値はあると思うよ");
                        SelectStack.Push("配信って準備がちょっと面倒なんだよなぁ😅");
                        LineButtom.VButtonFlag = false;
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
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("まぁ、どれを選んでも似合うから安心して！");
                        SelectStack.Push("そっか。でも準備もあるし、別の服にしちゃおうかな");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("それだね！映える準備、こっちでしっかり整えておくよ");
                        SelectStack.Push("じゃあこれにする！当日バッチリ決めていくね💃");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("もちろん、当日試してから決めても大丈夫だよ");
                        SelectStack.Push("うーん…着てみてから決めてもいい？");
                        LineButtom.VButtonFlag = false;
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
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("決まりだね！いい観光地をリストアップしておくよ");
                        SelectStack.Push("海外がいい！映えスポットたくさんあるし、写真もいっぱい撮りたい✈️");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("そうだよね。温泉とかもいいし、リラックスできる場所探そう");
                        SelectStack.Push("うーん…国内のほうが移動が楽で助かるなぁ");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まぁ、疲れるのもわかるけど、仕事だし頑張ろうよ」");
                        SelectStack.Push("どっちもパスで。旅行は疲れるから嫌だな😓");
                        LineButtom.VButtonFlag = false;
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
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("気持ちはわかるけど、無視するほうが効果的なことも多いんだ");
                        SelectStack.Push("もう嫌だ…全部消してほしい😢");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("その意気だよ！アンチに負けずに進もう");
                        SelectStack.Push("無視するのが一番だよね。私は私のままでいく💪");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まあ、反応するなら冷静にね。感情的になると良くないから");
                        SelectStack.Push("少しくらい反応したほうがいいのかな？");
                        LineButtom.VButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                }
                else if (LineButtom.Text9)
                {
                    if (LineButtom.FirstText)
                    {
                        SelectStack.Clear();
                        SelectStack.Push("〇〇の新作コスメが今人気みたいだよ。レビューも結構いいって！");
                        SelectStack.Push("最近さ、新しいコスメが欲しいんだけど、何かおすすめないかな？");
                        Debug.Log("テキスト9表示");
                        StartCoroutine(Text());
                        LineButtom.FirstText = false;
                    }
                    if (LineButtom.XButtonFlag)
                    {
                        SelectStack.Push("レビュー楽しみにしてるよ！絶対似合うと思う");
                        SelectStack.Push("買ってみる！試してみるのが楽しみだな💄");
                        LineButtom.XButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.CButtonFlag)
                    {
                        SelectStack.Push("そっか…でも、興味が出たらいつでも試してみて！");
                        SelectStack.Push("うーん、コスメにはあんまり興味ないかも");
                        LineButtom.CButtonFlag = false;
                        StartCoroutine(Text2());
                    }
                    else if (LineButtom.VButtonFlag)
                    {
                        SelectStack.Push("まぁ、無理して買わなくてもいいよね");
                        SelectStack.Push("見るだけにしとこうかな…");
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
