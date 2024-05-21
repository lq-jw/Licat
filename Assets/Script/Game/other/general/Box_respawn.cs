using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_respawn : MonoBehaviour
{
    Vector3 checkPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathBorder"))  //∂W•X√‰¨…
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(Respawn());
    }

    public void UpdateCheckPoint(Vector3 pos)
    {
        checkPoint = pos;
    }
    IEnumerator Respawn()
    {   
        yield return new WaitForSeconds(1f);
        transform.position = checkPoint;
        
    }
}
