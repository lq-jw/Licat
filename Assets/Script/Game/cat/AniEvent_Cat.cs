using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent_Cat : MonoBehaviour
{
    public void Cat_move()
    {
        AudioManager.instance.PlaySE("cat_move");
    }

    public void Cat_run()
    {
        AudioManager.instance.PlaySE("cat_run");
    }

    public void Cat_jump()
    {
        AudioManager.instance.PlaySE("cat_jump");
    }

    public void Cat_jump_landing()
    {
        AudioManager.instance.PlaySE("cat_jump_landing");
    }

    public void Cat_convert()
    {
        AudioManager.instance.PlaySE("cat_convert");
    }

    public void Cat_convert_landing()
    {
        AudioManager.instance.PlaySE("cat_convert_landing");
    }

    //////////////////////////////////////

    public void Licat_move()
    {
        AudioManager.instance.PlaySE("licat_move");
    }

    public void Licat_convert()
    {
        AudioManager.instance.PlaySE("licat_convert");
    }

    public void Licat_split()
    {
        AudioManager.instance.PlaySE("licat_split");
    }

    public void Licat_merge()
    {
        AudioManager.instance.PlaySE("licat_merge");
    }
}