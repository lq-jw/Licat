using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndAni_controller : MonoBehaviour
{
    [SerializeField] private ASyncLoader Loader;

    public GameObject CircleTrigger;
    public Animator doorAni;
    public GameObject Licat;

    void Start()
    {
        Hide(CircleTrigger);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) || Input.GetButtonDown("X"))
        {
            //int layerMask = LayerMask.GetMask("Role_stage");
            //int layerMask = 1 << 3;
            int layerMask = ~(1 << gameObject.layer);

            RaycastHit2D hitL = Physics2D.Raycast(transform.position, Vector2.left, 3f, layerMask);
            RaycastHit2D hitR = Physics2D.Raycast(transform.position, Vector2.right, 3f, layerMask);

            Debug.Log("hit object " + gameObject.name);
            if (hitL.collider != null && hitL.collider.CompareTag("Player") || hitR.collider.CompareTag("Player"))
            {
                //Debug.Log("hit object " + gameObject.name);
                StartCoroutine(LoadScene());
            }
            else
            {
                //Debug.Log("hit nothing " + hitD.collider.name);
            }
        }
    }
    private IEnumerator LoadScene()
    {
        Licat.SetActive(false);
        doorAni.SetBool("is_inToTube", true);
        GameManager.instance.FadeOut();

        yield return new WaitForSecondsRealtime(1.5f);
        if (Loader != null)
        {
            Loader.LoadScene("Level_1_3", true);
        }
        else
        {
            SceneManager.LoadScene("Level_1_3");
            SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
        }
        //SceneManager.LoadScene("Level_1_3");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            Show(CircleTrigger);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            Hide(CircleTrigger);
        }
    }

    public void Show(GameObject trigger)
    {
        trigger.SetActive(true);
    }
    public void Hide(GameObject trigger)
    {
        trigger.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.right * -3f);
    }
}
