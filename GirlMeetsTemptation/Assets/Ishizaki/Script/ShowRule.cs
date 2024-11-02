using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowRule : MonoBehaviour
{
    public GameObject ruleCanvas;
    public GameObject[] slides;
    public GameObject canvas;
    private int currentSlide = 0;
    private bool isShowingRules = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartShowRule()
    {
        // �X�^�[�g�{�^���������ꂽ�烋�[��������\��
        canvas.SetActive(false);
        ruleCanvas.SetActive(true);
        isShowingRules = true;
        ShowSlide(currentSlide);
    }

    void Update()
    {
        // A�{�^�����������Ƃ��Ɏ��̃X���C�h��
        if (isShowingRules && Input.GetButtonDown("Submit"))
        {
            NextSlide();
        }
    }

    void ShowSlide(int index)
    {
        // �S�X���C�h���\���ɂ��A���݂̃X���C�h��\��
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == index);
        }
    }

    void NextSlide()
    {
        if (currentSlide < slides.Length - 1)
        {
            currentSlide++;
            ShowSlide(currentSlide);
        }
        else
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // �Q�[���V�[���ւ̑J��
        Scene.GetInstance().MainGame();
    }
}