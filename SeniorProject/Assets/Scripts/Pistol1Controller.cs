using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol1Controller : MonoBehaviour
{
    public float damage = 10;
        public float range = 100;
        public Camera fpsCam;
        public float fireRate = 15;
    
        [SerializeField] public GameObject Crosshair;
        public ParticleSystem muzzleflash;
    
        private float nextTimeToFire = 0f;
    
        public int MaxAmmo = 6;
        public int AmmoCount = 6;
        public Vector3 Recoil;
        private Vector3 orignalRotation;
        
        // Start is called before the first frame update
        void Start()
        {
            orignalRotation = transform.localEulerAngles;
            if (gameObject.isStatic)
            {
                Crosshair.SetActive(true);
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            
            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 2f / fireRate;
                AddRecoil();
                Shoot();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                StopRecoil();
            }
            
            
        }
        
        void Shoot()
        {
            muzzleflash.Play();
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
    
                GraphicsBuffer.Target target = hit.transform.GetComponent<GraphicsBuffer.Target>();
                if (target != null)
                {
                    //target.takeDamage(damage);
                }
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
