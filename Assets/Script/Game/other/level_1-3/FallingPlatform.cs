using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private ASyncLoader Loader;
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float destroyDelay = 2f;
    [SerializeField] private Rigidbody2D platformRB;
    public bool isCatFalling;
    public Animator LicatAni;

    private bool isPlatformFalling = false;
    private GameObject CatStepOnPlatform;

    public void Start()
    {
        LicatAni.SetBool("is_faceRight", true);
        GameManager.instance.LeaveAniMode(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isPlatformFalling)
            return;
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box") || collision.gameObject.CompareTag("Player_blue") || collision.gameObject.CompareTag("Player_yellow"))
        {
            StartCoroutine(StarFall());
            CatStepOnPlatform = collision.gameObject;
        }
    }

    private IEnumerator StarFall()
    {
        isPlatformFalling = true;
        yield return new WaitForSeconds(fallDelay);

        platformRB.bodyType = RigidbodyType2D.Dynamic;

        if (isCatFalling == true)
        {
            print("isCatFalling");
            if (CatStepOnPlatform != null)
            {
                yield return new WaitForSeconds(0.5f);
                CatStepOnPlatform.SetActive(false);
                GameManager.instance.FadeOut();
                yield return new WaitForSeconds(1.5f);
                if (Loader != null)
                {
                    Loader.LoadScene("MainScene", true);
                }
                else
                {
                    SceneManager.LoadScene("MainScene");
                    SceneManager.LoadScene("PauseScene", LoadSceneMode.Additive);
                }
            }
            else
            {
                print("CatStepOnPlatform " + null);
                GameManager.instance.FadeOut();
            }
            //CatStepOnPlatform.SetActive(false);
            
        }
        yield return new WaitForSeconds(2f);
        Destroy(gameObject, destroyDelay);
    }
}
