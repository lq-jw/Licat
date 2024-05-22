using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PullBtn_controller : MonoBehaviour
{
    public Animator floor_btn_ani;
    public Animator floor_door_ani;
    public GameObject trigger;
    public Animator licat_ani;

    protected bool ani_state;
    //protected abstract void SwitchDoor();
    protected abstract void SwitchDoor();


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            //int layerMask = LayerMask.GetMask("Role_stage");
            //int layerMask = 1 << 3;
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);
            Debug.Log("hit object " + gameObject.name);
            if (hitD.collider != null && hitD.collider.CompareTag("Player") || hitD.collider.CompareTag("Player_yellow") || hitD.collider.CompareTag("Player_blue"))
            {
                //Debug.Log("hit object " + gameObject.name);
                SwitchDoor();
            }
            else
            {
                //Debug.Log("hit nothing " + hitD.collider.name);
            }
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
