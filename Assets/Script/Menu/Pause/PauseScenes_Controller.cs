// Pause menu 畫面控制區
// 控制頁面切換、按鈕的功能

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScenes_Controller : MonoBehaviour
{
    [SerializeField] private GameObject Pause_menu, Set_menu, Quit_check, BG, EventSystem, imgHint_keyboard, imgHint_handle;
    [SerializeField] private ASyncLoader Loader;

    [SerializeField] private string now_menu;
    [SerializeField] private bool isPause, isUseHandle;




    // Start is called before the first frame update
    void Start()
    {
        GotoPage("game");
        UpdateHintImg();
        // ASyncLoader Loader = GameObject.FindObjectOfType<ASyncLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        OnEscClick();
    }

    void Awake()
    {
        ASyncLoader Loader = GameObject.FindObjectOfType<ASyncLoader>();
    }

    public bool CheckIsPause()      // 給其他 scene 檢查是否在暫停狀態（但我不確定把控制這個變數的權力）給 pause menu 這樣到底好不好）
    {
        return isPause;
    }

    private void CloseScenes()      // 關閉所有場景，如果有新的scene，要在這裡更新
    {
        Pause_menu.SetActive(false);
        Set_menu.SetActive(false);
        Quit_check.SetActive(false);
    }
    private void GotoPage(string set)      // 切換場景，會關閉場景，更新 now_menu
    {
        now_menu = set;
        CloseScenes();
        BG.SetActive(true);
        switch (now_menu)
        {
            case "game":
                BG.SetActive(false);
                EventSystem.SetActive(false);
                isPause = false;
                break;
            case "pause":
                Pause_menu.SetActive(true);
                EventSystem.SetActive(true);
                isPause = true;
                break;
            case "set":
                Set_menu.SetActive(true);
                isPause = true;
                break;
            case "quit":
                Quit_check.SetActive(true);
                isPause = true;
                break;
            default:
                break;
        }
    }

    private void GoBack()       // menu中的各頁回到上一頁
    {
        GotoPage("pause");
    }

    private void OnEscClick()       // menu中的esc事件
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Xbox_menu"))
        {
            UpdateHintImg();
            switch (now_menu)
            {
                case "game":
                    AudioManager.instance.PlaySE("menu_close");     // 音效
                    GotoPage("pause");
                    break;
                case "pause":
                    AudioManager.instance.PlaySE("menu_close");     // 音效
                    GotoPage("game");
                    break;
                case "set":
                    GotoPage("pause");
                    break;
                case "quit":
                    GotoPage("pause");
                    break;
                default:
                    break;
            }
        }
    }

    /////////////////////////////////////////////////////////
    // menu 按鈕控制、事件

    public void BtnOnClick(int index, int mode = 0)
    {
        // Debug.Log(now_menu + " " + index);
        BtnEvent(index, mode);
    }

    private void BtnEvent(int btnIndex, int mode)
    {
        if (isPause)
        {
            switch (now_menu)
            {
                case "pause":
                    PauseMenuBtnEvent(btnIndex, mode);
                    break;
                case "set":
                    SetMenuBtnEvent(btnIndex, mode);
                    break;
                case "quit":
                    QuitMenuBtnEvent(btnIndex, mode);
                    break;
                default:
                    break;
            }
        }
    }

    private void PauseMenuBtnEvent(int btnIndex, int mode)
    {
        if (mode == 0)
        {
            switch (btnIndex)
            {
                case 0:
                    GotoPage("game");
                    break;
                case 1:
                    GotoPage("set");
                    break;
                case 2:
                    GameSaveAndBackToMain();
                    break;
                default:
                    break;
            }
        }
    }

    private void SetMenuBtnEvent(int btnIndex, int mode)
    {
        switch (mode)
        {
            case 0:
                switch (btnIndex)
                {
                    case 4:
                        GoBack();
                        break;
                    default:
                        break;
                }
                break;
            case 1:
                switch (btnIndex)
                {
                    case 0:
                        Debug.Log("-");
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
                break;
            case 2:
                switch (btnIndex)
                {
                    case 0:
                        Debug.Log("+");
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }

    }

    private void QuitMenuBtnEvent(int btnIndex, int mode)
    {
        if (mode == 0)
        {
            switch (btnIndex)
            {
                case 0:
                    BackToMainMenu();
                    break;
                case 1:
                    GoBack();
                    break;
                default:
                    break;
            }
        }
    }

    private void GameSaveAndBackToMain()
    {
        GameSave();
    }

    private void GameSave()
    {
        Debug.Log("Save Game");
        GotoPage("quit");
    }

    private void BackToMainMenu()
    {
        Debug.Log("BackToMainMenu");
        if (Loader != null)
        {
            Loader.LoadScene("MainScene");
        }
        else
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    private void UpdateHintImg()
    {       // 用於根據 handle 顯示對應教學圖片，以 game manager 為主
        if (isUseHandle != GameManager.instance.GetIsUseHandle())
        {
            isUseHandle = GameManager.instance.GetIsUseHandle();
        }
        if (isUseHandle)
        {
            // 用手把
            imgHint_handle.SetActive(true);
            imgHint_keyboard.SetActive(false);
        }
        else
        {
            // 用鍵盤
            imgHint_handle.SetActive(false);
            imgHint_keyboard.SetActive(true);
        }
    }

}
