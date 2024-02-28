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

    // Update is called once per frame
    public void LoadScene(string levelToLoad, bool loadPause = false)
    {
        Debug.Log("start loading.");
        Loading_screen.SetActive(true);
        Debug.Log("open loading screen.");
        StartCoroutine(LoadLevelASync(levelToLoad, loadPause));
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
