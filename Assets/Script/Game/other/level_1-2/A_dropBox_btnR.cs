using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_dropBox_btnR : MonoBehaviour
{
    public GameObject connectedDoor; // �s������
    public Animator btn_ani;
    public Animator licat_ani;
    public int number;
    public GameObject trigger;

    private bool is_press = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            //int layerMask = LayerMask.GetMask("Role_stage");
            //int layerMask = 1 << 3;
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);

            if (hitD.collider != null && hitD.collider.CompareTag("Player") || hitD.collider.CompareTag("Player_yellow") || hitD.collider.CompareTag("Player_blue"))
            {
                //Debug.Log("hit object " + gameObject.name);
                PressBtn();
                //is_press = !is_press;
            }
            else 
            {
                //Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }

    private void PressBtn()
    {
        is_press = btn_ani.GetBool("is_press");
        if (is_press)
        {
            connectedDoor.GetComponent<A_dropBox>().SetSwitchR(true, number);
            btn_ani.SetBool("is_press", false);
            licat_ani.Play("push_pole_S");
        }
        else if (!is_press)
        {
            connectedDoor.GetComponent<A_dropBox>().SetSwitchR(false, number);
            btn_ani.SetBool("is_press", true);
            licat_ani.Play("pull_pole_S");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawRay(transform.position, transform.right * 2f);
        Gizmos.DrawRay(transform.position, transform.up * -5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Show(trigger);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Hide(trigger);
    }

    public void Show(GameObject trigger)
    {
        trigger.SetActive(true);
    }
    public void Hide(GameObject trigger)
    {
        trigger.SetActive(false);
    }
}
