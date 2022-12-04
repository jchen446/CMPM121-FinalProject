using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int damageAmount = 20;

    public int fireRate = 10;


    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public float timeBetweenAttacks;

    bool alreadyAttacked;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void Fire()
    {
        if (!alreadyAttacked)
        {
            muzzleFlash.Play();
            RaycastHit hit;
            if(Physics.Raycast(fpsCam.position + fpsCam.forward, fpsCam.forward, out hit, range))
            {
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                Enemy e = hit.transform.GetComponent<Enemy>();
                if(e != null)
                {
                    e.TakeDamage(damageAmount);
                    return;
                }

                Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
                GameObject impact = Instantiate(impactEffect, hit.point, impactRotation);
                impact.transform.parent = hit.transform;
                Destroy(impact, 5);
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    
}
