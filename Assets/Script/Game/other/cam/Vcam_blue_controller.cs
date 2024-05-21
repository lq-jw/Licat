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
                this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 14f;
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

    private IEnumerator Vcam_LensSwitsh()
    {
        print("isEnter " + isEnter);
        print("Vcam_lenSize " + Vcam_lenSize);
        if (isEnter == false)
        {
            yield return new WaitForSeconds(2f);
            isEnter = true;
            //Vcam_lenSize = this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize;
            this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 8.3f;
        }
        else if(isEnter == true)
        {
            yield return new WaitForSeconds(2f);
            isEnter = false;
            this.GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = 6.5f;
        }
        //yield return new WaitForSeconds(2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, Vector3.forward * 13f);
    }
}
