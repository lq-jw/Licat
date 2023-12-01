using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan_controler : MonoBehaviour
{
    public Animator fan_ani;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2f, layerMask);
            RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 2f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")) || (hitL.collider != null && hitL.collider.CompareTag("Player")))
            {
                Debug.Log("hit object " + gameObject.name);
                if (!fan_ani.GetBool("is_open"))
                {
                    fan_ani.SetBool("is_open", true);
                }
                else
                {
                    fan_ani.SetBool("is_fan_open", false);
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
