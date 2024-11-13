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
        Audio.GetInstance().StopLoopSound();
        deadmes(messageToDisplay);
        //// �ŏ��ɑI������{�^����ݒ�
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

    // ���b�Z�[�W��ݒ肷�郁�\�b�h�imain�V�[������Ăяo���j
    public static void SetMessage(string mes)
    {
        messageToDisplay = mes;
    }

    // ���b�Z�[�W��\�����郁�\�b�h
    public void deadmes(string mes)
    {
        if (gameOverText != null)
        {
            gameOverText.text = mes;
        }
        else
        {
            Debug.LogWarning("gameOverText �����蓖�Ă��Ă��܂���B");
        }
    }
}
