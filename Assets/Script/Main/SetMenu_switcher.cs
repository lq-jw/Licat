using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetMenu_switcher : MonoBehaviour
{
    [SerializeField] Mainmenu_btn_controller mainmenu_btn_controller;
    [SerializeField] Animator btn_animator;
    [SerializeField] private int thisIndex;
    [SerializeField] private TextMeshPro text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainmenu_btn_controller.GetSelect() == thisIndex)
        {
            // Debug.Log("select" + thisIndex);
            btn_animator.SetBool("btn_hover", true);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                text.text="A";
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // text.text("B");
            }
        }
        else
        {
            btn_animator.SetBool("btn_hover", false);
        }
    }
}
