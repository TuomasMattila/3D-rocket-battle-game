using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public ParticleSystem hitEffect;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.GetComponent<Health>();
        if (health != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            health.TakeDamage();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (transform.position.x > 12)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 7)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

}
