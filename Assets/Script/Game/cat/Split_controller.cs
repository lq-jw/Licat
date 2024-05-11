using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split_controller : MonoBehaviour
{
    public GameObject Big_licat;
    public GameObject Yallow_licat;
    public GameObject Blue_licat;

    public GameObject charController;

    public Animator catAni;
    public Animator catblueAni;
    public Animator catyallowAni;
    public SpriteRenderer catSr;
    public PolygonCollider2D polygonCollider2D;
    public BoxCollider2D LeftBoxCollider2D;

    public GameObject blue_triangle;
    public GameObject yallow_triangle;

    private float pressTime = 0f;
    private float requiredPressTime = 1f; // 長按所需的時間
    private bool B_check_merge;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) || Input.GetButton("B"))    //融合
        {
            Debug.Log("F key is being held down");
            pressTime += Time.deltaTime;
            Check_merge();

            if(pressTime >= requiredPressTime && catblueAni.GetBool("is_solid") == false && catyallowAni.GetBool("is_solid") == false && B_check_merge)
            {
                print("stoppppppp");

                Big_licat.transform.position = new Vector3((Blue_licat.transform.position.x) - 2, Blue_licat.transform.position.y, 3);

                Big_licat.SetActive(true);
                Big_licat.GetComponent<Licat_move_controller>().enabled = true;

                catAni.Play("_L_R_merge");

                catAni.SetBool("is_split", false);
                catAni.SetBool("is_solid", false);
                catAni.SetBool("is_faceRight", true);

                Blue_licat.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Blue_licat.GetComponent<PolygonCollider2D>().enabled = true;
                Yallow_licat.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Yallow_licat.GetComponent<PolygonCollider2D>().enabled = true;

                //catSr.enabled = true;
                //polygonCollider2D.enabled = true;
                //LeftBoxCollider2D.enabled = true;

                StartCoroutine(CloseSplitController());
            }
        }
        else
        {
            pressTime = 0f;
        }

        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("RB"))   //切換
        {
            if (Blue_licat.GetComponent<Licat_blue_move_controller>().enabled == false)   //藍色 On
            {
                Blue_licat.GetComponent<Licat_blue_move_controller>().enabled = true;
                blue_triangle.SetActive(true);
                Yallow_licat.GetComponent<Licat_yellow_move_controller>().enabled = false;
                yallow_triangle.SetActive(false);
                //print("blue on");

                Blue_licat.GetComponent<PolygonCollider2D>().enabled = true;
                Blue_licat.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                Yallow_licat.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                Yallow_licat.GetComponent<PolygonCollider2D>().enabled = false;
            }
            else if(Yallow_licat.GetComponent<Licat_yellow_move_controller>().enabled == false) //黃色 On
            {
                Blue_licat.GetComponent<Licat_blue_move_controller>().enabled = false;
                blue_triangle.SetActive(false);
                Yallow_licat.GetComponent<Licat_yellow_move_controller>().enabled = true;
                yallow_triangle.SetActive(true);
                //print("blue off");

                Blue_licat.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                Blue_licat.GetComponent<PolygonCollider2D>().enabled = false;
                
                Yallow_licat.GetComponent<PolygonCollider2D>().enabled = true;
                Yallow_licat.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }

        IEnumerator CloseSplitController()
        {
            catAni.SetBool("is_split", false);

            yield return new WaitForSeconds(0f);
            Blue_licat.GetComponent<Licat_blue_move_controller>().enabled = false;
            Yallow_licat.GetComponent<Licat_yellow_move_controller>().enabled = false;
            blue_triangle.SetActive(true);
            yallow_triangle.SetActive(false);
            Yallow_licat.SetActive(false);
            Blue_licat.SetActive(false);

            charController.GetComponent<Split_controller>().enabled = false;
            charController.SetActive(false);
        }
    }

    private void Check_merge()  //確定兩隻貓的距離
    {
        Vector3 Yallow_licatPosition = Yallow_licat.transform.position;
        Vector3 Blue_licatPosition = Blue_licat.transform.position;

        float y_delta = Mathf.Abs(Yallow_licatPosition.y - Blue_licatPosition.y);
        float x_delta = Mathf.Abs(Yallow_licatPosition.x - Blue_licatPosition.x);

        if (y_delta <= 2f && x_delta <= 2.5f)
        {
            B_check_merge =  true;
        }
        else B_check_merge =  false;
        
    }
}
