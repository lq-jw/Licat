using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_dropBox_btnR : MonoBehaviour
{
    public GameObject connectedDoor; // 連接的門
    public GameObject btn;
    public Animator btn_ani;
    public Animator licat_ani;
    public Animator licat_blue_ani;
    public Animator licat_yellow_ani;
    public int number;
    public GameObject trigger;

    private Vector3 btn_position;
    private Vector3 licat_position;
    private bool is_press = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            //int layerMask = LayerMask.GetMask("Role_stage");
            //int layerMask = 1 << 3;
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);

            if (hitD.collider != null && hitD.collider.CompareTag("Player"))
            {
                btn_position = btn.transform.position;
                licat_position = hitD.collider.transform.position;

                licat_position.x = btn_position.x;
                hitD.collider.transform.position = licat_position;

                PressBtn(0);
            }
            else if (hitD.collider != null && hitD.collider.CompareTag("Player_blue"))
            {
                btn_position = btn.transform.position;
                licat_position = hitD.collider.transform.position;

                licat_position.x = btn_position.x;
                hitD.collider.transform.position = licat_position;
                PressBtn(1);
            }
            else if (hitD.collider != null && hitD.collider.CompareTag("Player_yellow"))
            {
                btn_position = btn.transform.position;
                licat_position = hitD.collider.transform.position;

                licat_position.x = btn_position.x;
                hitD.collider.transform.position = licat_position;
                PressBtn(2);
            }
            else 
            {
                //Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }

    private void PressBtn(int licatNum)
    {
        is_press = btn_ani.GetBool("is_press");
        if (is_press)
        {
            connectedDoor.GetComponent<A_dropBox>().SetSwitchR(true, number);
            btn_ani.SetBool("is_press", false);
            //licat_ani.Play("push_pole_S");
            switch (licatNum)
            {
                case 0:
                    licat_ani.Play("push_pole_S");
                    break;
                case 1:
                    licat_blue_ani.Play("push_pole_S_B");
                    break;
                case 2:
                    licat_yellow_ani.Play("push_pole_S_Y");
                    break;
                default:
                    break;
            }
        }
        else if (!is_press)
        {
            connectedDoor.GetComponent<A_dropBox>().SetSwitchR(false, number);
            btn_ani.SetBool("is_press", true);
            //licat_ani.Play("pull_pole_S");
            switch (licatNum)
            {
                case 0:
                    licat_ani.Play("pull_pole_S");
                    break;
                case 1:
                    licat_blue_ani.Play("pull_pole_S_B");
                    break;
                case 2:
                    licat_yellow_ani.Play("pull_pole_S_Y");
                    break;
                default:
                    break;
            }
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
