using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMissionManager : MonoBehaviour
{
    public static int CoinSum;
    public static float DistanceSum;

    public Text SubMissionText;


    public static SubMissionManager instance;
    void OnEnable()
    {
        MiniGameManager.SubClear = false;
        if(MiniGameManager.SubMissionID == 1)
        {
            //�R�C���̖���
            CoinSum = Random.Range(3, 6);
        }
        else if(MiniGameManager.SubMissionID == 2)
        {
            //���鋗��
            DistanceSum = Random.Range(30f, 60f);
        }
    }


    void Update()
    {
        //�f�o�b�O�p
        if(Input.GetKeyDown("o"))
        {
            MiniGameManager.CoinCount++;
        }





        if (MiniGameManager.SubMissionID == 0)//�T�u�~�b�V��������
        {
            SubMissionText.text = "";
        }
        else if (MiniGameManager.SubMissionID == 1)//�R�C���l���~�b�V����
        {
            SubMissionText.text = "�R�C�� : " + MiniGameManager.CoinCount + " / " + CoinSum;
            if (MiniGameManager.CoinCount >= CoinSum)
            {
                MiniGameManager.SubClear = true;
                SubMissionText.text = "�~�b�V����\n�B��";
            }
        }
        else if(MiniGameManager.SubMissionID == 2)//���鋗���~�b�V����
        {

        }
    }
}
