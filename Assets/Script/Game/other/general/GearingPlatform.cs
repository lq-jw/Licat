using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearingPlatform : MonoBehaviour
{
    public Licat_move_controller licat;
    public Licat_blue_move_controller blueLicat;
    public Licat_yellow_move_controller yellowLicat;

    public GameObject platformMain;
    public GameObject platformSub;

    public GameObject otherSide;
    public GameObject otherCat = null;

    private float moveSpeedLicat;
    private GameObject catOnPlatform;
    
    private Vector3 thisSide;

    // Start is called before the first frame update
    void Start()
    {
        //licat = GetComponent<Licat_move_controller>();
        moveSpeedLicat = licat.moveSpeed;
        thisSide = platformMain.transform.position;
        //platformMain = this.gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            catOnPlatform = collision.gameObject;
            movePlatform();
        }
    }

    private void movePlatform()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (otherSide.transform.position.x >= platformMain.transform.position.x)
            {
                moveSpeedLicat = 0f;
                licat.setMoveSpeed(moveSpeedLicat);
                blueLicat.setMoveSpeed(moveSpeedLicat);
                yellowLicat.setMoveSpeed(moveSpeedLicat);

                platformMain.transform.Translate(Vector3.right * 10f * Time.deltaTime);
                catOnPlatform.transform.Translate(Vector3.right * 10f * Time.deltaTime);

                platformSub.transform.Translate(Vector3.right * 10f * Time.deltaTime);
                otherCat.transform.Translate(Vector3.right * 10f * Time.deltaTime);
            }
        }else if (Input.GetKey(KeyCode.A))
        {
            if (thisSide.x <= platformMain.transform.position.x)
            {
                moveSpeedLicat = 0f;
                licat.setMoveSpeed(moveSpeedLicat);
                blueLicat.setMoveSpeed(moveSpeedLicat);
                yellowLicat.setMoveSpeed(moveSpeedLicat);

                platformMain.transform.Translate(Vector3.left * 10f * Time.deltaTime);
                catOnPlatform.transform.Translate(Vector3.left * 10f * Time.deltaTime);

                platformSub.transform.Translate(Vector3.left * 10f * Time.deltaTime);
                otherCat.transform.Translate(Vector3.left * 10f * Time.deltaTime);
            }
        }
    }

    public void GetOtherCat(GameObject othercat)
    {
        otherCat = othercat;
    }
}
