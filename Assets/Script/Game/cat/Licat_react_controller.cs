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
    public ReLoad_1_3 ReLoad_1_3;
    private bool water_die = false;
    //private float hp = 0f;
    //private float max_hp;
    //public GameObject hp_bar;
    //public Image img_hp_bar;

    void Start()
    {
        licat = GetComponent<Licat_move_controller>();
        Rigidbody = GetComponent<Rigidbody2D>();

        //max_hp = 10f;
        //hp = max_hp;
        //img_hp_bar.enabled = false;
        //hp_bar.SetActive(false);

        moveSpeed = licat.moveSpeed;

        checkPoint = new Vector3(3, -3, 0);
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
            //print("out of DeathBorder");
            Die();
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            water_die = true;
            //print("touch water");
            Die();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)   //防水材質(碰到扣血)
    {
        if (collision.gameObject.CompareTag("WaterProof") && catAni.GetBool("is_solid") == false )
        {
            //img_hp_bar.enabled = true;
            //hp_bar.SetActive(true);
            //hp -= 0.05f;
            //if (hp <= 0)
            //{
            //    Die();
            //}
        }
        else if (!collision.gameObject.CompareTag("WaterProof"))
        {
            //hp = max_hp;
            //img_hp_bar.enabled = false;
            //hp_bar.SetActive(false);
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

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("WaterDrop"))
        {
            //print("WaterDrop   OnParticleCollision");
            Die();
        }
    }

    public void UpdateCheckPoint(Vector3 pos)
    {
        checkPoint = pos;
    }

    public void Die()
    {
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        GameManager.instance.FadeOut();
        yield return new WaitForSeconds(duration);
        //print(virtualCamera.transform.rotation);
        Rigidbody.simulated = false;
        transform.localScale = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(duration);
        if (water_die)
        {
            ReLoad_1_3.reLoad_1_3();
            water_die = false;
        }
        transform.position = checkPoint;
        //virtualCamera.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        transform.localScale = new Vector3(1, 1, 1);
        Rigidbody.simulated = true;
        //print(virtualCamera.transform.rotation);

        yield return new WaitForSeconds(0.3f);
        GameManager.instance.LeaveAniMode(false);
    }

    private void FixedUpdate()
    {
        //hp_bar.transform.localScale = new Vector3(hp / max_hp, hp_bar.transform.localScale.y, hp_bar.transform.localScale.z);
    }
}
