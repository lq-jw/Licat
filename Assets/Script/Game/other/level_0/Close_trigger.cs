using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close_trigger : MonoBehaviour
{
    public GameObject trigger;

    public void Show(GameObject triangle)
    {
        triangle.SetActive(true);
    }
    public void Hide(GameObject triangle)
    {
        triangle.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Show(trigger);
        print("enter");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Hide(trigger);
        print("exit");
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide(trigger);
    }
}
