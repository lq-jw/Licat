using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent_Drop : MonoBehaviour
{
    public void Drop()
    {
        AudioManager.instance.PlaySE("cat_convert_landing");
    }
}