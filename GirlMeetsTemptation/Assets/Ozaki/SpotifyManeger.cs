using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotifyManager : MonoBehaviour
{
    public GameObject Canvas;
    private PlayerMovement PlayerMovement;
    public Button[] buttons;      // 再生ボタンの配列
    public Button[] stopbuttons;  // 停止ボタンの配列
    //public GameObject Addbutton;  // 追加ボタン
    private bool soundActive = false; // 音が再生中かどうか
    //public bool Addsound = false;  // 追加音声が必要かどうか
    private int selectedIndex = 0; // 選択中のボタンインデックス

    void Start()
    {
        //Addbutton.SetActive(false); // 追加ボタンを非表示
        // 各ボタンの初期設定
        PlayerMovement = FindObjectOfType<PlayerMovement>();
        SetUpButtons(buttons, OnPlayButtonClick);
        SetUpButtons(stopbuttons, OnStopButtonClick);
        UpdateButtonSelection();
        ShowButtons(true, -1); // 初期状態で再生ボタンを表示、停止ボタンを非表示
    }

    private void SetUpButtons(Button[] buttonArray, UnityEngine.Events.UnityAction<int> action)
    {
        for (int i = 0; i < buttonArray.Length; i++)
        {
            int index = i; // クロージャ問題を防ぐためのローカルコピー
            buttonArray[i].onClick.AddListener(() => action(index));
        }
    }
    /*private void ADDSetUpButtons(Button[] buttonArray, UnityEngine.Events.UnityAction<int> action)
    {
        for (int i = 0; i < buttonArray.Length; i++)
        {
            int index = i; // クロージャ問題を防ぐためのローカルコピー
            buttonArray[i].onClick.AddListener(() => action(index));
        }
    }*/
    private void UpdateButtonSelection()
    {
        // 現在表示されているボタンを取得
        Button[] currentButtons = soundActive ? stopbuttons : buttons;

        // ボタンの色を更新
        for (int i = 0; i < buttons.Length; i++)
        {
            ColorBlock buttonColors = buttons[i].colors;
            buttonColors.normalColor = (i == selectedIndex && !soundActive) ? Color.yellow : Color.white;
            buttons[i].colors = buttonColors;
        }
        for (int i = 0; i < stopbuttons.Length; i++)
        {
            ColorBlock stopButtonColors = stopbuttons[i].colors;
            stopButtonColors.normalColor = (i == selectedIndex && soundActive) ? Color.yellow : Color.white;
            stopbuttons[i].colors = stopButtonColors;
        }
    }

    private void OnPlayButtonClick(int index)
    {
        Debug.Log($"再生ボタン {index} がクリックされました");
        soundActive = true;

        // 音声を再生
        /*if (!Addsound)
        {*/
            Audio.GetInstance().PlaySound(10 - index); // 各ボタンに対応したサウンドを再生
        /*}
        else
        {
            Audio.GetInstance().PlaySound(11 - index);
        }*/
        
        ShowButtons(false, index); // 再生ボタンを非表示、停止ボタンを表示
        UpdateButtonSelection();
    }

    private void OnStopButtonClick(int index)
    {
        Debug.Log($"停止ボタン {index} がクリックされました");
        soundActive = false;
        Audio.GetInstance().StopLoopSound();
        Audio.GetInstance().PlaySound(0);
        ShowButtons(true, index); // 停止ボタンを非表示、再生ボタンを表示
        UpdateButtonSelection();
    }

    private void ShowButtons(bool showButtons, int index)
    {
        if (index == -1) return;

        // ボタンの表示・非表示を制御
        if (showButtons)
        {
            if(index <=3){
            buttons[index].gameObject.SetActive(true);
            stopbuttons[index].gameObject.SetActive(false);
            }
        }
        else
        {
            if(index <=3){
            buttons[index].gameObject.SetActive(false);
            stopbuttons[index].gameObject.SetActive(true);
            }
        }
    }

    void Update()
    {
        if(PlayerMovement.getphoneOn()){
            Canvas.SetActive(true);
        }else{
            Canvas.SetActive(false);
        }
        // 現在表示されているボタンを取得
        Button[] currentButtons = soundActive ? stopbuttons : buttons;

        // 音が再生中でない場合のみ選択を制御
        if (!soundActive)
        {
            // 上キーで上のボタンを選択
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : currentButtons.Length - 1;
                UpdateButtonSelection();
            }
            // 下キーで下のボタンを選択
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedIndex = (selectedIndex < currentButtons.Length - 1) ? selectedIndex + 1 : 0;
                UpdateButtonSelection();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                selectedIndex = (selectedIndex < currentButtons.Length - 1) ? selectedIndex + 1 : 0;
                UpdateButtonSelection();
            }
        }

        // 追加音声が必要な場合、追加ボタンを表示
        /*if (Addsound)
        {
            Addbutton.SetActive(true);
            ADDSetUpButtons(buttons, OnPlayButtonClick);
            ADDSetUpButtons(stopbuttons, OnStopButtonClick);
        }
        else
        {
            Addbutton.SetActive(false);
        }*/

        // Enterキーで選択中のボタンをクリック
        if (Input.GetKeyDown(KeyCode.Return) && currentButtons.Length > 0)
        {
            currentButtons[selectedIndex].onClick.Invoke(); // 選択中のボタンをクリック
        }
    }
}
