using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class FameManager : MonoBehaviour
{
    public Image Fgauge; //�����Q�[�W�摜
    private float Fscore = 0f; //�����Q�[�W�������p�ϐ�
    private float TimePerScore = 0.03f / 5f; //5�b��3%�̌���

    void Start()
    {
        Fgauge.fillAmount = 0.5f;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.U))
        {
            UpFgauge(10);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            DownFgauge(10);
        }
        
        Fscore -= TimePerScore * Time.deltaTime;

        Fgauge.fillAmount += Fscore;
        Fscore = 0f;
    }

    //����p�֐�

    //Fgauge�������Ŏw�肵�������������₷(����0�`100)
    public void UpFgauge(int score)
    {
        Fscore = score * 0.01f;
    }

    //Fgauge�������Ŏw�肵�������������炷(����0�`100)
    public void DownFgauge(int score)
    {
        Fscore = score * -0.01f;
    }
}
