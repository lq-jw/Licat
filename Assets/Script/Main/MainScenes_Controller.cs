using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScenes_Controller : MonoBehaviour
{
    public GameObject Main_menu;
    public GameObject Open;
    public GameObject Set_menu;

    [SerializeField] int menuIndex;

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
            menuIndex = 0;
        }
    }

    private void CloseScenes()
    {
        Open.SetActive(false);
        Main_menu.SetActive(false);
        Set_menu.SetActive(false);
    }
    private void SetScenes(int index)
    {
        menuIndex = index;
        CloseScenes();
        switch (menuIndex)
        {
            case 0:
                Main_menu.SetActive(true);
                break;
            case 1:
                Set_menu.SetActive(true);
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
        SetScenes(0);
    }

    public void BtnOnClick(int index)
    {
        Debug.Log(menuIndex + " " + index);
        BtnEvent(index);
    }
    private void BtnEvent(int btnIndex)
    {
        switch (menuIndex)
        {
            case 0:
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
                        SetScenes(1);
                        break;
                    case 4:
                        //SceneManager.LoadScene("gameScene");
                        break;
                    case 5:

                        break;
                    case 6:
                        GameQuit();
                        break;
                    default:
                        break;
                }
                break;
            case 1:
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
                break;
            default:
                break;
        }
    }

}
