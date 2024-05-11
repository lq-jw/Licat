using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_dropBox : MonoBehaviour
{
    public Animator dropDoor_ani;
    public Animator btn_ani;
    public GameObject trigger;

    private bool is_press = false;

    // Update is called once per frame
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
            }
            else
            {
                //Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }

    private void PressBtn()
    {
        if (!is_press)
        {
            btn_ani.SetBool("is_press", true);
            dropDoor_ani.SetTrigger("is_drop");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
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
