using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class B_TubeChangeLevel_down : MonoBehaviour
{
    public GameObject Turn_1;

    public BoxCollider2D tube_collider;

    public Animator Big_cat_ani;
    public GameObject Big_cat;

    public Animator Licat_blue_ani;
    public Animator Licat_yellow_ani;
    
    public ChangeLevel_tube_2 ChangeLevel_tube_2;

    private GameObject tubeCat;
    private bool isBlueCat;

    private float tubeSpeed = 30f;
    private float X_distance;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Big_cat_ani.GetBool("is_solid") == false
    || Input.GetButtonDown("X") && Big_cat_ani.GetBool("is_solid") == false)
        {
            int layerMask = LayerMask.GetMask("Role_stage");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 4f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")) 
                || (hit.collider != null && hit.collider.CompareTag("Player_blue"))|| (hit.collider != null && hit.collider.CompareTag("Player_yellow")))
            {
                if (hit.collider.CompareTag("Player_blue"))
                {
                    Licat_blue_ani.Play("_L_tubeThrough_0");
                    Licat_blue_ani.SetBool("is_tubeThrough",true);
                    tube_collider.enabled = false;
                    isBlueCat = true;

                    tubeCat = hit.collider.gameObject;
                    MoveBigCat();
                }
                else if (hit.collider.CompareTag("Player_yellow"))
                {
                    Licat_yellow_ani.Play("_L_tubeThrough_0");
                    Licat_yellow_ani.SetBool("is_tubeThrough", true);
                    tube_collider.enabled = false;
                    isBlueCat = false;

                    tubeCat = hit.collider.gameObject;
                    MoveBigCat();
                }
            }
            else
            {
                Debug.Log("hit nothing ");
            }
        }
    }

    private void MoveBigCat()
    {
        StartCoroutine(CatTurn());
    }

    private IEnumerator CatTurn()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        X_distance = (tubeCat.transform.position.x) - (Turn_1.transform.position.x);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            tubeCat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (tubeCat.transform.position.x) - (Turn_1.transform.position.x);
            yield return null;
        }

        tubeCat.transform.position = Turn_1.transform.position;

        Licat_yellow_ani.SetBool("is_tubeThrough", false);
        Licat_blue_ani.SetBool("is_tubeThrough", false);

        ChangeLevel_tube_2.closeCam(false, isBlueCat);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.left * 3f);
    }
}
