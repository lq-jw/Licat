using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_elevator_down : MonoBehaviour
{
    public GameObject G_btn;

    private float btnNow_Y_pisition;
    private float btnPress_Y_pisition;
    private float btnUnpress_Y_pisition;

    public GameObject[] G_elevator;
    public GameObject[] G_elevatorSide;

    private Vector3[] elevatorNow_position;
    private Vector3[] elevatorLowest_position;
    private Vector3[] elevatorVertex_position;

    private bool[] is_Rising_H;
    private bool is_Rising_V;

    // Start is called before the first frame update
    void Start()
    {
        btnUnpress_Y_pisition = G_btn.transform.position.y;
        btnPress_Y_pisition = btnUnpress_Y_pisition - 0.05f;

        Init();
    }

    private void OnCollisionStay2D(Collision2D collision) //��
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            MoveElevator();
            btnNow_Y_pisition = G_btn.transform.position.y;
            if (btnNow_Y_pisition >= btnPress_Y_pisition)
            {
                G_btn.transform.Translate(Vector3.down * 0.1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)  //��}
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            UnPressBtn();
        }
    }

    private void UnPressBtn() //���s�첾
    {
        if (btnNow_Y_pisition <= btnUnpress_Y_pisition)
        {
            G_btn.transform.Translate(Vector3.up * 0.08f);
            btnNow_Y_pisition = G_btn.transform.position.y;
        }
    }

    private void MoveElevator() //�q�貾��
    {
        for (int i = 0; i < G_elevator.Length; i++)
        {
            // �P�_�q��O���k�٬O�W�U
            if (elevatorLowest_position[i].x < elevatorVertex_position[i].x || elevatorLowest_position[i].x > elevatorVertex_position[i].x)
            {
                elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m

                if (elevatorNow_position[i].x >= elevatorVertex_position[i].x) //�P�_�q���m�A�M�w���k����
                {
                    is_Rising_H[i] = false;
                }
                else if (elevatorNow_position[i].x <= elevatorLowest_position[i].x)
                {
                    is_Rising_H[i] = true;
                }

                if (is_Rising_H[i])
                {
                    G_elevator[i].transform.Translate(Vector3.right * 1.2f * Time.deltaTime);
                }
                else if (!is_Rising_H[i])
                {
                    G_elevator[i].transform.Translate(Vector3.left * 1.2f * Time.deltaTime);
                }
            }
            else if (elevatorLowest_position[i].y < elevatorVertex_position[i].y)
            {
                elevatorNow_position[i] = G_elevator[i].transform.position;  //��s�q��{�b��m

                if (elevatorNow_position[i].y >= elevatorVertex_position[i].y)  //�P�_�q���m�A�M�w���k����
                {
                    is_Rising_V = false;
                }
                else if (elevatorNow_position[i].y <= elevatorLowest_position[i].y)
                {
                    is_Rising_V = true;
                }

                if (is_Rising_V)
                {
                    G_elevator[i].transform.Translate(Vector3.up * 1.2f * Time.deltaTime);
                }
                else if (!is_Rising_V)
                {
                    G_elevator[i].transform.Translate(Vector3.down * 1.2f * Time.deltaTime);
                }
            }
        }
    }


    private void Init()
    {
        elevatorNow_position = new Vector3[G_elevator.Length];
        elevatorLowest_position = new Vector3[G_elevator.Length];
        elevatorVertex_position = new Vector3[G_elevator.Length];
        is_Rising_H = new bool[G_elevator.Length];

        for (int i = 0; i < G_elevator.Length; i++)
        {
            if (G_elevator[i].transform.position.x > G_elevatorSide[i].transform.position.x || G_elevator[i].transform.position.y > G_elevatorSide[i].transform.position.y)
            {
                elevatorNow_position[i] = G_elevator[i].transform.position;
                elevatorLowest_position[i] = G_elevatorSide[i].transform.position;
                elevatorVertex_position[i] = G_elevator[i].transform.position;
            }
            else if (G_elevator[i].transform.position.x < G_elevatorSide[i].transform.position.x || G_elevator[i].transform.position.y < G_elevatorSide[i].transform.position.y)
            {
                elevatorNow_position[i] = G_elevator[i].transform.position;
                elevatorLowest_position[i] = G_elevator[i].transform.position;
                elevatorVertex_position[i] = G_elevatorSide[i].transform.position;
            }
        }
    }
}
