using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AR4Controller : MonoBehaviour
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
    public Vector3 Recoil;
    private Vector3 orignalRotation;
    [SerializeField] public Vector3 fixRecoilRotation;
    [SerializeField] public Vector3 reloadRotation;
    public float reloadTime = 3;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private LayerMask enemylayer;

    [SerializeField] public AnimationClip RecoilAnim;

    private Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        orignalRotation = transform.localEulerAngles;
            
        if (gameObject.isStatic)
        {
            Crosshair.SetActive(true);
        }
        ammo.SetText(AmmoCount + "/" + MaxAmmo);
        anim = GetComponent<Animation>();
        anim.clip = RecoilAnim;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("r")&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + reloadTime;
            transform.localEulerAngles += reloadRotation;
            isReloading = true;
        }

        if (isReloading == true && Time.time >= nextTimeToFire)
        {
            transform.localEulerAngles = orignalRotation;
            AmmoCount = MaxAmmo;
            ammo.SetText(AmmoCount + "/" + MaxAmmo);
            isReloading = false;
        }
            
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            if (AmmoCount > 0 )
            {
                nextTimeToFire = Time.time + fireRate;
                AmmoCount--; 
                Shoot();
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
