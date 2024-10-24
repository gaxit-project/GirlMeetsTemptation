using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioClip[] SE;  // 効果音の配列
    private AudioSource bgmSource;    // SE[0] 用の AudioSource（ループ専用）
    private AudioSource seSource;     // その他の効果音用の AudioSource
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
        }
    }

    // サウンドを再生するメソッド
    public void PlaySound(int index){

        if (index == 0 && index >= 0 && index < SE.Length){
            // SE[0] をループ再生する
            bgmSource.clip = SE[0];
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
