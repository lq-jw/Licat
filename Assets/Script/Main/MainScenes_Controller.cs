using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScenes_Controller : MonoBehaviour
{
    public GameObject Main_menu;
    public GameObject Open;
    public GameObject Set_menu;


    void Start()
    {
        Main_menu.SetActive(false);
        Open.SetActive(true);
        Set_menu.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Open.SetActive(false);
            Main_menu.SetActive(true);
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

    public void GameSet()
    {
        Main_menu.SetActive(false);
        Set_menu.SetActive(true);
    }

}
