using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ߧ�O F ���U�h���᪺�ʧ@
public class CatGrasp_controler : MonoBehaviour
{
    public Animator Cat_ani;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2f, layerMask);
            RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 2f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")) || (hitL.collider != null && hitL.collider.CompareTag("Player")))
            {
                Cat_ani.Play("_N_R_grasp");
                //Debug.Log("hit object " + gameObject.name);
                //if (!fan_ani.GetBool("is_open"))
                //{
                //    fan_ani.SetBool("is_open", true);
                //}
                //else
                //{
                //    fan_ani.SetBool("is_open", false);
                //}
            }
            else
            {
                //Debug.Log("hit nothing " + hit.collider.name);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("OnPlatForm");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.right * 2f);
    }
}
