using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject GoalObjext;
    float distanceOfPlayer;
    float currentDistance;
    float StartDistanceOfPlayer;
    //Slider������
    public Slider slider;

    void Start()
    {
        StartDistanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        //Slider�𖞃^���ɂ���B
        slider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�ƃS�[���܂ł̋����̌v�Z
        distanceOfPlayer = Vector3.Distance(Player.transform.position, GoalObjext.transform.position);
        Debug.Log("�S�[���܂ł̋���:" + distanceOfPlayer);

        //if(/*�}�b�v���J���t���O���I���̎�*/)
        //{
            //(float)������float�̕ϐ��Ƃ��ĐU���킹��B
            slider.value = distanceOfPlayer / StartDistanceOfPlayer;
        //}
    }
}
