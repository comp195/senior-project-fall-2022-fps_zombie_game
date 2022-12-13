using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pistol4Controller : MonoBehaviour
{
    public float damage = 40;
    public float range = 100;
    public Camera fpsCam;
    public float fireRate = 1;
    [SerializeField] public TextMeshProUGUI ammo;

    [SerializeField] public GameObject Crosshair;
    public ParticleSystem muzzleflash;
    
    private float nextTimeToFire = 0f;
    private bool isReloading = false;
    
    public int MaxAmmo = 17;
    public int AmmoCount = 17;
    public Vector3 Recoil;
    private Vector3 orignalRotation;
    [SerializeField] public Vector3 reloadRotation;
    public float reloadTime = 3;
    [SerializeField] private Transform bulletPoint;
    [SerializeField] private LayerMask enemylayer;
    [SerializeField] public TextMeshProUGUI Reloading;
    private AudioSource audio;
    [SerializeField] public AudioClip gunshot;
    [SerializeField] public AudioClip reloadSound;   
    // Start is called before the first frame update
    void Start()
    {
        orignalRotation = transform.localEulerAngles;
        audio = gameObject.GetComponent<AudioSource>();
        if (gameObject.isStatic)
        {
            Crosshair.SetActive(true);
        }
        ammo.SetText(AmmoCount + "/" + MaxAmmo);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")&& Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + reloadTime;
            transform.localEulerAngles += reloadRotation;
            isReloading = true;
            Reloading.gameObject.SetActive(true);
        }

        if (isReloading == true && Time.time >= nextTimeToFire)
        {
            audio.PlayOneShot(reloadSound);
            transform.localEulerAngles = orignalRotation;
            AmmoCount = MaxAmmo;
            ammo.SetText(AmmoCount + "/" + MaxAmmo);
            isReloading = false;
            Reloading.gameObject.SetActive(false);
        }
            
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            if (AmmoCount > 0 )
            {
                nextTimeToFire = Time.time + fireRate;
                AddRecoil();
                AmmoCount--; 
                Shoot();
                audio.volume = 0.5f;
                audio.PlayOneShot(gunshot);
                ammo.SetText(AmmoCount + "/" + MaxAmmo);
            }
                
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopRecoil();
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
    
    private void AddRecoil()
    {
        transform.localEulerAngles += Recoil;
    }
    
    private void StopRecoil()
    {
        transform.localEulerAngles = orignalRotation;
    }
}
