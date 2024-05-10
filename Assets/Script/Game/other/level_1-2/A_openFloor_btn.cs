using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_openFloor_btn : MonoBehaviour
{
    public Animator floor_btn_ani;
    public Animator floor_door_ani;
    public GameObject trigger;

    private bool ani_state;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            int layerMask = LayerMask.GetMask("Role_stage");
            //int layerMask = 1 << 3;
            //int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);
            Debug.Log("hit object " + gameObject.name);
            if (hitD.collider != null && hitD.collider.CompareTag("Player") || hitD.collider.CompareTag("Player_yellow") || hitD.collider.CompareTag("Player_blue"))
            {
                //Debug.Log("hit object " + gameObject.name);
                closeDoor();
            }
            else
            {
                //Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }

    private void closeDoor()
    {
        ani_state = floor_btn_ani.GetBool("is_open");
        if (ani_state)
        {
            //print("string true");
            ani_state = true;
        }
        else if(!ani_state)
        { 
            //print("string false");
            ani_state = false;
        }
        
        floor_btn_ani.SetBool("is_open", !ani_state);
        floor_door_ani.SetBool("is_open", !ani_state);
        print("close");
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
