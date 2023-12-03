// menu 畫面控制區

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScenes_Controller : MonoBehaviour
{
    [SerializeField] private GameObject Logo, Open, Main_menu, Start_menu, Set_menu, Quit_check;

    [SerializeField] private string now_menu, pre_menu;
    [SerializeField] private bool isFirstGame = true;

    void Start()
    {
        isFirstGame = false;        // 測試用
        SetScenes("open");
        // SetScenes("main");
        pre_menu = now_menu;
    }

    void Update()
    {
        if (Open.activeSelf && Input.anyKeyDown && !(Input.GetKeyDown(KeyCode.Escape))) SetScenes("main");
        OnEscClick();
    }

    private void CloseScenes(string scene = "all")      // 關閉所有場景，如果有新的scene，要在這裡更新
    {
        // switch (scene)
        // {
        //     case "quit":
        //         Quit_check.SetActive(false);
        //         break;
        //     default:
        Open.SetActive(false);
        Main_menu.SetActive(false);
        Start_menu.SetActive(false);
        Set_menu.SetActive(false);
        Quit_check.SetActive(false);
        //         break;
        // }
    }
    private void SetScenes(string set)      // 切換場景，會關閉場景，更新 now_menu
    {
        pre_menu = now_menu;
        now_menu = set;
        CloseScenes();
        switch (now_menu)
        {
            case "open":
                // CloseScenes();
                Logo.SetActive(true);
                Open.SetActive(true);
                break;
            case "main":
                // CloseScenes();
                Logo.SetActive(true);
                Main_menu.SetActive(true);
                break;
            case "start":
                // CloseScenes();
                Logo.SetActive(true);
                Start_menu.SetActive(true);
                break;
            case "set":
                // CloseScenes();
                // Logo.SetActive(false);
                Set_menu.SetActive(true);
                break;
            case "quit":
                // Logo.SetActive(false);
                Quit_check.SetActive(true);
                break;
            default:
                break;
        }
    }

    private void NewGame()     // 開啟新遊戲
    {
        isFirstGame = false;
        print("start new game");
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }

    private void ContinueGame()     // 繼續遊戲
    {
        print("continue game");
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }

    private void GameQuit()      // 離開遊戲
    {
        if (now_menu == "quit")
        {
            Debug.Log("Quit Game");
            Application.Quit();
        }
        else CheckGameQuit();
    }

    private void CheckGameQuit()        // 確認是否要離開遊戲
    {
        SetScenes("quit");
    }

    private void GoBack()       // menu中的各頁回到上一頁
    {
        SetScenes("main");
        // switch (now_menu)
        // {
        //     case "main":
        //         Debug.Log("go back to open");
        //         SetScenes("open");

        //         break;
        //     case "quit":
        //         SetScenes(pre_menu);
        //         break;
        //     default:
        //         SetScenes("main");
        //         break;
        // }

    }

    private void OnEscClick()       // menu中的esc事件
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (now_menu)
            {
                case "open":
                    GameQuit();
                    break;
                case "main":
                    SetScenes("open");
                    break;
                case "start":
                    GoBack();
                    break;
                case "set":
                    GoBack();
                    break;
                case "quit":
                    SetScenes(pre_menu);
                    break;
                default:
                    break;
            }
        }
    }

    public void BtnOnClick(int index, int mode = 0)
    {
        // Debug.Log(now_menu + " " + index);
        BtnEvent(index, mode);
    }

    private void BtnEvent(int btnIndex, int mode)
    {
        switch (now_menu)
        {
            case "main":
                MainMenuBtnEvent(btnIndex, mode);
                break;
            case "start":
                StartMenuBtnEvent(btnIndex, mode);
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

    private void MainMenuBtnEvent(int btnIndex, int mode)
    {
        if (mode == 0)
        {
            switch (btnIndex)
            {
                case 0:
                    if (isFirstGame) NewGame();
                    else SetScenes("start");
                    break;
                case 1:
                    SetScenes("set");
                    break;
                case 2:
                    GameQuit();
                    break;
                default:
                    break;
            }
        }
    }

    private void StartMenuBtnEvent(int btnIndex, int mode)
    {
        if (mode == 0)
        {
            switch (btnIndex)
            {
                case 0:
                    ContinueGame();
                    break;
                case 1:
                    NewGame();
                    break;
                case 2:
                    GoBack();
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
                    case 5:
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
                    GameQuit();
                    break;
                case 1:
                    GoBack();
                    break;
                default:
                    break;
            }
        }
    }
}


