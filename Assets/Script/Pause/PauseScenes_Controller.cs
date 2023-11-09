using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScenes_Controller : MonoBehaviour
{

    [SerializeField] private GameObject Pause_menu, Set_menu, BG;
    [SerializeField] private string now_menu;
    [SerializeField] private bool isPause;

    // Start is called before the first frame update
    void Start()
    {
        SetScenes("game");
    }

    // Update is called once per frame
    void Update()
    {
        OnEscClick();
    }

    private void CloseScenes()      // 關閉所有場景，如果有新的scene，要在這裡更新
    {
        Pause_menu.SetActive(false);
        Set_menu.SetActive(false);
    }
    private void SetScenes(string set)      // 切換場景，會關閉場景，更新 now_menu
    {
        now_menu = set;
        CloseScenes();
        BG.SetActive(true);
        switch (now_menu)
        {
            case "game":
                BG.SetActive(false);
                isPause = false;
                break;
            case "pause":
                Pause_menu.SetActive(true);
                isPause = true;
                break;
            case "set":
                Set_menu.SetActive(true);
                isPause = true;
                break;
            default:
                break;
        }
    }

    private void GoBack()       // menu中的各頁回到上一頁
    {
        SetScenes("pause");
    }

    private void OnEscClick()       // menu中的esc事件
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (now_menu)
            {
                case "game":
                    SetScenes("pause");
                    break;
                case "pause":
                    SetScenes("game");
                    break;
                case "set":
                    SetScenes("pause");
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
        if (isPause)
        {
            switch (now_menu)
            {
                case "pause":
                    PauseMenuBtnEvent(btnIndex);
                    break;
                case "set":
                    SetMenuBtnEvent(btnIndex, mode);
                    break;
                default:
                    break;
            }
        }
    }

    private void PauseMenuBtnEvent(int btnIndex)
    {
        switch (btnIndex)
        {
            case 0:
                SetScenes("game");
                break;
            case 1:
                SetScenes("set");
                break;
            case 2:
                GameSaveAndBackToMain();
                break;
            default:
                break;
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

    private void GameSaveAndBackToMain()
    {
        GameSave();
        BackToMainMenu();
    }

    private void GameSave()
    {
        Debug.Log("Save Game");
    }

    private void BackToMainMenu()
    {
        Debug.Log("BackToMainMenu");
        SceneManager.LoadScene("MainScenes");
    }

}
