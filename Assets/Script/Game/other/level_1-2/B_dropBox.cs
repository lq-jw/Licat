using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_dropBox : MonoBehaviour
{
    public GameObject connectedDoor_L; // 連接的門
    public GameObject connectedDoor_R;
    public Animator btn_ani;

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
                Debug.Log("hit object " + gameObject.name);
                PressBtn();
                //is_press = !is_press;
            }
            else
            {
                Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }

    private void PressBtn()
    {
        if (is_press)
        {
            //btn_ani.SetBool("is_press", false);
        }
        else if (!is_press)
        {
            btn_ani.SetBool("is_press", true);
            //StartCoroutine(RotateDoor());
        }

    }

    private IEnumerable RotateDoor()
    {
        connectedDoor_L.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        connectedDoor_R.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        yield return new WaitForSecondsRealtime(5);
        connectedDoor_L.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        connectedDoor_R.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        is_press = !is_press;
        btn_ani.SetBool("is_press", false);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        //Gizmos.DrawRay(transform.position, transform.right * 2f);
        Gizmos.DrawRay(transform.position, transform.up * -5f);
    }
}
