using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Licat_react_controller : MonoBehaviour
{
    Vector3 checkPoint;

    Licat_move_controller licat;
    float moveSpeed;
    Rigidbody2D Rigidbody;
    public Animator catAni;
    public CinemachineVirtualCamera virtualCamera;
    private bool solid;

    private float hp = 0f;
    private float max_hp;
    public GameObject hp_bar;
    public Image img_hp_bar;

    void Start()
    {
        licat = GetComponent<Licat_move_controller>();
        Rigidbody = GetComponent<Rigidbody2D>();

        max_hp = 10f;
        hp = max_hp;
        img_hp_bar.enabled = false;
        hp_bar.SetActive(false);

        moveSpeed = licat.moveSpeed;

        checkPoint = new Vector3(3, -3, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        solid = catAni.GetBool("is_solid");

        if (collision.CompareTag("Ditch"))  //碰到水溝(死)
        {
            if (virtualCamera != null)
            {
                if (!solid)
                {
                    Die();
                }
            }
        }
        else if (collision.CompareTag("DeathBorder"))  //超出邊界
        {
            Die();
        }else if (collision.CompareTag("WaterDrop"))
        {
            print("WaterDrop");
        }
    }

    private void OnCollisionStay2D(Collision2D collision)   //防水材質(碰到扣血)
    {
        if (collision.gameObject.CompareTag("WaterProof") && catAni.GetBool("is_solid") == false && hp >= 0)
        {
            img_hp_bar.enabled = true;
            hp_bar.SetActive(true);
            hp -= 0.05f;
            if (hp <= 0)
            {
                Die();
            }
        }
        else if (!collision.gameObject.CompareTag("WaterProof"))
        {
            hp = max_hp;
            img_hp_bar.enabled = false;
            hp_bar.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Hydrophobic") && catAni.GetBool("is_solid") == false) //疏水材質(降速)
        {
            print("Hydrophobic");

            if (licat != null)
            {
                print("moveSpeed " + moveSpeed);
                moveSpeed = 5f;
                licat.setMoveSpeed(moveSpeed);
            }
            else
            {
                print("null");
            }
        }
    }

    public void UpdateCheckPoint(Vector3 pos)
    {
        checkPoint = pos;
    }

    void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        //print(virtualCamera.transform.rotation);
        Rigidbody.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        transform.position = checkPoint;
        //virtualCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localScale = new Vector3(1, 1, 1);
        Rigidbody.simulated = true;
        //print(virtualCamera.transform.rotation);
    }

    private void FixedUpdate()
    {
        hp_bar.transform.localScale = new Vector3(hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
}
