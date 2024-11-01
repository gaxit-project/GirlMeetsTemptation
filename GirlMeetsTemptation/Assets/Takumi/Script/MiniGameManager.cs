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
    //�~�j�Q�[�����b�Z�[�WUI
    public GameObject MiniUI;
    //�~�j�Q�[�����b�Z�[�WUI
    public Text Minitext;
    //���C���X�}�zUI
    public GameObject MainPhoneUI;
    //�~�j�Q�[��Map
    public MapGen MapGen;

    float count = 0;

    //�R�C���̖���
    public static int CoinCount = 0;
    //���s����
    public static float RunDistance = 0f;

    // �T�u�~�b�V�������N���A������
    public static bool SubClear = false;

    //���ϐ�
    bool isOnce = false;

    //�T�u�~�b�V�����̎��
    //0 :�����Ȃ� 
    //1 :�R�C���̎擾
    //2 :���鋗��(������)
    public static int SubMissionID = 0;

    //���S���̎��
    //0 :�����Ȃ� 
    //1 :����
    //2 :�Ԃ̏Փ�
    //3 :���ォ��̗�����(������)
    public static int MiniDeathID = 0;

    float time = 0;



    public static MiniGameManager instance;


    void Start()
    {
        MiniDeathID = 0;
        MapGen.InitMapGen();

    }

    void Update()
    {
        if (isOpen)
        {
            if (isStart)
            {
                MiniUI.SetActive(false);
            }
            else
            {
                MiniUI.SetActive(true);
            }

            time += Time.deltaTime;
            int ITime = (int)time;
            if(ITime == 1)
            {
                Minitext.text = "2";
            }
            else if(ITime == 2)
            {
                Minitext.text = "1";
            }
            else if(ITime == 3)
            {
                Minitext.text = "Go!";
            }
            else if(ITime >= 4)
            {
                isStart = true;
            }

            if(MiniDeathID != 0)
            {
                isStart = false;
                Minitext.text = "GameOver";
            }

            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MainPhoneUI.SetActive(false);
            MapGen.InitMapGen();

        }
        else
        {
            Minitext.text = "3";
            time = 0;
            isStart = false;
            MapDestroy();
            MiniGame.SetActive(isOpen);
            MiniGameUI.SetActive(isOpen);
            MainPhoneUI.SetActive(true);
        }

        if (SubClear)
        {
            //�����X�R�A+10
            SubClear = false;
            if (!isOnce)
            {
                //�����X�R�A+10

                //Sound

                StartCoroutine(SubMissionReset());
            }

        }


        //�f�o�b�O�p
        if (Input.GetKeyDown("k"))
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

        if (Input.GetKeyDown("p"))
        {
            SubMissionID = 1;
        }
    }

    IEnumerator SubMissionReset()
    {
        yield return new WaitForSeconds(3);
        SubMissionID = 0;
    }

    void MapDestroy()
    {
        GameObject[] Top = GameObject.FindGameObjectsWithTag("Top");
        foreach (GameObject top in Top)
        {
            Destroy(top);
        }
        GameObject[] Mid = GameObject.FindGameObjectsWithTag("Mid");
        foreach (GameObject mid in Mid)
        {
            Destroy(mid);
        }
        GameObject[] Bot = GameObject.FindGameObjectsWithTag("Bot");
        foreach (GameObject bot in Bot)
        {
            Destroy(bot);
        }
        GameObject[] Human = GameObject.FindGameObjectsWithTag("Human");
        foreach (GameObject human in Human)
        {
            Destroy(human);
        }
        GameObject[] Car = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in Car)
        {
            Destroy(car);
        }
        GameObject[] Meteo = GameObject.FindGameObjectsWithTag("Meteo");
        foreach (GameObject meteo in Meteo)
        {
            Destroy(meteo);
        }
    }
}
