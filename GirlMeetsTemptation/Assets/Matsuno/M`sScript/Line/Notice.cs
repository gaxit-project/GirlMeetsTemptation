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

    // Start is called before the first frame update
    void Start()
    {
        FirstTaskText = false;
        Phone.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (/*�X�}�z���J���Ă��Ȃ��Ƃ� && NoticeFlag &&*/ !ManeLineTaskFlagON && !test)
        {
            // ���݂̃R���[�`�������s���Ȃ��~����
            if (ActiveCoroutine == null)
            {
                Debug.Log("�R���[�`���J�n");
                // �V�����R���[�`�����J�n���A���̎Q�Ƃ�ۑ�����
                ActiveCoroutine = StartCoroutine(Timer());
            }
        }
        else
        {
            // ���݂̃R���[�`�������s���Ȃ��~����
            if (ActiveCoroutine != null)
            {
                StopCoroutine(ActiveCoroutine);
            }
            //Phone.SetActive(false);
        }
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(7.5f);
        Debug.Log("�́[�����t���O�I���I");
        //�e�X�g�̂��ߌ�Ő�΂Ƀt���O�������K�v����
        test = true;
        NoticeFlag = true;
        NoticeCnt = Random.Range(1, 2);
        FirstTaskText = true;

        Phone.SetActive(true);

        if (NoticeCnt == 1)
        {
            ManeLineTaskFlagON = true;
            TaskNoticeText.text = "�}�l�[�W���[�����BYEN�ʒm";
        }
        else if(NoticeCnt == 2)
        {
            Tomodati1TaskFlagON = false;
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
