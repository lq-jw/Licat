using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent_Eat : MonoBehaviour
{
    public void JumpIntoBag(){
        AudioManager.instance.PlaySE("cat_jump");
    }

    public void InBag(){
        AudioManager.instance.PlaySE("lv0_eat_inBag");
    }

    public void BagFall(){
        AudioManager.instance.PlaySE("lv0_eat_bagfall");
    }

    public void CatRoll(){
        AudioManager.instance.PlaySE("ani_moveSound");
    }

    public void HitWall(){
        AudioManager.instance.PlaySE("lv0_eat_hitWall");
    }

    public void Eat(){
        AudioManager.instance.PlaySE("lv0_eat_eat");
    }

    public void Eating(){
        AudioManager.instance.PlaySE("lv0_eat_eating");
    }

    public void ChangeToLiquid(){
        AudioManager.instance.PlaySE("lv0_eat_changeToLiquid");
    }

    public void Flow(){
        AudioManager.instance.PlaySE("licat_move");
    }

    public void FlowIntoTube(){
        AudioManager.instance.PlaySE("ani_flowInTube");
    }
}