using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReLoad_1_3 : MonoBehaviour
{
    public GameObject scene_1_3;
    public GameObject LicatPosition;
    public GameObject licat;
    
    public GameObject box;

    public GameObject box_position;
    // Start is called before the first frame update
    void Start()
    {
        //box_position.transform.position = box.transform.position;
        //scene_1_3.SetActive(false);
        //LicatPosition.transform.position = licat.transform.position;
    }

    public void reLoad_1_3()
    {
        print("reLoad_1_3");
        
        scene_1_3.SetActive(false);

        StartCoroutine(openScene());
    }

    IEnumerator openScene()
    {
        //yield return new WaitForSeconds(2f);
        scene_1_3.SetActive(true);
        licat.transform.position = LicatPosition.transform.position;
        box.transform.position = box_position.transform.position;
        yield return new WaitForSeconds(2f);
        
        GameManager.instance.LeaveAniMode(false);
    }
}
