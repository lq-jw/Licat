using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_dropBox : MonoBehaviour
{
    private bool btn_L_Set = false;
    private bool btn_R_Set = false;

    private bool[] btn_L;
    private bool[] btn_R;

    public SpriteRenderer[] dropBoxLight;
    public Animator box;
    public GameObject[] BoxLight; 

    private Color tempColor;

    public void Start()
    {
        btn_L = new bool[4];
        btn_R = new bool[4];
        for (int i = 0; i < 4; i++)
        {
            btn_L[i] = false;
            btn_R[i] = false;
        }
    }
    public void SetSwitchL(bool activated, int number)
    {
        btn_L[number] = activated;
        CheckSwitch_L();
        //LightSwitch(number);
        StartCoroutine(LightSwitch(number));
    }

    public void SetSwitchR(bool activated, int number)
    {
        btn_R[number] = activated;
        CheckSwitch_R();
        //LightSwitch(number);
        StartCoroutine(LightSwitch(number));
    }

    private void CheckSwitch_L()
    {
        if (btn_L[0] == false && btn_L[1] == false && btn_L[2] == true && btn_L[3] == false)
        {
            btn_L_Set = true;
            CheckSwitches();
        }    
    }

    private void CheckSwitch_R()
    {
        if (btn_R[0] == false && btn_R[1] == true && btn_R[2] == true && btn_R[3] == false)
        {
            btn_R_Set = true;
            CheckSwitches();
        }
    }


    private void CheckSwitches()
    {
        // 如果兩個開關都被觸發，打開門，否則關閉門
        if (btn_L_Set && btn_R_Set)
        {
            DropBox();
        }
    }

    IEnumerator LightSwitch(int number)
    {

        if (btn_R[number] && btn_L[number])
        {
            yield return new WaitForSeconds(0.5f);
            //print("1,1");
            tempColor = dropBoxLight[number].color;
            tempColor.a = 1f;
            dropBoxLight[number].color = tempColor;
            dropBoxLight[number + 4].color = tempColor;
        }
        else if (btn_R[number] && !btn_L[number])
        {
            yield return new WaitForSeconds(0.5f);
            //print("0,1");
            tempColor = dropBoxLight[number].color;
            tempColor.a = 0.6f;
            dropBoxLight[number].color = tempColor;
            dropBoxLight[number + 4].color = tempColor;
        }
        else if (!btn_R[number] && btn_L[number])
        {
            yield return new WaitForSeconds(0.5f);
            //print("1,0");
            tempColor = dropBoxLight[number].color;
            tempColor.a = 0.6f;
            dropBoxLight[number].color = tempColor;
            dropBoxLight[number + 4].color = tempColor;
        }
        else if (!btn_R[number] && !btn_L[number])
        {
            yield return new WaitForSeconds(0.5f);
            //print("0,0");
            tempColor = dropBoxLight[number].color;
            tempColor.a = 0f;
            dropBoxLight[number].color = tempColor;
            dropBoxLight[number + 4].color = tempColor;
        }
        
    }

    private void DropBox()
    {
        box.SetTrigger("is_drop");
        for (int i = 0; i < BoxLight.Length; i++)
        {
            BoxLight[i].SetActive(true);
        }
    }
}
