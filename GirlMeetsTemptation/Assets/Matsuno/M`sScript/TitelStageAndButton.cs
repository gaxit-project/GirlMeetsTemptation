using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TitleStageAndButton : MonoBehaviour
{
    // Start is called before the first frame update
    int StageSize = 15;
    int StageIndex;
    public Transform Target;//Unitychan
    public GameObject[] stagenum;//�X�e�[�W�̃v���n�u
    private int aheadStage = 4; //���O�ɐ������Ă����X�e�[�W
    public int totalStages; // ��������X�e�[�W�̑���
    public List<GameObject> StageList = new List<GameObject>();//���������X�e�[�W�̃��X�g


    [SerializeField] Button StartButton;

    //���[�������p
    public ShowRule rule;
    public GameObject RuleCanvas;

    void Start()
    {
        StartButton.Select();
        StageManager(aheadStage);

        RuleCanvas.SetActive(false);
        
    }
    void MainGameScene()
    {
        Scene.GetInstance().MainGame();
    }
    void QuitGameScene()
    {
        Scene.GetInstance().QuitGame();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 1F, Space.World);
        int targetPosIndex = (int)(Target.position.z / StageSize);
        if (targetPosIndex + aheadStage > StageIndex)
        {
            StageManager(targetPosIndex + aheadStage);
        }
        //// �L�[���͂Ń{�^���̑I����؂�ւ�
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : buttons.Length - 1;
        //    UpdateButtonSelection();
        //}
        //else if (Input.GetKeyDown(KeyCode.D))
        //{
        //    selectedIndex = (selectedIndex < buttons.Length - 1) ? selectedIndex + 1 : 0;
        //    UpdateButtonSelection();
        //}
        //else if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    buttons[selectedIndex].onClick.Invoke(); // �I�𒆂̃{�^�����N���b�N
        //}
    }

    public void StartKey()
    {
        rule.StartShowRule();
    }
    void StageManager(int maps)
    {
        if (maps <= StageIndex)
        {
            return;
        }


        for (int i = StageIndex + 1; i <= maps; i++)//�w�肵���X�e�[�W�܂ō쐬����
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 1)//�Â��X�e�[�W���폜����
        {
            DestroyStage();
        }

        StageIndex = maps;
    }
    GameObject MakeStage(int index)//�X�e�[�W�𐶐�����
    {
        GameObject stageObject = (GameObject)Instantiate(stagenum[0], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;
    }

    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        Destroy(oldStage);
    }
}

