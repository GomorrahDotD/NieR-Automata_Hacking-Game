using System.Collections;
using UnityEngine;

public class mbGun : MonoBehaviour
{
    [Header("Location of Nozzle and Bulletprefab")]
    public Transform gunNozzle;
    public GameObject bulletPrefab;

    public AudioClip shootEffect;
    public AudioSource audioSource;

    [Header("Values for Testing")]
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float ammoCapacity;
    [SerializeField] private float refillRate;

    private float currentAmmo;
    private bool isShooting;
    private float cooldown = 1f;
    private void Start()
    {
        currentAmmo = ammoCapacity;
        audioSource.clip = shootEffect;
    }
    void Update()
    {
        isShooting = Input.GetButton("Fire1");

        if (currentAmmo > 1 && isShooting && cooldown == 0)
        {
            ShootAmmo();
            currentAmmo -= 1;
            cooldown = 1f;
        }

        cooldown = Mathf.Clamp(((cooldown / fireRate) - Time.deltaTime), 0f, 1f);
        currentAmmo = Mathf.Clamp(currentAmmo + (Time.deltaTime * refillRate), 0f, ammoCapacity);

    }

    void ShootAmmo()
    {
        
        audioSource.Play();
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, new Vector3(gunNozzle.position.x, 0.8f, gunNozzle.position.z), gunNozzle.rotation);
    }
}
