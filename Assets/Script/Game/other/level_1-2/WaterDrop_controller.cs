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
        // 如果碰撞的是指定的物體
        if (other.CompareTag("Player"))
        {
            print("WaterDrop   OnParticleCollision");
            // 返回碰撞值
            //GameManager.instance.AddScore(collisionValue); // 這裡假設你有一個 GameManager，並呼叫其 AddScore 方法來增加分數
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("WaterDrop   OnTriggerEnter2D");
    }
}
