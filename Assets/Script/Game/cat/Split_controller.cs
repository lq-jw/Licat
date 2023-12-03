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
    public SpriteRenderer catSr;
    public PolygonCollider2D polygonCollider2D;
    public BoxCollider2D LeftBoxCollider2D;

    public GameObject blue_triangle;
    public GameObject yallow_triangle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("stoppppppp");

            Big_licat.transform.position = new Vector3((Blue_licat.transform.position.x) - 2, Blue_licat.transform.position.y, 3);

            Big_licat.SetActive(true);
            Big_licat.GetComponent<Licat_move_controller>().enabled = true;
            catSr.enabled = true;
            polygonCollider2D.enabled = true;
            LeftBoxCollider2D.enabled = true;

            StartCoroutine(CloseSplitController());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Blue_licat.GetComponent<Licat_blue_move_controller>().enabled == false)
            {
                Blue_licat.GetComponent<Licat_blue_move_controller>().enabled = true;
                blue_triangle.SetActive(true);
                Yallow_licat.GetComponent<Licat_yallow_move_controller>().enabled = false;
                yallow_triangle.SetActive(false);
                //print("blue on");
            }
            else
            {
                Blue_licat.GetComponent<Licat_blue_move_controller>().enabled = false;
                blue_triangle.SetActive(false);
                Yallow_licat.GetComponent<Licat_yallow_move_controller>().enabled = true;
                yallow_triangle.SetActive(true);
                //print("blue off");
            }
        }

        IEnumerator CloseSplitController()
        {
            catAni.SetBool("is_split", false);

            yield return new WaitForSeconds(0f);
            Blue_licat.GetComponent<Licat_blue_move_controller>().enabled = false;
            Yallow_licat.GetComponent<Licat_yallow_move_controller>().enabled = false;
            Yallow_licat.SetActive(false);
            Blue_licat.SetActive(false);

            charController.GetComponent<Split_controller>().enabled = false;
            charController.SetActive(false);
        }
    }
}
