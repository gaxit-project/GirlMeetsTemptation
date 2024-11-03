using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems; // EventSystemの参照

public class MGameOver : MonoBehaviour
{
    public Text gameOverText;
    private static string messageToDisplay;
    public Button Restartbuttons; // ボタンの配列をInspectorで設定
    public Button Titlebuttons; // ボタンの配列をInspectorで設定
    private int selectedIndex = 0; // 選択中のボタンインデックス

    void Start()
    {
        //Audio.GetInstance().StopLoopSound();
        deadmes(messageToDisplay);

        //// 最初に選択するボタンを設定
        //if (buttons.Length > 0)
        //{
        //    EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        //}
        Restartbuttons.Select();
    }

    void Update()
    {
        // 選択状態の変更はEventSystemに依存するため、コード内で手動操作は不要です
    }


    public void MainGameScene()
    {
        Scene.GetInstance().MainGame();
    }
    public void TitleGameScene()
    {
        Scene.GetInstance().TitleGame();
    }

    // メッセージを設定するメソッド（他のシーンからメッセージを設定する際に呼び出す）
    public static void SetMessage(string mes)
    {
        messageToDisplay = mes;
    }

    // メッセージを表示するメソッド
    public void deadmes(string mes)
    {
        if (gameOverText != null)
        {
            gameOverText.text = mes;
        }
        else
        {
            Debug.LogWarning("gameOverText が割り当てられていません。");
        }
    }
}
