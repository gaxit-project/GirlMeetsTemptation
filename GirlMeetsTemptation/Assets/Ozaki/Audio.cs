using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip[] SE;  // 効果音の配列
    private AudioSource bgmSource;    // SE[0] 用の AudioSource（ループ専用）
    private AudioSource seSource;     // その他の効果音用の AudioSource
    public Button upButton;
    public Button downButton;
    private float volumeStep = 0.05f;
    public static Audio Instance = null;  // シングルトンインスタンス
    //

    // シングルトンの実装
    private void Awake(){
        if(this != GetInstance()){
            Destroy(this.gameObject);  // 他のインスタンスがある場合は破棄
            return;
        }
        DontDestroyOnLoad(this.gameObject);  // シーンを跨いでもオブジェクトを保持

    }

    void Start()
    {
        // SE[0] 用の AudioSource
        if (bgmSource == null)
        {
            bgmSource = gameObject.AddComponent<AudioSource>();
            bgmSource.playOnAwake = false;
            bgmSource.volume = 0.5f;
        }

        // 他の効果音用の AudioSource
        if (seSource == null)
        {
            seSource = gameObject.AddComponent<AudioSource>();
            seSource.playOnAwake = false;
            seSource.volume = 0.5f;
        }

        if (upButton != null)
        {
            upButton.onClick.AddListener(IncreaseVolume);
        }

        if (downButton != null)
        {
            downButton.onClick.AddListener(DecreaseVolume);
        }
    }
    
    // 音量を上げるメソッド
    private void IncreaseVolume()
    {
        bgmSource.volume = Mathf.Clamp(bgmSource.volume + volumeStep, 0, 1);
        seSource.volume = Mathf.Clamp(seSource.volume + volumeStep, 0, 1);
    }

    // 音量を下げるメソッド
    private void DecreaseVolume()
    {
        bgmSource.volume = Mathf.Clamp(bgmSource.volume - volumeStep, 0, 1);
        seSource.volume = Mathf.Clamp(seSource.volume - volumeStep, 0, 1);
    }

    // サウンドを再生するメソッド
    public void PlaySound(int index){

        if ((index == 0 || index == 6 || index == 7 || index == 8 || index == 9 || index == 10 || index == 11 || index == 12) && index >= 0 && index < SE.Length){
            // SE[0] をループ再生する
            bgmSource.clip = SE[index];
            bgmSource.loop = true;
            if (!bgmSource.isPlaying)  // 再生中でなければ再生
            {
                bgmSource.Play();
            }
        }
        else if (index > 0 && index < SE.Length){
            // その他の効果音を再生
            seSource.PlayOneShot(SE[index]);
        }
    }
    public bool IsPlayingSound(int index)
    {
        return bgmSource.isPlaying && bgmSource.clip == SE[index];
    }

    // SE[0] の再生を停止するメソッド
    public void StopLoopSound(){
        bgmSource.loop = false;  // ループを無効にする
        bgmSource.Stop();        // 再生を停止
    }

    // インスタンスを取得するメソッド
    public static Audio GetInstance(){
        if(Instance == null){
            Instance = FindObjectOfType<Audio>();
        }
        return Instance;
    }
}
