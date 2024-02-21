using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Btn_controller : MonoBehaviour
{
    public Animator floor_door_ani;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            int layerMask = LayerMask.GetMask("Role_stage");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2f, layerMask);
            RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 2f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player") || hit.collider.CompareTag("Player_yellow") || hit.collider.CompareTag("Player_blue")) 
                || (hitL.collider != null && hitL.collider.CompareTag("Player") || hit.collider.CompareTag("Player_yellow") || hit.collider.CompareTag("Player_blue")))
            {
                Debug.Log("hit object " + gameObject.name);
                if (!floor_door_ani.GetBool("openDoor"))
                {
                    floor_door_ani.SetBool("openDoor", true);
                }
                else
                {
                    floor_door_ani.SetBool("openDoor", false);
                }
            }
            else
            {
                Debug.Log("hit nothing " + hit.collider.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.right * 2f);
    }
}
