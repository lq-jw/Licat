using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent_Drop : MonoBehaviour
{
    public void Drop()
    {
        AudioManager.instance.PlaySE("lv1_drop_drop");
    }
}