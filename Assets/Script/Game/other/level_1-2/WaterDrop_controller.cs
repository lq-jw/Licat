using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrop_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        // �p�G�I�����O���w������
        if (other.CompareTag("Player"))
        {
            print("WaterDrop   OnParticleCollision");
            // ��^�I����
            //GameManager.instance.AddScore(collisionValue); // �o�̰��]�A���@�� GameManager�A�éI�s�� AddScore ��k�ӼW�[����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("WaterDrop   OnTriggerEnter2D");
    }
}
