using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PullBtn_controller : MonoBehaviour
{
    public Animator floor_btn_ani;
    public Animator floor_door_ani;
    public GameObject btn;
    public GameObject trigger;

    public Animator licat_ani;
    public Animator licat_blue_ani;
    public Animator licat_yellow_ani;

    protected bool ani_state;
    private Vector3 btn_position;
    private Vector3 licat_position;
    //protected abstract void SwitchDoor();
    protected abstract void SwitchDoor(int licatNum);

    private void Start()
    {
        Hide(trigger);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            //int layerMask = LayerMask.GetMask("Role_stage");
            //int layerMask = 1 << 3;
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hitD = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);
            //Debug.Log("hit object " + gameObject.name);
            if (hitD.collider != null && hitD.collider.CompareTag("Player"))
            {
                btn_position = btn.transform.position;
                licat_position = hitD.collider.transform.position;

                licat_position.x = btn_position.x;
                hitD.collider.transform.position = licat_position;
                SwitchDoor(0);
            }
            else if (hitD.collider != null && hitD.collider.CompareTag("Player_blue"))
            {
                btn_position = btn.transform.position;
                licat_position = hitD.collider.transform.position;

                licat_position.x = btn_position.x;
                hitD.collider.transform.position = licat_position;
                SwitchDoor(1);
            }
            else if (hitD.collider != null && hitD.collider.CompareTag("Player_yellow"))
            {
                btn_position = btn.transform.position;
                licat_position = hitD.collider.transform.position;

                licat_position.x = btn_position.x;
                hitD.collider.transform.position = licat_position;
                SwitchDoor(2);
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
