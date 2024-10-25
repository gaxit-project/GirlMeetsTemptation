using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [Header("�ݒ�")]
    //�����Q�[�W
    public static bool islunatic = false;
    //�~�j�Q�[�����J����Ă��邩
    public static bool isOpen = false;
    //�~�j�Q�[�����J�n���Ă��邩
    public static bool isStart = false;
    //�~�j�Q�[��
    public GameObject MiniGame;
    //�~�j�Q�[��UI
    public GameObject MiniGameUI;
    //�~�j�Q�[��Map
    public MapGen MapGen;





    //���S���̎��
    //0 :�����Ȃ� 
    //1 :����
    //2 :�Ԃ̏Փ�
    //3 :���ォ��̗�����(������)
    public static int MiniDeathID = 0;

    public static MiniGameManager instance;


    void Start()
    {
        //Time.timeScale = 0.0f;
        MiniDeathID = 0;
        MapGen.InitMapGen();

    }

    void Update()
    {
        if (isOpen)
        {
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MapGen.InitMapGen();
        }
        else
        {
            isStart = false;
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
        }

        //�f�o�b�O�p
        if(Input.GetKeyDown("k"))
        {
            if (isOpen)
            {
                isOpen = false;
            }
            else
            {
                isOpen= true;
            }
        }
        if (Input.GetKeyDown("l"))
        {
            if (isStart)
            {
                isStart = false;
            }
            else
            {
                isStart = true;
            }
        }
    }
}
