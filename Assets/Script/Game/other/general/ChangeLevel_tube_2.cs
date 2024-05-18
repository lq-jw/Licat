using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel_tube_2 : MonoBehaviour
{
    public GameObject level_1_2;
    public GameObject level_1_3;

    public Split_controller Split_controller;

    private bool isUpCam_open = true;
    private bool isDownCam_open = true;

    public void closeCam(bool isUp,bool isBlueCat)
    {
        if (isUp)
        {
            isUpCam_open = false;
            print("isBlueCat  " + isBlueCat);
            if (isBlueCat == true)
            {
                Split_controller.OpenYellow();
            }
            else
            {
                Split_controller.OpenBlue();
            }
            checkChangeLevel();
        }
        else if(!isUp)
        {
            isDownCam_open = false;
            print("isBlueCat  " + isBlueCat);
            if (isBlueCat == true)
            {
                Split_controller.OpenYellow();
            }
            else
            {
                Split_controller.OpenBlue();
            }
            checkChangeLevel();
        }
    }

    private void checkChangeLevel()
    {
        if (isUpCam_open == false && isDownCam_open == false)
        {
            GameManager.instance.FadeOut();
            Split_controller.Merge();
            StartCoroutine(changeLevel());
        }
    }

    private IEnumerator changeLevel()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        level_1_3.SetActive(true);
        //level_1_2.SetActive(false);
    }
}
