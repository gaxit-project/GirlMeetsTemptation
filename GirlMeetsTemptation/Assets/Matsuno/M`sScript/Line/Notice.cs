using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Notice : MonoBehaviour
{
    public static bool NoticeFlag = false;
    private Coroutine ActiveCoroutine;
    public static int NoticeCnt;
    public static bool FirstTaskText = false;
    public static bool ManeLineTaskFlagON = false;
    public static bool Tomodati1TaskFlagON = false;
    bool test = false;
    [SerializeField] GameObject Phone;
    [SerializeField] TextMeshProUGUI TaskNoticeText;

    bool Task1 = true;
    bool Task2 = true;

    bool TaskFirstFlag = true;

    // Start is called before the first frame update
    void Start()
    {
        FirstTaskText = false;
        Phone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("�^�X�N�t���O����" + TaskFirstFlag);

        if (PlayerMovement.PhoneONTaskFlag && !ManeLineTaskFlagON && TaskFirstFlag)
        {
            // �R���[�`�������s���łȂ��ꍇ�̂݊J�n����
            if (ActiveCoroutine == null)
            {
                if(Task1)
                {
                    Debug.Log("�R���[�`���J�n");
                    ActiveCoroutine = StartCoroutine(Timer());
                }
                
                TaskFirstFlag = false;
            }
        }
        else if(!PlayerMovement.PhoneONTaskFlag)
        {
            // �����ꂩ�̏������������Ȃ��ꍇ�A�R���[�`�����~����
            if (ActiveCoroutine != null)
            {
                StopCoroutine(ActiveCoroutine);
                ActiveCoroutine = null;
                Debug.Log("�R���[�`���X�g�b�v");
                TaskFirstFlag = true;
                Phone.SetActive(false);
            }
        }
    }


    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(7.5f);
        Debug.Log("�́[�����t���O�I���I");
        NoticeFlag = true;
        NoticeCnt = Random.Range(1, 2);
        FirstTaskText = true;

        Phone.SetActive(true);

        if (NoticeCnt == 1)
        {
            ManeLineTaskFlagON = true;
            Task1 = false;
            TaskNoticeText.text = "�}�l�[�W���[�����BYEN�ʒm";
        }
        else if(NoticeCnt == 2)
        {
            Tomodati1TaskFlagON = false;
            Task2 = false;
            TaskNoticeText.text = "�F�B�����BYEN�ʒm";
        }
        else if (NoticeCnt == 3)
        {
            ManeLineTaskFlagON = true;
            TaskNoticeText.text = "�}�l�[�W���[�����BYEN�ʒm";
        }
        else if (NoticeCnt == 4)
        {
            //�F�B���C���^�X�N�t���O
        }
        else if (NoticeCnt == 5)
        {
            //�F�B���C���^�X�N�t���O
        }
        else if (NoticeCnt == 6)
        {
            //�F�B���C���^�X�N�t���O
        }
        else if (NoticeCnt == 7)
        {
            
        }
        else if (NoticeCnt == 8)
        {
            
        }
        else if (NoticeCnt == 9)
        {

        }
    }
}
