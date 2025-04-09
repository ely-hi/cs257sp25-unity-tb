using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{

    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    public int bulletsAmount;
    Animator animator;

    public int fireRate;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    void OnFire(InputValue value)
    {
        // if (value.isPressed && bulletsAmount > 0 && Time.timeScale > 0) {

        //     bulletsAmount--;
            
        //     GameObject clone = Instantiate(prefab);

        //     clone.transform.position = shootPoint.transform.position;
        //     clone.transform.rotation = shootPoint.transform.rotation;

        //     muzzleEffect.Play();
        //     shootSound.Play();
        // }
        animator.SetBool("Shooting", value.isPressed);

        if (value.isPressed) {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        else
        {
            CancelInvoke();
        }
    }

    private void Shoot() {
        if(bulletsAmount > 0 && Time.timeScale > 0) {
            bulletsAmount--;

            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

            muzzleEffect.Play();
            shootSound.Play();
        }
    }

}
