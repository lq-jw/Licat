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
        CloseScenes();
        Open.SetActive(true);
    }

    void Update()
    {
        if (Open.activeSelf && Input.anyKeyDown)
        {
            Open.SetActive(false);
            Main_menu.SetActive(true);
            now_menu = "main";
        }
        EscOnClick();
    }

    private void CloseScenes()      // 如果有新的scene，要在這裡更新
    {
        Open.SetActive(false);
        Main_menu.SetActive(false);
        Set_menu.SetActive(false);
        Achievement_menu.SetActive(false);
        Credit_menu.SetActive(false);
    }
    private void SetScenes(string set)
    {
        now_menu = set;
        CloseScenes();
        switch (now_menu)
        {
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

    public void GameStart()
    {
        print("start");
        SceneManager.LoadScene("GameScene");
    }

    public void GameQuit()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    private void GoBack()
    {
        SetScenes("main");
    }

    private void EscOnClick()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (now_menu)
            {
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

    public void BtnOnClick(int index)
    {
        Debug.Log(now_menu + " " + index);
        BtnEvent(index);
    }
    private void BtnEvent(int btnIndex)
    {
        switch (now_menu)
        {
            case "main":
                MainMenuBtnEvent(btnIndex);
                break;
            case "set":
                SetMenuBtnEvent(btnIndex);
                break;
            case "achievement":
                AchievementMenuBtnEvent(btnIndex);
                break;
            case "credit":
                CreditMenuBtnEvent(btnIndex);
                break;
            default:
                break;
        }
    }

    private void MainMenuBtnEvent(int btnIndex)
    {
        switch (btnIndex)
        {
            case 0:
                SceneManager.LoadScene("gameScene");
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
    private void SetMenuBtnEvent(int btnIndex)
    {
        switch (btnIndex)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                GoBack();
                break;
            default:
                break;
        }
    }
    private void AchievementMenuBtnEvent(int btnIndex)
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
    private void CreditMenuBtnEvent(int btnIndex)
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


