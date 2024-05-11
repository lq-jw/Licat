using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{

    [SerializeField] private bool isStopBGM = false;
    // Start is called before the first frame update
    void Start()
    {
        if (isStopBGM) AudioManager.instance.StopBGM();
    }
}
