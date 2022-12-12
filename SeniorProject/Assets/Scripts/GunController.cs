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
    [SerializeField] public GameObject LV5Gun;
    [SerializeField] public GameObject LV6Gun;
    [SerializeField] public GameObject LV7Gun;

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
            else if (LV2Gun.activeSelf)
            {
                LV2toLV3();
                killsCounter = 0;
            }
            else if (LV3Gun.activeSelf)
            {
                LV3toLV4();
                killsCounter = 0;
            }
            else if (LV4Gun.activeSelf)
            {
                LV4toLV5();
                killsCounter = 0;
            }
            else if (LV5Gun.activeSelf)
            {
                LV5toLV6();
                killsCounter = 0;
            }
            else if (LV6Gun.activeSelf)
            {
                LV6toLV7();
                killsCounter = 0;
            }
        }
    }

    public void LV1toLV2()
    {
        LV1Gun.SetActive(false);
        LV2Gun.SetActive(true);
    }
    
    public void LV2toLV3()
    {
        LV2Gun.SetActive(false);
        LV3Gun.SetActive(true);
    }
    public void LV3toLV4()
    {
        LV3Gun.SetActive(false);
        LV4Gun.SetActive(true);
    }
    public void LV4toLV5()
    {
        LV4Gun.SetActive(false);
        LV5Gun.SetActive(true);
    }
    public void LV5toLV6()
    {
        LV5Gun.SetActive(false);
        LV6Gun.SetActive(true);
    }
    public void LV6toLV7()
    {
        LV6Gun.SetActive(false);
        LV7Gun.SetActive(true);
    }
    
}
