using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube_test : MonoBehaviour
{
    public GameObject Turn_0;
    public GameObject Turn_1;
    public GameObject Turn_2;
    public GameObject Turn_3;
    public GameObject Turn_4;
    public GameObject Turn_5;

    public BoxCollider2D tube_collider;
    public BoxCollider2D tube_collider_other;

    public Animator Big_cat_ani;
    public GameObject Big_cat;

    private float tubeSpeed = 30f;
    private float X_distance;
    private float Y_distance;
    private float Turn23_distance;


    private void Start()
    {
        //tube_collider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Big_cat_ani.GetBool("is_solid") == false
            || Input.GetButtonDown("X") && Big_cat_ani.GetBool("is_solid") == false)
        {
            int layerMask = LayerMask.GetMask("Role_stage");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 4f, layerMask);
            RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, 4f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")))
            {
                Debug.Log("hit object " + hit.collider.name);

                Big_cat_ani.Play("_L_R_tubeThrough_0");
                Big_cat_ani.SetBool("is_tubeThrough_R", true);
                tube_collider.enabled = false;
                
                tube_collider_other.enabled = false;

                MoveBigCat();
            }else if ((hitR.collider != null && hitR.collider.CompareTag("Player")))
            {
                Debug.Log("hit object " + hitR.collider.name);

                Big_cat_ani.Play("_L_R_tubeThrough_0");
                Big_cat_ani.SetBool("is_tubeThrough_R", true);
                tube_collider.enabled = false;
                tube_collider_other.enabled = false;

                MoveBigCatR();
            }
            else
            {
                Debug.Log("hit nothing " );
            }
        }
        else
        {
            print("not in range");
        }
    }

    private void MoveBigCat()
    {
        //StartCoroutine(TranslateBigCat());
        StartCoroutine(CatTurn());
    }

    private void MoveBigCatR()
    {
        //StartCoroutine(TranslateBigCat());
        StartCoroutine(CatTurnR());
    }

    private IEnumerator TranslateBigCat()
    {
        while (Big_cat.transform.position.x < gameObject.transform.position.x + 2.5f)
        {
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            Debug.Log(Big_cat.transform.position.x);
            yield return null;
        }
        while (Big_cat.transform.position.y < gameObject.transform.position.y + 9.0f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            Debug.Log(Big_cat.transform.position.x);
            yield return null;
        }
        while (Big_cat.transform.position.x < gameObject.transform.position.x + 8f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            Debug.Log(Big_cat.transform.position.x);
            yield return null;
        }


        tube_collider.enabled = true;
        //Big_cat_ani.SetBool("is_tubeThrough", false);
        Big_cat_ani.SetBool("is_tubeThrough_R", false);
    }

    private IEnumerator CatTurn()
    {
        X_distance = (Big_cat.transform.position.x) - (Turn_1.transform.position.x);
        Y_distance = (Big_cat.transform.position.y) - (Turn_2.transform.position.y);
        Turn23_distance = (Turn_2.transform.position.y) - (Turn_3.transform.position.y);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_1.transform.position.x);
            yield return null;
        }

        while (Y_distance > 0.5f || Y_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Big_cat.transform.Translate(Vector3.right * (tubeSpeed + 10f) * Time.deltaTime);
            Y_distance = (Big_cat.transform.position.y) - (Turn_2.transform.position.y);
            yield return null;
        }

        if (Turn23_distance > 0.5f || Turn23_distance < -0.5f)
        {
            Big_cat.transform.Translate(Vector3.down * 1f);
            Y_distance = (Big_cat.transform.position.y) - (Turn_3.transform.position.y);
            while (Y_distance > 0.5f || Y_distance < -0.5f)
            {
                Big_cat.transform.Translate(Vector3.right * (tubeSpeed + 10f) * Time.deltaTime);
                Y_distance = (Big_cat.transform.position.y) - (Turn_3.transform.position.y);
                yield return null;
            }
        }

        X_distance = (Big_cat.transform.position.x) - (Turn_3.transform.position.x);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_3.transform.position.x);
            yield return null;
        }

        Y_distance = (Big_cat.transform.position.y) - (Turn_4.transform.position.y);
        while (Y_distance > 0.5f || Y_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            Y_distance = (Big_cat.transform.position.y) - (Turn_4.transform.position.y);
            yield return null;
        }

        X_distance = (Big_cat.transform.position.x) - (Turn_5.transform.position.x);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_5.transform.position.x);
            yield return null;
        }
    
        Big_cat_ani.SetBool("is_tubeThrough_R", false);

        yield return 3f;
        tube_collider.enabled = true;
        tube_collider_other.enabled = true;
    }

    private IEnumerator CatTurnR()
    {
        X_distance = (Big_cat.transform.position.x) - (Turn_4.transform.position.x);
        Y_distance = (Big_cat.transform.position.y) - (Turn_3.transform.position.y);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_4.transform.position.x);
            yield return null;
        }

        while (Y_distance > 0.5f || Y_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Big_cat.transform.Translate(Vector3.right * (tubeSpeed + 10f) * Time.deltaTime);
            Y_distance = (Big_cat.transform.position.y) - (Turn_3.transform.position.y);
            yield return null;
        }

        if (Turn23_distance > 0.5f || Turn23_distance < -0.5f)
        {
            Big_cat.transform.Translate(Vector3.down * 1f);
            Y_distance = (Big_cat.transform.position.y) - (Turn_2.transform.position.y);
            while (Y_distance > 0.5f || Y_distance < -0.5f)
            {
                Big_cat.transform.Translate(Vector3.right * (tubeSpeed + 10f) * Time.deltaTime);
                Y_distance = (Big_cat.transform.position.y) - (Turn_3.transform.position.y);
                yield return null;
            }
        }

        X_distance = (Big_cat.transform.position.x) - (Turn_2.transform.position.x);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_2.transform.position.x);
            yield return null;
        }

        Y_distance = (Big_cat.transform.position.y) - (Turn_1.transform.position.y);
        while (Y_distance > 0.5f || Y_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            Y_distance = (Big_cat.transform.position.y) - (Turn_1.transform.position.y);
            yield return null;
        }

        X_distance = (Big_cat.transform.position.x) - (Turn_0.transform.position.x);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_0.transform.position.x);
            yield return null;
        }

        Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        Big_cat_ani.SetBool("is_tubeThrough_R", false);

        yield return new WaitForSecondsRealtime(5);
        tube_collider.enabled = true;
        tube_collider_other.enabled = true;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.left * 3f);
        Gizmos.DrawRay(transform.position, Vector3.right * 3f);
    }
}
