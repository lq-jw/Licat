using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float fallDelay = 1f;
    [SerializeField] private float destroyDelay = 2f;
    [SerializeField] private Rigidbody2D platformRB;
    public bool isCatFalling;

    private bool isPlatformFalling = false;
    private GameObject CatStepOnPlatform;

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
