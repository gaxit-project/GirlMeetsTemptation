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
        // スタートボタンが押されたらルール説明を表示
        canvas.SetActive(false);
        ruleCanvas.SetActive(true);
        isShowingRules = true;
        ShowSlide(currentSlide);
    }

    void Update()
    {
        // Aボタンを押したときに次のスライドへ
        if (isShowingRules && Input.GetButtonDown("Submit"))
        {
            NextSlide();
        }
    }

    void ShowSlide(int index)
    {
        // 全スライドを非表示にし、現在のスライドを表示
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == index);
        }
    }

    void NextSlide()
    {
        if (currentSlide < slides.Length)
        {
            ShowSlide(currentSlide);
            currentSlide++;
        }
        else
        {
            StartGame();
        }
    }

    void StartGame()
    {
        // ゲームシーンへの遷移
        Scene.GetInstance().MainGame();
    }
}
