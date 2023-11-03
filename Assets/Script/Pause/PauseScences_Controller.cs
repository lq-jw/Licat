using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScences_Controller : MonoBehaviour
{

    [SerializeField] private GameObject Pause_menu, BG;
    [SerializeField] private string now_menu;
    private bool isPause;

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
    }
    private void SetScenes(string set)      // 切換場景，會關閉場景，更新 now_menu
    {
        now_menu = set;
        CloseScenes();
        BG.SetActive(true);
        switch (now_menu)
        {
            case "pause":
                Pause_menu.SetActive(true);
                isPause = true;
                break;
            case "game":
                BG.SetActive(false);
                isPause = false;
                break;
            default:
                break;
        }
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
                default:
                    break;
            }
        }
    }


}
