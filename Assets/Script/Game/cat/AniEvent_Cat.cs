using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent_Cat : MonoBehaviour
{
    public void Cat_move()
    {
        AudioManager.instance.PlaySE("cat_move");
    }

    public void Cat_jump()
    {
        AudioManager.instance.PlaySE("cat_jump");
    }

//////////////////////////////////////

    public void Licat_move()
    {
        AudioManager.instance.PlaySE("licat_move");
    }
}