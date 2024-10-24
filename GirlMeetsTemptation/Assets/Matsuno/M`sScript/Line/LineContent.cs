using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LineContent : MonoBehaviour
{
    [SerializeField] private RectTransform content;   // Scroll ViewのContent
    [SerializeField] private GameObject LeftPrefab;    // TextMeshProUGUIのPrefab
    [SerializeField] private GameObject RightPrefab;    // TextMeshProUGUIのPrefab
    [SerializeField] private float padding = 10f;     // 各要素の間隔

    /// <summary>
    /// TextMeshProのテキストを動的に追加する
    /// </summary>
    public void AddToLeftText(string message)
    {
        // TextMeshProUGUIのPrefabをContentの子として生成
        GameObject newText = Instantiate(LeftPrefab, content);

        // RectTransformコンポーネントを取得
        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        //if (rectTransform != null)
        //{
        //    // 全体の幅を600に設定
        //    rectTransform.sizeDelta = new Vector2(600, rectTransform.sizeDelta.y);
        //    rectTransform.anchorMin = new Vector2(0, 1); // 左上に揃える
        //    rectTransform.anchorMax = new Vector2(0, 1);
        //    rectTransform.pivot = new Vector2(0, 1);     // ピボットも左上に揃える
        //}

        // TextMeshProUGUIコンポーネントを取得してテキストを設定
        TextMeshProUGUI tmpComponent = newText.GetComponent<TextMeshProUGUI>();
        if (tmpComponent != null)
        {
            tmpComponent.text = message;
            tmpComponent.fontSize = 35;                          // フォントサイズを設定
            tmpComponent.alignment = TextAlignmentOptions.Left;  // 左揃え
            tmpComponent.enableWordWrapping = true;              // 自動で単語ごとに改行
            tmpComponent.color = Color.black;

            // マージン（余白）を使って文字の表示幅を400に制限
            float totalWidth = 600f;
            float usableWidth = 400f;
            float marginValue = (totalWidth - usableWidth) / 2;  // 左右に均等な余白を設定
            tmpComponent.margin = new Vector4(0, 0, marginValue, 0);  // 左・上・右・下の順
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
            // RectTransformのAnchorとPivotを右揃えに設定
            rectTransform.anchorMin = new Vector2(1, 0.5f);  // 右端の中央にAnchorを設定
            rectTransform.anchorMax = new Vector2(1, 0.5f);  // 右端の中央にAnchorを設定
            rectTransform.pivot = new Vector2(1, 0.5f);      // Pivotを右端の中央に設定

            // Prefabの位置を調整
            rectTransform.anchoredPosition = new Vector2(-padding, 0);  // 右端からpadding分だけ左に
        }

        // TextMeshProUGUIコンポーネントを取得してテキストを設定
        TextMeshProUGUI tmpComponent = newText.GetComponent<TextMeshProUGUI>();
        if (tmpComponent != null)
        {
            tmpComponent.text = message;
            tmpComponent.fontSize = 35;  // フォントサイズを設定
            tmpComponent.alignment = TextAlignmentOptions.Left;  // テキストを左揃え
            tmpComponent.color = Color.black;

            // マージン（余白）を使って文字の表示幅を400に制限
            float totalWidth = 600f;
            float usableWidth = 400f;
            float marginValue = (totalWidth - usableWidth) / 2;  // 左右に均等な余白を設定
            tmpComponent.margin = new Vector4(marginValue, 0, 0, 0);  // 左・上・右・下の順
        }

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