using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [Header("References")]
    [SerializeField] public Weapon gunData;
    [SerializeField] private Transform shootingPoint;
    //[SerializeField] private Transform camFirst;
    //[SerializeField] private Transform camThird;
    [SerializeField] private GameObject bulletPrefab;

    float timeSinceLastShot;

    private void Start()
    {
        PlayerAction.shootInput += Shoot;
        PlayerAction.reloadInput += StartReload;
        gunData.currentAmmor = gunData.Amminition;
    }

    private void OnDisable() => gunData.reloading = false;

    public void StartReload()
    {
        if (!gunData.reloading && this.gameObject.activeSelf)
            StartCoroutine(Reload());
        Debug.Log("StartReload");
    }

    private IEnumerator Reload()
    {
        gunData.reloading = true;

        gunData.currentAmmor = 20;

        yield return new WaitForSeconds(1f);


        gunData.reloading = false;


    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShot > 1f / (gunData.RateOfFire / 60f);

    private void Shoot()
    {
        if (gunData.currentAmmor > 0)
        {
            if (CanShoot())
            {

               SpawnPrefab();

                //if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, 1000f))
                //{
                //    IDamagable damageable = hitInfo.transform.GetComponent<IDamagable>();

                //    // Check if damageable is not null before calling TakeDamage
                //    if (damageable != null)
                //    {
                //        damageable.TakeDamage(gunData.Damage);
                //    }
                //}

                gunData.currentAmmor--;
                timeSinceLastShot = 0;
                OnGunShot();
            }
        }
    }

    // In the Gun script
    private void SpawnPrefab()
    {
        
        Quaternion quaternion = bulletPrefab.transform.rotation;
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        //bullet.GetComponent<Bullet>().Initialize(shootingPoint);
        Debug.Log("Spawn");
    }



    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(shootingPoint.position, shootingPoint.forward * gunData.MaxDistance);
    }

    private void OnGunShot() { }
}