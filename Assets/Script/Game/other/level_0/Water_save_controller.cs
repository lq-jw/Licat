using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water_save_controller : MonoBehaviour
{
    public Animator water_ani;

    // Update is called once per frame
    void Update()
    {
        int layerMask = ~(1 << gameObject.layer);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 2f, layerMask);
        RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 2f, layerMask);

        if ((hit.collider != null && hit.collider.CompareTag("Player")) || (hitL.collider != null && hitL.collider.CompareTag("Player")))
        {
            print("hit cat");
            water_ani.Play("water");
        }
        else
        {
            Debug.Log("hit nothing ");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right * 0.5f);
    }
}
