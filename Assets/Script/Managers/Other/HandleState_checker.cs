// 確認是否使用手把的判斷器（推薦利用按鍵去確認）
// 請需要呼叫的人在 Awake 自動抓 HandleState_passer 這個 class
// （寫入）紀錄是否使用手把：SetIsHandle(bool set)
// （輸出）呼叫紀錄值：GetIsHandle()
// true：用手把 flase：用鍵盤
// 無法根據左右鍵或搖桿去判斷是否使用手把

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandleState_checker : MonoBehaviour
{

    [SerializeField] private bool isUseHandle;
    [SerializeField] int passerCounter = 0;

    private bool isLoadMainScene, isLoadLevel0;
    // Start is called before the first frame update
    void Start()
    {
        isUseHandle = GameManager.instance.GetIsUseHandle();
    }

    // Update is called once per frame
    void Update()
    {
        CheckUserInput();
    }


    void Awake()
    {
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("handle_passer");


        // HandleState_passer[] objs = GameObject.FindObjectsOfType<HandleState_passer>();
        // passerCounter = objs.Length;
        // if (objs.Length > 1)
        // {
        //     Destroy(this.gameObject);
        // }

        // DontDestroyOnLoad(this.gameObject);
    }


    // //////////

    private void SetIsHandle(bool set)
    {
        GameManager.instance.SetIsUseHandle(set);
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

    private void CheckUserInput()
    {
        // _inputH = Input.GetAxisRaw("Horizontal");
        // _inputV = Input.GetAxisRaw("Vertical");

        if (isUseHandle)
        {
            if (Input.GetKeyDown(KeyCode.W) ||
                Input.GetKeyDown(KeyCode.A) ||
                Input.GetKeyDown(KeyCode.S) ||
                Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.Q) ||
                Input.GetKeyDown(KeyCode.E) ||
                Input.GetKeyDown(KeyCode.R) ||
                Input.GetKeyDown(KeyCode.F) ||
                Input.GetKeyDown(KeyCode.C) ||
                Input.GetKeyDown(KeyCode.LeftArrow) ||
                Input.GetKeyDown(KeyCode.RightArrow) ||
                Input.GetKeyDown(KeyCode.DownArrow)
                    ) SetIsHandle(false);
        }
        else
        {
            if (Input.GetButtonDown("X") ||
                Input.GetButtonDown("Y") ||
                Input.GetButtonDown("A") ||
                Input.GetButtonDown("B") ||
                Input.GetButtonDown("LB") ||
                Input.GetButtonDown("Xbox_menu")
                    ) SetIsHandle(true);

            // if (!(!(Input.GetAxisRaw("Horizontal") == 0) &&
            //     (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            //         ) SetIsHandle(true);
        }
    }

}
