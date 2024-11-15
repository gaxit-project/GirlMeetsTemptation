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
    private opening opening;

    // Start is called before the first frame update
    void Start()
    {
        opening = FindObjectOfType<opening>();
    }

    public void StartShowRule()
    {
        // �X�^�[�g�{�^���������ꂽ�烋�[��������\��
        canvas.SetActive(false);
        ruleCanvas.SetActive(true);
        isShowingRules = true;
        if (opening != null)
        {
            opening.enabled = false;
        }
        Audio.GetInstance().StopLoopSound();
        ShowSlide(currentSlide);
    }

    void Update()
    {
        // A�{�^�����������Ƃ��Ɏ��̃X���C�h��
        if (isShowingRules && Input.GetButtonDown("Submit"))
        {
            NextSlide();
        }else if(!isShowingRules && Input.GetButtonDown("Submit"))
        {
            StartShowRule();
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
        currentSlide++;
        if (currentSlide < slides.Length)
        {
            ShowSlide(currentSlide);
            
        }
        else
        {
            Scene.GetInstance().MainGame();
        }
    }

    


}
