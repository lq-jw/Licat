using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenningScenes_Controller : MonoBehaviour
{

    [SerializeField] private GameObject Openning_scene;

    // Start is called before the first frame update
    void Start()
    {
        Openning();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    ////////////////////////////////////////////////////////////////////

    private void CloseScenes()      // 關閉所有場景，如果有新的scene，要在這裡更新
    {
        Openning_scene.SetActive(false);
    }

    private void Openning()      // 開始的 function
    {
        CloseScenes();
        Openning_scene.SetActive(true);
    }

    private void CheckInput()      // 開始後，檢查是否有任何輸入
    {
        if (Openning_scene.activeSelf && Input.anyKeyDown)
        {
            GoToMain();
        }
    }

    private void GoToMain()      // 前往標題畫面
    {
        SceneManager.LoadScene("MainScene");
    }

        private void OnEscClick()      // 前往標題畫面
    {
        SceneManager.LoadScene("MainScene");
    }

    private void GameQuit()      // 離開遊戲
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

}
