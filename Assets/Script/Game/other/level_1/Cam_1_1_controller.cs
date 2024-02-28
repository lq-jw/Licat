using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Cam_1_1_controller : Cam_controller
{

    private List<Collider2D> catInArea = new List<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<CinemachineVirtualCamera>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isPlayerYellow = collision.CompareTag("Player_yellow");
        bool isPlayerBlue = collision.CompareTag("Player_blue");

        if (collision.CompareTag("Player") || collision.CompareTag("Player_yellow") || collision.CompareTag("Player_blue"))
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }

        if(collision.CompareTag("Player_yellow") || collision.CompareTag("Player_blue"))
        {
            catInArea.Add(collision);
            CheckColliders();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool isPlayerYellow = collision.CompareTag("Player_yellow");
        bool isPlayerBlue = collision.CompareTag("Player_blue");

        if(catInArea.Count < 2)
        {
            if (isPlayerYellow && !isPlayerBlue)
            {
                //print("yellow in, blue out");
                //Cam_change();
                Cam_changeYellow();
            }
            else if (!isPlayerYellow && isPlayerBlue)
            {
                //print("yellow out, blue in");
                Cam_changeBlue();
            }
            else
            {
                //print("else");
                //this.GetComponent<CinemachineVirtualCamera>().enabled = true;
            }
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player_yellow") || collision.CompareTag("Player_blue"))
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }

        if (collision.CompareTag("Player_yellow") || collision.CompareTag("Player_blue"))
        {
            catInArea.Remove(collision);
            CheckColliders();
        }
    }

    private void Cam_changeYellow()
    {
        if (blue_licat.GetComponent<Licat_blue_move_controller>().enabled && yellow_licat.GetComponent<Licat_yellow_move_controller>().enabled == false)
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
        else if (blue_licat.GetComponent<Licat_blue_move_controller>().enabled == false && yellow_licat.GetComponent<Licat_yellow_move_controller>().enabled)
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
        else
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }

    private void Cam_changeBlue()
    {
        if (blue_licat.GetComponent<Licat_blue_move_controller>().enabled && yellow_licat.GetComponent<Licat_yellow_move_controller>().enabled == false)
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
        else if (blue_licat.GetComponent<Licat_blue_move_controller>().enabled == false && yellow_licat.GetComponent<Licat_yellow_move_controller>().enabled)
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = false;
        }
        else
        {
            this.GetComponent<CinemachineVirtualCamera>().enabled = true;
        }
    }

    private void CheckColliders()
    {
        if (catInArea.Count == 2)
        {
            // 同時有兩個碰撞體在範圍內
            Debug.Log("Two colliders in the area.");
        }
    }
}
