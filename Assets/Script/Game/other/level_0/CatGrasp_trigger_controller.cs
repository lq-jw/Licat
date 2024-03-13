using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����ߧ�O���� F �����
public class CatGrasp_trigger_controller : MonoBehaviour
{
    public GameObject trigger;
    public Animator Big_cat_ani;

    void Start()
    {
        Hide(trigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Show(trigger);
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        Hide(trigger);
    }


    public void Show(GameObject trigger)
    {
        trigger.SetActive(true);
    }
    public void Hide(GameObject trigger)
    {
        trigger.SetActive(false);
    }
}
