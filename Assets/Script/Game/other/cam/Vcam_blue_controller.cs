using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Vcam_blue_controller : MonoBehaviour
{
    private float Vcam_lenSize;
    private bool isEnter = false;

    void Update()
    {
        int layerMask = LayerMask.GetMask("Vcam_trigger");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.forward, 14f, layerMask);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 4f, layerMask);

        if ((hit.collider != null && hit.collider.CompareTag("Vcam_trigger")))
        {
            Debug.Log("hit object " + hit.collider.name);
            StartCoroutine(Vcam_LensSwitsh_S());
            //this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 14f;
        }
        else if (hit.collider != null && hit.collider.CompareTag("Vcam_trigger_Lv1-1"))
        {
            StartCoroutine(Vcam_LensSwitsh());
        }
        else
        {
            //Debug.Log("hit nothing ");
        }
        
    }

    private IEnumerator Vcam_LensSwitsh_S()
    {
        for (float i = 5; i <= 14; i += 0.1f)
        {
            this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(0f);
        }
    }

    private IEnumerator Vcam_LensSwitsh()
    {
        for (float i = 6.5f; i <= 8.3f; i += 0.1f)
        {
            this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(0f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.forward * 13f);
    }
}
