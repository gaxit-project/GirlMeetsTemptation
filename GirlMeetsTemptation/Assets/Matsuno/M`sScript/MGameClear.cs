using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MGameClear : MonoBehaviour
{
    public Text gameOverText;
    private static string messageToDisplay;
    public Button Restartbutton;
    public Button Titlebutton;

    void Start()
    {
        //Audio.GetInstance().StopLoopSound();
        deadmes(messageToDisplay);

        //// 最初に選択するボタンを設定
        //if (buttons.Length > 0)
        //{
        //    EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        //}
        Restartbutton.Select();
    }

    public void MainGameScene()
    {
        Scene.GetInstance().MainGame();
    }
    public void TitleGameScene()
    {
        Scene.GetInstance().TitleGame();
    }

    // メッセージを設定するメソッド（mainシーンから呼び出す）
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
