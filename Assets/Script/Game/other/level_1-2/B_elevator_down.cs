using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_elevator_down : Btn_controller
{
    public GameObject[] G_elevator;
    public GameObject[] G_elevatorSide;

    private Vector3[] elevatorNow_position;         // �{�b
    private Vector3[] elevatorLowest_position;      // �̧C�B
    private Vector3[] elevatorVertex_position;      // �̰��B
    private Vector3[] elevatorOtherSide_position;   // �ؼ�
    private Vector3[] elevatorStartSide_position;

    private bool[] is_Rising_H;
    private bool is_Rising_V;
    private bool[] is_reachOtherSide;
    private bool[] is_vertical;

    private bool isMoveElevator = false;
    private float distanceToOtherSide;
    private float distanceAll;
    [SerializeField] private GameObject otherCatOnPlatform = null;
    private int haveCatPlatform = 0;

    private float moveUnit = 20f;

    protected override void OnBtnStart()
    {
        Init();
    }

    protected override void OnBtnEnter()
    {
        isMoveElevator = true;
    }

    protected override void OnBtnExit()
    {
        isMoveElevator = false;
    }

    public void FixedUpdate()
    {
        if (isMoveElevator)
        {
            // ElevatorGo();
            MoveElevator();
        }
        else if (!isMoveElevator)
        {
            // ElevatorBack();
            BackToPosition();
        }
    }

    private void ElevatorGo()
    {
        for (int i = 0; i < G_elevator.Length; i++)
        {
            ElevatorMove(i, elevatorStartSide_position[i], elevatorOtherSide_position[i]);
        }
    }
    private void ElevatorBack()
    {
        for (int i = 0; i < G_elevator.Length; i++)
        {
            ElevatorMove(i, elevatorOtherSide_position[i], elevatorStartSide_position[i]);
        }
    }

    private void ElevatorMove(int i, Vector3 startPoint, Vector3 endPoint)
    {
        // elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m
        distanceToOtherSide = endPoint.x - elevatorNow_position[i].x;
        // distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].x - elevatorNow_position[i].x);
        // Debug.Log("/////");
        // Debug.Log(endPoint.x);
        // Debug.Log(elevatorNow_position[i].x);
        // Debug.Log(elevatorStartSide_position[i].x);
        // Debug.Log(elevatorOtherSide_position[i].x);
        // Debug.Log(distanceToOtherSide);
        // Debug.Log(Mathf.Abs(elevatorOtherSide_position[i].x - elevatorNow_position[i].x));
        // Debug.Log("/////");
        // ��s��m
        // �p��Z��
        // �P�w�O�_����I
        if (Mathf.Abs(distanceToOtherSide) <= 0.5f || Mathf.Abs(elevatorNow_position[i].x - startPoint.x) >= Mathf.Abs(endPoint.x - startPoint.x))
        {
            is_reachOtherSide[i] = true;
        }
        else is_reachOtherSide[i] = false;
        // ����
        if (is_reachOtherSide[i])
        {
            G_elevator[i].transform.position = endPoint;
            Debug.Log("end");
        }
        else if (distanceToOtherSide > 0)
        {
            G_elevator[i].transform.Translate(Vector3.right * 20f * Time.deltaTime);
            Debug.Log("right");
        }
        else if (distanceToOtherSide < 0)
        {
            G_elevator[i].transform.Translate(Vector3.left * 20f * Time.deltaTime);
            Debug.Log("left");
        }
        // ���b
    }
    // ^�g��@�b���F��A���S���Ψ�


    private void MoveElevator() //�q�貾��
    {
        for (int i = 0; i < G_elevator.Length; i++)
        {
            // �P�_�q��O���k�٬O�W�U
            if (!is_vertical[i])
            {
                elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m

                distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].x - elevatorNow_position[i].x);

                if (elevatorNow_position[i].x > elevatorVertex_position[i].x) //�P�_�q���m�A�M�w���k����
                {
                    is_Rising_H[i] = false;
                }
                else if (elevatorNow_position[i].x < elevatorLowest_position[i].x)
                {
                    is_Rising_H[i] = true;
                }
                else if (distanceToOtherSide <= 0.5f)
                {
                    is_reachOtherSide[i] = true;
                }

                if (is_reachOtherSide[i] == false)  //�٨S��t�@��
                {
                    if (is_Rising_H[i]) // �V�k
                    {
                        G_elevator[i].transform.Translate(Vector3.right * 20f * Time.deltaTime);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)  //���F��b���x�W
                            otherCatOnPlatform.transform.Translate(Vector3.right * 20f * Time.deltaTime);
                    }
                    else if (!is_Rising_H[i])  // �V��
                    {
                        G_elevator[i].transform.Translate(Vector3.left * 20f * Time.deltaTime);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)  //���F��b���x�W
                            otherCatOnPlatform.transform.Translate(Vector3.left * 20f * Time.deltaTime);
                    }
                }
            }
            else if (is_vertical[i])
            {
                elevatorNow_position[i] = G_elevator[i].transform.position;  //��s�q��{�b��m

                distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].y - elevatorNow_position[i].y);

                if (elevatorNow_position[i].y >= elevatorVertex_position[i].y)  //�P�_�q���m�A�M�w���k����
                {
                    is_Rising_V = false;
                }
                else if (elevatorNow_position[i].y <= elevatorLowest_position[i].y)
                {
                    is_Rising_V = true;
                }
                else if (distanceToOtherSide <= 0.5f)
                {
                    is_reachOtherSide[i] = true;
                }

                if (is_reachOtherSide[i] == false)
                {
                    if (is_Rising_V)  //�V�W
                    {
                        G_elevator[i].transform.Translate(Vector3.up * 10f * Time.deltaTime);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)  //���F��b���x�W
                            otherCatOnPlatform.transform.Translate(Vector3.up * 10f * Time.deltaTime);
                    }
                    else if (!is_Rising_V)  //�V�U
                    {
                        G_elevator[i].transform.Translate(Vector3.down * 10f * Time.deltaTime);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)  //���F��b���x�W
                            otherCatOnPlatform.transform.Translate(Vector3.down * 10f * Time.deltaTime);
                    }
                }
                //print("is_reachOtherSide  " + i + is_reachOtherSide[i]);
            }
        }
    }


    private void BackToPosition()
    {
        for (int i = 0; i < G_elevator.Length; i++)
        {
            // �P�_�q��O���k�٬O�W�U
            if (!is_vertical[i])
            {
                distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].x - elevatorNow_position[i].x);
                distanceAll = Mathf.Abs(elevatorVertex_position[i].x - elevatorLowest_position[i].x);

                if (distanceToOtherSide < distanceAll)
                {
                    is_reachOtherSide[i] = true;
                }
                if (!is_Rising_H[i])
                {
                    while (is_reachOtherSide[i] == true)
                    {
                        //print("elevator H moving right");
                        G_elevator[i].transform.Translate(Vector3.right * 1f);

                        if (i==haveCatPlatform&&otherCatOnPlatform != null)  //���F��b���x�W
                        {
                            otherCatOnPlatform.transform.Translate(Vector3.right * 1f);
                        }

                        elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m

                        distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].x - elevatorNow_position[i].x);
                        distanceAll = Mathf.Abs(elevatorVertex_position[i].x - elevatorLowest_position[i].x);

                        if (distanceToOtherSide >= distanceAll)
                        {
                            is_reachOtherSide[i] = false;
                        }
                    }
                }
                else if (is_Rising_H[i])
                {
                    while (is_reachOtherSide[i] == true)
                    {
                        //print("elevator H moving left");
                        G_elevator[i].transform.Translate(Vector3.left * 1f);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)
                            otherCatOnPlatform.transform.Translate(Vector3.left * 1f);
                        elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m

                        distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].x - elevatorNow_position[i].x);
                        distanceAll = Mathf.Abs(elevatorVertex_position[i].x - elevatorLowest_position[i].x);

                        if (distanceToOtherSide >= distanceAll)
                        {
                            is_reachOtherSide[i] = false;
                        }
                    }
                }
            }
            else if (is_vertical[i])
            {
                distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].y - elevatorNow_position[i].y);
                distanceAll = Mathf.Abs(elevatorVertex_position[i].y - elevatorLowest_position[i].y);

                if (distanceToOtherSide < distanceAll)
                {
                    is_reachOtherSide[i] = true;
                }
                if (!is_Rising_V)
                {
                    while (is_reachOtherSide[i] == true)
                    {
                        G_elevator[i].transform.Translate(Vector3.up * 1f);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)
                            otherCatOnPlatform.transform.Translate(Vector3.up * 1f);
                        elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m

                        distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].y - elevatorNow_position[i].y);
                        distanceAll = Mathf.Abs(elevatorVertex_position[i].y - elevatorLowest_position[i].y);

                        if (distanceToOtherSide >= distanceAll)
                        {
                            is_reachOtherSide[i] = false;
                        }
                    }
                }
                else if (is_Rising_V)
                {
                    while (is_reachOtherSide[i] == true)
                    {
                        G_elevator[i].transform.Translate(Vector3.down * 1f);
                        if (i==haveCatPlatform&&otherCatOnPlatform != null)
                            otherCatOnPlatform.transform.Translate(Vector3.down * 1f);
                        elevatorNow_position[i] = G_elevator[i].transform.position; //��s�q��{�b��m

                        distanceToOtherSide = Mathf.Abs(elevatorOtherSide_position[i].y - elevatorNow_position[i].y);
                        distanceAll = Mathf.Abs(elevatorVertex_position[i].y - elevatorLowest_position[i].y);

                        if (distanceToOtherSide >= distanceAll)
                        {
                            is_reachOtherSide[i] = false;
                        }
                    }
                }
            }
        }
    }

    private void Init()
    {
        elevatorNow_position = new Vector3[G_elevator.Length];
        elevatorLowest_position = new Vector3[G_elevator.Length];
        elevatorVertex_position = new Vector3[G_elevator.Length];
        elevatorStartSide_position = new Vector3[G_elevator.Length];
        elevatorOtherSide_position = new Vector3[G_elevator.Length];
        is_Rising_H = new bool[G_elevator.Length];
        is_reachOtherSide = new bool[G_elevator.Length];
        is_vertical = new bool[G_elevator.Length];

        for (int i = 0; i < G_elevator.Length; i++)
        {
            elevatorStartSide_position[i] = G_elevator[i].transform.position;
            if (G_elevator[i].transform.position.x > G_elevatorSide[i].transform.position.x || G_elevator[i].transform.position.y > G_elevatorSide[i].transform.position.y)
            {
                elevatorNow_position[i] = G_elevator[i].transform.position;
                elevatorLowest_position[i] = G_elevatorSide[i].transform.position;
                elevatorVertex_position[i] = G_elevator[i].transform.position;
                elevatorOtherSide_position[i] = G_elevatorSide[i].transform.position;
                is_reachOtherSide[i] = false;
            }
            else if (G_elevator[i].transform.position.x < G_elevatorSide[i].transform.position.x || G_elevator[i].transform.position.y < G_elevatorSide[i].transform.position.y)
            {
                elevatorNow_position[i] = G_elevator[i].transform.position;
                elevatorLowest_position[i] = G_elevator[i].transform.position;
                elevatorVertex_position[i] = G_elevatorSide[i].transform.position;
                elevatorOtherSide_position[i] = G_elevatorSide[i].transform.position;
                is_reachOtherSide[i] = false;
            }
            if (elevatorLowest_position[i].x < elevatorVertex_position[i].x || elevatorLowest_position[i].x > elevatorVertex_position[i].x)
            {
                is_vertical[i] = false;
            }
            else if (elevatorLowest_position[i].y < elevatorVertex_position[i].y)
            {
                is_vertical[i] = true;
            }
        }
    }

    public void GetPlatformCat(GameObject othercat, int i = 0)
    {
        otherCatOnPlatform = othercat;
        haveCatPlatform = i-1;
        //print("otherCatOnPlatform " + otherCatOnPlatform);
    }
}
