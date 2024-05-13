using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingElevator : MonoBehaviour
{
    public GameObject G_elevator;
    private float elevatorNow_X_pisition;
    private float elevatorVertex_X_pisition;
    private float elevatorLowest_X_pisition;
    private bool is_Rising = true;

    private GameObject CatOnPlatform;
    private bool isCatOnPlatform = false;

    // Start is called before the first frame update
    private void Start()
    {
        elevatorVertex_X_pisition = G_elevator.transform.position.x + 7;
        elevatorLowest_X_pisition = G_elevator.transform.position.x;
        //------確認按鈕、電梯位置
    }

    // Update is called once per frame
    void Update()
    {
        MoveElevator();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            CatOnPlatform = collision.gameObject;
            isCatOnPlatform = true;
        }
    }

    private void MoveElevator() //電梯移動
    {
        if (!isCatOnPlatform)
        {
            elevatorNow_X_pisition = G_elevator.transform.position.x;
            if (elevatorNow_X_pisition >= elevatorVertex_X_pisition)
            {
                is_Rising = false;
            }
            else if (elevatorNow_X_pisition <= elevatorLowest_X_pisition)
            {
                is_Rising = true;
            }

            if (is_Rising)
            {
                G_elevator.transform.Translate(Vector3.right * 1.7f * Time.deltaTime);
            }
            else if (!is_Rising)
            {
                G_elevator.transform.Translate(Vector3.left * 1.7f * Time.deltaTime);
            }
        }
        else if (isCatOnPlatform)
        {
            elevatorNow_X_pisition = G_elevator.transform.position.x;
            if (elevatorNow_X_pisition >= elevatorVertex_X_pisition)
            {
                is_Rising = false;
            }
            else if (elevatorNow_X_pisition <= elevatorLowest_X_pisition)
            {
                is_Rising = true;
            }

            if (is_Rising)
            {
                G_elevator.transform.Translate(Vector3.right * 1.7f * Time.deltaTime);
                CatOnPlatform.transform.Translate(Vector3.right * 1.7f * Time.deltaTime);
            }
            else if (!is_Rising)
            {
                G_elevator.transform.Translate(Vector3.left * 1.7f * Time.deltaTime);
                CatOnPlatform.transform.Translate(Vector3.left * 1.7f * Time.deltaTime);
            }
        }

    }
}
