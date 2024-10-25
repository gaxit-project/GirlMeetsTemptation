using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public static Scene Instance = null;
    public static Scene GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<Scene>();
        }
        return Instance;
    }
    private void Awake()
    {
        if (this != GetInstance())
        {
            Destroy(this.gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClearGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameClear");
    }
    public void TitleGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
    public void MainGame(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("main");
    }
    public void EndGame() //Quit
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameover");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    
}
