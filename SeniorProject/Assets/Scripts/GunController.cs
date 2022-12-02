using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public float killsCounter = 0;
    public float levelCap = 3;

    [SerializeField] public GameObject LV1Gun;
    [SerializeField] public GameObject LV2Gun;
    [SerializeField] public GameObject LV3Gun;
    [SerializeField] public GameObject LV4Gun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addKill()
    {
        killsCounter++;
        if (killsCounter == levelCap)
        {
            if (LV1Gun.activeSelf)
            {
                LV1toLV2();
                killsCounter = 0;
            }
        }
    }

    public void LV1toLV2()
    {
        LV1Gun.SetActive(false);
        LV2Gun.SetActive(true);
    }
    
}
