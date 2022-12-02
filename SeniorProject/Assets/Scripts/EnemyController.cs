using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Hitpoint = 100;
    [SerializeField] public GameObject gunController;
    
    public void takeDamage(float damage)
    {
        
        Hitpoint -= damage;
        
        if (Hitpoint <= 0)
        {
            Debug.Log(Hitpoint);
            killEnemy();
            
        }
    }

    void killEnemy()
    {
        Destroy(this.gameObject);
        ScoreManager.instance.AddPoint();
        gunController.GetComponent<GunController>().addKill();
        
        
    }
}
