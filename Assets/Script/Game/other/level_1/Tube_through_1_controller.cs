using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube_through_1_controller : MonoBehaviour
{
    public BoxCollider2D tube_collider;
    public Animator Big_cat_ani;
    public GameObject Big_cat;
    private float moveSpeed = 40f;

    private void Start()
    {
        //tube_collider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Big_cat_ani.GetBool("is_solid") == false)
        {
            int layerMask = LayerMask.GetMask("Role_stage");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 5f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")))
            {
                Debug.Log("hit object " + hit.collider.name);
                Big_cat_ani.SetBool("is_tubeThrough", true);
                Big_cat_ani.SetBool("is_tubeThrough_R", true);
                //Big_cat.transform.position = new Vector3(gameObject.transform.position.x+10, gameObject.transform.position.y,gameObject.transform.position.z);
                tube_collider.enabled = false;

                MoveBigCat();
            }
            else
            {
                Debug.Log("hit nothing " + hit.collider.name);
            }
        }
        else
        {
            print("not in range");
        }
    }

    private void MoveBigCat()
    {
        StartCoroutine(TranslateBigCat());
    }

    private IEnumerator TranslateBigCat()
    {
        while (Big_cat.transform.position.x < gameObject.transform.position.x + 2.5f)
        {
            Big_cat.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            Debug.Log(Big_cat.transform.position.x);
            yield return null;
        }
        while (Big_cat.transform.position.y < gameObject.transform.position.y + 5.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Big_cat.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            Debug.Log(Big_cat.transform.position.x);
            yield return null;
        }
        while (Big_cat.transform.position.x < gameObject.transform.position.x + 6)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            Debug.Log(Big_cat.transform.position.x);
            yield return null;
        }


        tube_collider.enabled = true;
        Big_cat_ani.SetBool("is_tubeThrough", false);
        Big_cat_ani.SetBool("is_tubeThrough_R", false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.left * 5f);
    }
}
