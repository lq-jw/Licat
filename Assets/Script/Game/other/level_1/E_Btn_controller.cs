using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Btn_controller : MonoBehaviour
{
    public Animator floor_btn_ani;
    public Animator floor_door_R_ani;
    public Animator floor_door_L_ani;
    public Animator licat_ani;
    public GameObject trigger;

    private bool isdoorOpen = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            //int layerMask = LayerMask.GetMask("Role_stage");
            int layerMask = 1 << 3;

            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);

            if (hitD.collider != null && hitD.collider.CompareTag("Player") || hitD.collider.CompareTag("Player_yellow") || hitD.collider.CompareTag("Player_blue"))
            {
                Debug.Log("hit object " + gameObject.name);
                closeDoor();
            }
            else
            {
                Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }

    private void closeDoor()
    {
        if (isdoorOpen)
        {
            floor_btn_ani.SetBool("is_open", false);
            floor_door_R_ani.SetBool("is_open", false);
            floor_door_L_ani.SetBool("is_open", false);
            licat_ani.Play("pull_pole_L");
            isdoorOpen = !isdoorOpen;
        }

        //print("close");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawRay(transform.position, transform.right * 2f);
        Gizmos.DrawRay(transform.position, transform.up * 5f);
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
