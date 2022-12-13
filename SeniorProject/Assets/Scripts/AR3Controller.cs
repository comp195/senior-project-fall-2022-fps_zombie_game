using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AR3Controller : MonoBehaviour
{
    public float damage = 100;
    public float range = 1000;
    public Camera fpsCam;
    public float fireRate = 1;
    [SerializeField] public TextMeshProUGUI ammo;

    [SerializeField] public GameObject Crosshair;
    public ParticleSystem muzzleflash;
    
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    
    public int MaxAmmo = 10;
    public int AmmoCount = 10;
    public float reloadTime = 3;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private LayerMask enemylayer;
    [SerializeField] public TextMeshProUGUI Reloading;

    private Animator anim;

    [SerializeField] public float RecoilSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.isStatic)
        {
            Crosshair.SetActive(true);
        }
        ammo.SetText(AmmoCount + "/" + MaxAmmo);
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + reloadTime;
            anim.speed = 1;
            anim.Play("Reload");
            isReloading = true;
            Reloading.gameObject.SetActive(true);
        }

        if (isReloading == true && Time.time >= nextTimeToFire)
        {
            AmmoCount = MaxAmmo;
            ammo.SetText(AmmoCount + "/" + MaxAmmo);
            isReloading = false;
            Reloading.gameObject.SetActive(false);
        }
            
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (AmmoCount > 0 )
            {
                nextTimeToFire = Time.time + fireRate;
                AmmoCount--; 
                Shoot();
                anim.speed = RecoilSpeed;
                anim.Play("Recoil");
                ammo.SetText(AmmoCount + "/" + MaxAmmo);
                
            }
            
        }
    }
    void Shoot()
    {
        Ray ray = new Ray();
        ray.origin = bulletPoint.position;
        ray.direction = bulletPoint.TransformDirection(Vector3.forward);
        muzzleflash.Play();
        RaycastHit hit;
        Debug.DrawRay(ray.origin,ray.direction*range,Color.yellow);
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, enemylayer))
        {
                
            var healthCtrl = hit.collider.GetComponent<EnemyController>();
            healthCtrl.takeDamage(damage);
        }
    }
    
    
}
