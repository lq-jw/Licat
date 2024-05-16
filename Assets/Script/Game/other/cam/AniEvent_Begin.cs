using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent_Begin : MonoBehaviour
{
    public void InBasket(){
        AudioManager.instance.PlaySE("lv0_begin_inBasket");
    }

    public void MoveInBasket(){
        AudioManager.instance.PlaySE("ani_moveSound");
    }

    public void JumpOut(){
        AudioManager.instance.PlaySE("lv0_begin_jumpOut");
    }
}