using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel_tube : MonoBehaviour
{
    public GameObject Turn_1;
    public GameObject Turn_2;
    public GameObject Turn_3;

    public BoxCollider2D tube_collider;

    public Animator Big_cat_ani;
    public GameObject Big_cat;

    private GameObject lv1_2front;
    private GameObject lv1_2middle;
    private GameObject lv1_2behind;

    private float tubeSpeed = 30f;
    private float X_distance;
    private float Y_distance;
    private string SceneName;
    // Start is called before the first frame update
    void Start()
    {
        SceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Big_cat_ani.GetBool("is_solid") == false
    || Input.GetButtonDown("X") && Big_cat_ani.GetBool("is_solid") == false)
        {
            int layerMask = LayerMask.GetMask("Role_stage");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 4f, layerMask);

            if ((hit.collider != null && hit.collider.CompareTag("Player")))
            {
                Debug.Log("hit object " + hit.collider.name);

                Big_cat_ani.Play("_L_R_tubeThrough_0");
                Big_cat_ani.SetBool("is_tubeThrough_R", true);
                tube_collider.enabled = false;

                MoveBigCat();
            }
            else
            {
                Debug.Log("hit nothing ");
            }
        }
        else
        {
            //print("not in range");
        }
    }
    private void MoveBigCat()
    {
        //StartCoroutine(TranslateBigCat());
        StartCoroutine(CatTurn());
    }

    private IEnumerator CatTurn()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        X_distance = (Big_cat.transform.position.x) - (Turn_1.transform.position.x);
        Y_distance = (Big_cat.transform.position.y) - (Turn_2.transform.position.y);

        while (X_distance > 0.5f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_1.transform.position.x);
            yield return null;
        }

        Big_cat.transform.position = Turn_1.transform.position;


        GameManager.instance.FadeOut();

        while (Y_distance > 0.5f || Y_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            Big_cat.transform.Translate(Vector3.right * (tubeSpeed + 10f) * Time.deltaTime);
            Y_distance = (Big_cat.transform.position.y) - (Turn_2.transform.position.y);
            yield return null;
        }

        Big_cat.transform.position = Turn_2.transform.position;

        X_distance = (Big_cat.transform.position.x) - (Turn_3.transform.position.x);


        while (X_distance > 1f || X_distance < -0.5f)
        {
            Big_cat.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Big_cat.transform.Translate(Vector3.right * tubeSpeed * Time.deltaTime);
            X_distance = (Big_cat.transform.position.x) - (Turn_3.transform.position.x);
            yield return null;
        }

        Big_cat.transform.position = Turn_3.transform.position;
        Big_cat_ani.SetBool("is_tubeThrough_R", false);

        yield return new WaitForSecondsRealtime(3);
        //tube_collider.enabled = true;
        //GameManager.instance.LeaveAniMode(false);

        if (SceneName == "Level_1")  //直接換關
        {
            //GameManager.instance.LeaveAniMode(false);
            SceneManager.LoadScene("Level_1_2");  
        }
        else if (SceneName == "Level_1_2")   //播放下一段動畫，不換關
        {
            //先把某個鏡頭打開，然後把後面的關卡打開，順便把前面的關卡關掉節省效能
            lv1_2middle.transform.Find("1-Lv.1-2-2");
            lv1_2middle.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.left * 3f);
    }
}
