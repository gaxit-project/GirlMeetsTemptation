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

    public static bool Task1 = true;
    public static bool Task2 = true;
    public static bool Task3 = true;
    public static bool Task4 = true;


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
                Debug.Log("�R���[�`���J�n");
                ActiveCoroutine = StartCoroutine(Timer());
                TaskFirstFlag = false;
            }
        }
        else if (!PlayerMovement.PhoneONTaskFlag)
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

        // �d���`�F�b�N�̂��߂ɁA�g�p�ς݂̒ʒm�ԍ������X�g�ŊǗ����܂��B
        List<int> usedNoticeCounts = new List<int>();

        // �����_���ɐ������ďd�����Ȃ��悤�ɂȂ�܂Ń��[�v���܂��B
        do
        {
            NoticeCnt = Random.Range(1, 5);
        } while (usedNoticeCounts.Contains(NoticeCnt));

        // �I�΂ꂽ�ʒm�ԍ������X�g�ɒǉ����܂��B
        usedNoticeCounts.Add(NoticeCnt);

        NoticeFlag = true;
        FirstTaskText = true;

        Phone.SetActive(true);

        switch (NoticeCnt)
        {
            case 1:
                Tomodati1TaskFlagON = true;
                Task1 = false;
                TaskNoticeText.text = "�F�B�����BYEN�ʒm";
                break;
            case 2:
                Tomodati1TaskFlagON = true;
                Task2 = false;
                TaskNoticeText.text = "�F�B�����BYEN�ʒm";
                break;
            case 3:
                ManeLineTaskFlagON = true;
                Task3 = false;
                TaskNoticeText.text = "�}�l�[�W���[�����BYEN�ʒm";
                break;
            case 4:
                ManeLineTaskFlagON = true;
                Task4 = false;
                TaskNoticeText.text = "�}�l�[�W���[�����BYEN�ʒm";
                break;
        }

    }
}
