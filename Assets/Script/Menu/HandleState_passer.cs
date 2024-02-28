// 確認是否使用手把的判斷器（推薦利用按鍵去確認）
// 請需要呼叫的人在 Awake 自動抓 HandleState_passer 這個 class
// （寫入）紀錄是否使用手把：SetIsHandle(bool set)
// （輸出）呼叫紀錄值：GetIsHandle()
// true：用手把 flase：用鍵盤
// 暫時設定如果不在menu或第0關會刪掉，需要可以再改

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleState_passer : MonoBehaviour
{

    [SerializeField] private bool isUseHandle;
    [SerializeField] int passerCounter = 0;

    private bool isLoadMainScene, isLoadLevel0;
    // Start is called before the first frame update
    void Start()
    {
        isUseHandle = false;
        // gameObject.tag = "handle_passer";
    }

    // Update is called once per frame
    void Update()
    {
        CheckIsShouldDestroy();
        // ＾不想讓他自刪的話就不要這行函式
    }


    void Awake()
    {
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("handle_passer");
        HandleState_passer[] objs = GameObject.FindObjectsOfType<HandleState_passer>();
        passerCounter = objs.Length;
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }


    // //////////

    public bool GetIsHandle()
    {
        return isUseHandle;
    }

    public void SetIsHandle(bool set)
    {
        isUseHandle = set;
    }



    private bool CheckIsSceneLoaded(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);

        // 检查场景是否有效并且已经被加载
        return scene.IsValid() && scene.isLoaded;
    }

    private void CheckIsShouldDestroy()
    {
        // 如果場景不是mainScene或level 0就刪掉
        isLoadMainScene = CheckIsSceneLoaded("MainScene");
        isLoadLevel0 = CheckIsSceneLoaded("Level_0");
        if (!(isLoadMainScene || isLoadLevel0))
        {
            Destroy(this.gameObject);
        }
    }
}
