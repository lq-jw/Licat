using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制貓抓板 F 按下去之後的動作
public class CatGrasp_controler : MonoBehaviour
{
    public Animator Cat_ani;
    public Rigidbody2D Rigidbody;

    public GameObject Front_grasp;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            int layerMask = LayerMask.GetMask("Role_stage");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2f, layerMask);
            RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 2f, layerMask);
            RaycastHit2D hitUp = Physics2D.Raycast(transform.position, Vector2.up, 2f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")) || (hitL.collider != null && hitL.collider.CompareTag("Player")))
            {
                Cat_ani.Play("_N_R_move_1");
                Rigidbody.AddForce(Vector2.up * 100, ForceMode2D.Impulse);
                Front_grasp.SetActive(true);
                GraspAni();
            }
            else if ((hitUp.collider != null && hitUp.collider.CompareTag("Player")))
            {
                Front_grasp.SetActive(true);
                GraspAni();
            }
            else
            {
                Debug.Log("hit nothing ");
            }
        }
    }

    private void GraspAni()
    {
        if (Cat_ani.GetBool("is_faceRight") == true)
        {
            Cat_ani.Play("_N_R_grasp");
        }
        else if (Cat_ani.GetBool("is_faceRight") == false)
        {
            Cat_ani.Play("_N_L_grasp");
        }

        //Front_grasp.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.up * 2f);
        Gizmos.DrawRay(transform.position, transform.right * 2f);
    }
}
