using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private float bgmVolume, seVolume;
    [SerializeField] private bool isFirstGame, isNewGame;
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
        isPlayAni = isAfterLoading = isGoingToLoad = false;
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


    // ↓ 動畫用
    public bool GetIsPlayAni()
    {
        return isPlayAni;
    }

    public void SetIsPlayAni(bool set)
    {
        isPlayAni = set;
    }

    public bool GetIsAfterLoading()
    {
        return isAfterLoading;
    }

    public void SetIsAfterLoading(bool set)     //  由動畫那邊指定，loader和handlecheck也有
    {
        isAfterLoading = set;
    }

    public bool GetIsGoingToLoad()
    {
        return isGoingToLoad;
    }

    public void SetIsGoingToLoad(bool set)
    {
        isGoingToLoad = set;
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
