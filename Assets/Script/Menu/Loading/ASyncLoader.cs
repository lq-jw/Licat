// Loading頁使用
// 需要loading頁的時候，呼叫LoadScene（頁面名字，是否是關卡）
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ASyncLoader : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject Loading_screen;

    // [SerializeField] private float progress = 100, progress_pause = 100;
    // ＾測試用

    // Start is called before the first frame update
    void Start()
    {
        Loading_screen.SetActive(false);
    }


    // void Awake()
    // {
    //     ASyncLoader[] objs = GameObject.FindObjectsOfType<ASyncLoader>();
    //     if (objs.Length > 1)
    //     {
    //         Destroy(this.gameObject);
    //     }
    //     DontDestroyOnLoad(this.gameObject);
    // }

    // 讓他在下個場景載入完成後自動關掉
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Loading_screen.SetActive(false);
        Debug.Log("close loading screen.");
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    // void OnDisable()
    // {
    //     Loading_screen.SetActive(false);        //其實這沒用
    //     Debug.Log("close loading screen.");
    //     Debug.Log("OnDisable");
    //     SceneManager.sceneLoaded -= OnSceneLoaded;
    // }

    // Update is called once per frame
    public void LoadScene(string levelToLoad, bool loadPause = false)
    {
        // GameManager.instance.FadeOut();
        Debug.Log("start loading.");
        Loading_screen.SetActive(true);
        GameManager.instance.LeaveAniMode(false);       // 重置動畫黑邊過場設定
        Debug.Log("open loading screen.");
        StartCoroutine(LoadLevelASync(levelToLoad, loadPause));
        // SceneManager.sceneLoaded += OnSceneLoaded;      // 讓他在下個場景載入完成後自動關掉的監聽
    }

    IEnumerator LoadLevelASync(string levelToLoad, bool loadPause = false)
    {
        bool isnotLoadingPause = true;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        if (loadPause)
        {
            isnotLoadingPause = false;
            AsyncOperation loadPauseOperation = SceneManager.LoadSceneAsync("PauseScene", LoadSceneMode.Additive);
            if (loadPauseOperation.isDone) isnotLoadingPause = true;
        }

        // progress = Mathf.Clamp(loadOperation.progress / 0.9f, 0, 100);
        // progress_pause = Mathf.Clamp01(loadPauseOperation.progress / 0.9f);
        // ＾測試用
        while (!(loadOperation.isDone && isnotLoadingPause))
        {
            yield return null;
        }
    }
}
