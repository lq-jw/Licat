using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearingPlatform : MonoBehaviour
{
    public Licat_move_controller licat;
    public Licat_blue_move_controller blueLicat;
    public Licat_yellow_move_controller yellowLicat;
    public Split_controller Split_controller;

    public GameObject platformMain;
    public GameObject platformSub;

    public GameObject thisLight;
    public GameObject otherLight;

    public GameObject otherSide;
    private GameObject otherCat;

    private float moveSpeedLicat;
    private GameObject catOnPlatform;
    
    private Vector3 thisSide;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedLicat = licat.moveSpeed;
        thisSide = platformMain.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            catOnPlatform = collision.gameObject;
            thisLight.SetActive(true);
            otherLight.SetActive(true);
            movePlatform();
        }else if (collision.gameObject.CompareTag("Player_blue"))
        {
            catOnPlatform = collision.gameObject;
            thisLight.SetActive(true);
            otherLight.SetActive(true);
            //Split_controller.catNumber
            
            if (Split_controller.catNumber == 1)
            {
                print("Split_controller.catNumber " + Split_controller.catNumber);
                movePlatform();
            }

        }
        else if (collision.gameObject.CompareTag("Player_yellow"))
        {
            catOnPlatform = collision.gameObject;
            thisLight.SetActive(true);
            otherLight.SetActive(true);
            
            if (Split_controller.catNumber == 2)
            {
                print("Split_controller.catNumber " + Split_controller.catNumber);
                movePlatform();
            }
            
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        thisLight.SetActive(false);
        otherLight.SetActive(false);
    }

    private void movePlatform()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Horizontal") > 0 )
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
                if (otherCat != null)
                    otherCat.transform.Translate(Vector3.right * 10f * Time.deltaTime);
            }
        }else if (Input.GetKey(KeyCode.A) || Input.GetAxisRaw("Horizontal") < 0)
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
                if (otherCat != null) 
                    otherCat.transform.Translate(Vector3.left * 10f * Time.deltaTime);
            }
        }
    }

    public void GetOtherCat(GameObject othercat)
    {
        otherCat = othercat;
    }
}
