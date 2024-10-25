using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineContent : MonoBehaviour
{
    [SerializeField] private RectTransform content;   // Scroll ViewのContent
    [SerializeField] private GameObject LeftPrefab;    // TextMeshProUGUIのPrefab
    [SerializeField] private GameObject RightPrefab;    // TextMeshProUGUIのPrefab
    [SerializeField] private float padding = 10f;     // 各要素の間隔

    const int DIGIT = 14;

    /// <summary>
    /// TextMeshProのテキストを動的に追加する
    /// </summary>
    public void AddToLeftText(string message)
    {
        // TextMeshProUGUIのPrefabをContentの子として生成
        GameObject newText = Instantiate(LeftPrefab, content);

        // RectTransformコンポーネントを取得
        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            // 全体の幅を600に設定
            rectTransform.sizeDelta = new Vector2(600, rectTransform.sizeDelta.y);
            rectTransform.anchorMin = new Vector2(0.1f, -1); // 左に揃える
            rectTransform.anchorMax = new Vector2(0.1f, -1);
            rectTransform.pivot = new Vector2(0.1f, 1);     // ピボットも左に揃える
            rectTransform.anchoredPosition = new Vector2(0, rectTransform.anchoredPosition.y);
        }

        Image ImageComponent = newText.GetComponent<Image>();
        ImageComponent.color = new Color(0,0,0);

        string newChat = "";

        while (DIGIT < message.Length)
        {
            //前14行の抜き出し
            newChat += message.Substring(0, DIGIT) + "\n";

            //後の文字を格納
            message = message.Substring(DIGIT);
        }

        // TextMeshProUGUIコンポーネントを取得してテキストを設定
        TextMeshProUGUI tmpComponent = newText.GetComponentInChildren<TextMeshProUGUI>();
        if (tmpComponent != null)
        {
            tmpComponent.text = newChat + message;
            tmpComponent.fontSize = 35;                          // フォントサイズを設定
            tmpComponent.alignment = TextAlignmentOptions.Left;  // 左揃え
            tmpComponent.enableWordWrapping = true;              // 自動で単語ごとに改行
            tmpComponent.color = Color.white;
        }

        // レイアウトの更新
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }


    public void AddToRightText(string message)
    {
        // TextMeshProUGUIのPrefabをContentの子として生成
        GameObject newText = Instantiate(RightPrefab, content);

        // RectTransformコンポーネントを取得
        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            //RectTransformのAnchorとPivotを右揃えに設定
            rectTransform.anchorMin = new Vector2(1, 0.5f);  // 右端の中央にAnchorを設定
            rectTransform.anchorMax = new Vector2(1, 0.5f);  // 右端の中央にAnchorを設定
            rectTransform.pivot = new Vector2(0.9f, 0.5f);      // Pivotを右端の中央に設定
            // Prefabの位置を調整
            rectTransform.anchoredPosition = new Vector2(-padding, 0);  // 右端からpadding分だけ左に
        }

        Image ImageComponent = newText.GetComponent<Image>();
        ImageComponent.color = new Color(150f / 255f, 230f / 255f, 150f / 255f);

        string newChat = "";

        while (DIGIT < message.Length)
        {
            //前14行の抜き出し
            newChat += message.Substring(0, DIGIT) + "\n";

            //後の文字を格納
            message = message.Substring(DIGIT);
        }

        // TextMeshProUGUIコンポーネントを取得してテキストを設定
        TextMeshProUGUI tmpComponent = newText.GetComponentInChildren<TextMeshProUGUI>();

        if (tmpComponent != null)
        {
            tmpComponent.text = newChat + message;
            tmpComponent.fontSize = 35;  // フォントサイズを設定
            tmpComponent.alignment = TextAlignmentOptions.Left;  // テキストを左揃え
            tmpComponent.color = Color.black;
        }

        // 画像
        int NumberChar = message.Length / 14;   //行数

        // レイアウトの更新
        LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }
    public void RemoveLastText()
    {
        // 子オブジェクトがあるか確認
        if (content.childCount > 0)
        {
            // 最後の子オブジェクトを取得
            Transform lastChild = content.GetChild(content.childCount - 1);

            // オブジェクトを削除
            Destroy(lastChild.gameObject);

            // レイアウトの再構築を強制
            LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        }
        else
        {
            Debug.Log("Contentに削除する要素がありません。");
        }
    }




}