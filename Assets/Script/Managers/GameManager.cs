using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private float bgmVolume, seVolume;
    [SerializeField] private bool isFirstGame, isNewGame, isUseHandle;
    // ↓ 動畫用
    [SerializeField] private bool isPlayAni, isAfterLoading, isGoingToLoad;
    void Awake()    // 建立實例、不要被刪掉、檢查是否重複並刪掉
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        InitData();
    }

    // Start is called before the first frame update
    void Start()    // 開場先更新一下音量
    {
        AudioManager.instance.UpdateVolume();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitData()
    {
        bgmVolume = seVolume = 0.5f;
        // isFirstGame = true;
        // isNewGame = false;
        LeaveAniMode(false);
    }

    // ↓ 設定 set menu 的內容用
    public void SetSettings(string name, float fSet = 0f, string type = "")
    {
        switch (name)
        {
            case "bgmVolume":
                bgmVolume = fSet;
                AudioManager.instance.UpdateVolume();
                break;

            case "seVolume":
                seVolume = fSet;
                AudioManager.instance.UpdateVolume();
                break;

            default:
                break;
        }
    }

    /////////////////////////////////
    public bool GetIsFirstGame()
    {
        return isFirstGame;
    }

    public void SetIsFirstGame(bool set)
    {
        isFirstGame = set;
    }

    public bool GetIsNewGame()
    {
        return isNewGame;
    }

    public void SetIsNewGame(bool set)
    {
        isNewGame = set;
    }

    public bool GetIsUseHandle()
    {
        return isUseHandle;
    }

    public void SetIsUseHandle(bool set)
    {
        isUseHandle = set;
    }


    // ↓ 動畫用，無法由外部設定值（但可取得）
    //   要進入動畫黑邊、淡入淡出，請用 Goto/LeaveAniMode 跟 FadeOut
    //   Loader 會重置（LeaveAniMode(false)）
    public bool GetIsPlayAni()
    {
        return isPlayAni;
    }

    private void SetIsPlayAni(bool set)
    {
        isPlayAni = set;
    }

    public bool GetIsAfterLoading()
    {
        return isAfterLoading;
    }

    private void SetIsAfterLoading(bool set)
    {
        isAfterLoading = set;
    }

    public bool GetIsGoingToLoad()
    {
        return isGoingToLoad;
    }

    private void SetIsGoingToLoad(bool set)
    {
        isGoingToLoad = set;
    }

    public void GotoAniMode(bool mode = false)      // true 淡入，用於關卡開頭的動畫
    {
        Debug.Log("Go to ani mode.");
        switch (mode)
        {
            case false:         // in game
                SetIsAfterLoading(false);
                SetIsGoingToLoad(false);
                break;
            case true:         // fade in
                SetIsAfterLoading(true);
                SetIsGoingToLoad(false);
                break;
            default:        // in game
                SetIsAfterLoading(false);
                SetIsGoingToLoad(false);
                break;
        }
        SetIsPlayAni(true);
    }

    public void LeaveAniMode(bool mode = false)     // true 淡出，用於關卡最尾的動畫
    {
        Debug.Log("Leave ani mode.");
        switch (mode)
        {
            case false:         // in game，也可以用於重置所有設定或無黑帶 Fade out
                SetIsAfterLoading(false);
                SetIsGoingToLoad(false);
                break;
            case true:         // fade out
                SetIsAfterLoading(false);
                SetIsGoingToLoad(true);
                break;
            default:        // in game，也可以用於重置所有設定或無黑帶 Fade out
                SetIsAfterLoading(false);
                SetIsGoingToLoad(false);
                break;
        }
        SetIsPlayAni(false);
    }

    public void FadeOut()       // 淡出至黑色且無黑帶，要做到 Fade in（但所有關卡開始都會淡入，很少有需要的場合），請在觸發淡出後用 LeaveAniMode(false)
    {
        SetIsGoingToLoad(false);
        SetIsPlayAni(false);
        SetIsAfterLoading(true);
    }
    /////////////////////////////////
    public float GetVolume(string name)
    {
        switch (name)
        {
            case "bgmVolume":
                return bgmVolume;

            case "seVolume":
                return seVolume;

            default:
                return -0.1f;
        }
    }
}
