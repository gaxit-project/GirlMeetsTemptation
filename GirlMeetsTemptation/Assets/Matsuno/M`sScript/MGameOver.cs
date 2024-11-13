using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems; // EventSystem�̎Q��

public class MGameOver : MonoBehaviour
{
    public Text gameOverText;
    private static string messageToDisplay;
    public Button Restartbuttons; // �{�^���̔z���Inspector�Őݒ�
    public Button Titlebuttons; // �{�^���̔z���Inspector�Őݒ�
    private int selectedIndex = 0; // �I�𒆂̃{�^���C���f�b�N�X

    void Start()
    {
        //Audio.GetInstance().StopLoopSound();
        deadmes(messageToDisplay);
        Audio.GetInstance().StopLoopSound();

        //// �ŏ��ɑI������{�^����ݒ�
        //if (buttons.Length > 0)
        //{
        //    EventSystem.current.SetSelectedGameObject(buttons[0].gameObject);
        //}
        Restartbuttons.Select();
    }

    void Update()
    {
        // �I����Ԃ̕ύX��EventSystem�Ɉˑ����邽�߁A�R�[�h���Ŏ蓮����͕s�v�ł�
    }


    public void MainGameScene()
    {
        Scene.GetInstance().MainGame();
    }
    public void TitleGameScene()
    {
        Scene.GetInstance().TitleGame();
    }

    // ���b�Z�[�W��ݒ肷�郁�\�b�h�i���̃V�[�����烁�b�Z�[�W��ݒ肷��ۂɌĂяo���j
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
