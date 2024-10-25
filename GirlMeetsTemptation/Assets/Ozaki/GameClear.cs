using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameClear : MonoBehaviour
{
    public Button[] buttons; // ボタンの配列をInspectorで設定
    private int selectedIndex = 0; // 選択中のボタンインデックス

    void Start()
    {
        Audio.GetInstance().StopLoopSound();
        SetUpButton(0, MainGameScene);
        SetUpButton(1, TitleGameScene);

        UpdateButtonSelection();
    }
    void Update(){
        // キー入力でボタンの選択を切り替え
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : buttons.Length - 1;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            selectedIndex = (selectedIndex < buttons.Length - 1) ? selectedIndex + 1 : 0;
            UpdateButtonSelection();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            buttons[selectedIndex].onClick.Invoke(); // 選択中のボタンをクリック
        }
    }
    private void UpdateButtonSelection()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            ColorBlock colors = buttons[i].colors;
            colors.normalColor = (i == selectedIndex) ? Color.yellow : Color.white;
            buttons[i].colors = colors;
        }
    }
    private void SetUpButton(int index, UnityEngine.Events.UnityAction action)
    {
        if (index < buttons.Length)
        {
            buttons[index].onClick.AddListener(action);
        }
    }
    void MainGameScene()
    {
        Scene.GetInstance().MainGame();
    }
    void TitleGameScene()
    {
        Scene.GetInstance().TitleGame();
    }
}
