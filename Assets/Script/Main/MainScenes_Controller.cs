// menu 畫面控制區

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScenes_Controller : MonoBehaviour
{
    public GameObject Main_menu;
    public GameObject Open;
    public GameObject Set_menu;
    [SerializeField] private GameObject Achievement_menu, Credit_menu;

    [SerializeField] private string now_menu;

    void Start()
    {
        SetScenes("open");
        // SetScenes("open");
    }

    void Update()
    {
        if (Open.activeSelf && Input.anyKeyDown)
        {
            Open.SetActive(false);
            Main_menu.SetActive(true);
            now_menu = "main";
        }
        OnEscClick();
    }

    private void CloseScenes()      // 關閉所有場景，如果有新的scene，要在這裡更新
    {
        Open.SetActive(false);
        Main_menu.SetActive(false);
        Set_menu.SetActive(false);
        Achievement_menu.SetActive(false);
        Credit_menu.SetActive(false);
    }
    private void SetScenes(string set)      // 切換場景，會關閉場景，更新 now_menu
    {
        now_menu = set;
        CloseScenes();
        switch (now_menu)
        {
            case "open":
                Open.SetActive(true);
                break;
            case "main":
                Main_menu.SetActive(true);
                break;
            case "set":
                Set_menu.SetActive(true);
                break;
            case "achievement":
                Achievement_menu.SetActive(true);
                break;
            case "credit":
                Credit_menu.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void GameStart()     // 進入遊戲
    {
        print("start");
        SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
    }

    public void GameQuit()      // 離開遊戲
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void GoBack()       // menu中的各頁回到上一頁
    {
        SetScenes("main");
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
                    GameQuit();
                    break;
                case "set":
                    SetScenes("main");
                    break;
                case "achievement":
                    SetScenes("main");
                    break;
                case "credit":
                    SetScenes("main");
                    break;
                default:
                    break;
            }
        }
    }

    public void BtnOnClick(int index, int mode = 0)
    {
        Debug.Log(now_menu + " " + index);
        BtnEvent(index, mode);
    }

    private void BtnEvent(int btnIndex, int mode)
    {
        switch (now_menu)
        {
            case "main":
                MainMenuBtnEvent(btnIndex, mode);
                break;
            case "set":
                SetMenuBtnEvent(btnIndex, mode);
                break;
            case "achievement":
                AchievementMenuBtnEvent(btnIndex, mode);
                break;
            case "credit":
                CreditMenuBtnEvent(btnIndex, mode);
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
                    GameStart();
                    break;
                case 1:
                    GameStart();
                    break;
                case 2:

                    break;
                case 3:
                    SetScenes("set");
                    break;
                case 4:
                    SetScenes("achievement");
                    break;
                case 5:
                    SetScenes("credit");
                    break;
                case 6:
                    GameQuit();
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
    private void AchievementMenuBtnEvent(int btnIndex, int mode)
    {
        if (mode == 0)
        {
            switch (btnIndex)
            {
                case 0:
                    break;
                case 1:
                    GoBack();
                    break;
                default:
                    break;
            }
        }
    }
    private void CreditMenuBtnEvent(int btnIndex, int mode)
    {
        if (mode == 0)
        {
            switch (btnIndex)
            {
                case 0:
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


