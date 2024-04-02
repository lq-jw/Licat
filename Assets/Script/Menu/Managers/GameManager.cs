using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private float bgmVolume, seVolume;
    [SerializeField] private bool isFirstGame, isNewGame;
    
    void Awake()
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
    void Start()
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
        isFirstGame = true;
        isNewGame = false;
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
