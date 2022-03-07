using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    Rigidbody rb;
    public KeyCode up, down, left, right;
    public float movementSpeed;
    public float rotationSpeed;
    public AudioSource rocketSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        // Input
        if (Input.GetKey(up))
        {
            rb.AddForce(transform.up * movementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(down))
        {
            rb.AddForce(transform.up * -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(left))
        {
            rb.AddTorque(transform.forward * rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(right))
        {
            rb.AddTorque(transform.forward * -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(up))
        {
            GetComponentInChildren<ParticleSystem>().Play();
            rocketSound.Play();
        }
        if (Input.GetKeyUp(up))
        {
            GetComponentInChildren<ParticleSystem>().Stop();
            rocketSound.Stop();
        }

        // Boundaries
        if (transform.position.x > 12)
        {
            transform.position -= new Vector3(23, 0, 0);
        }
        else if (transform.position.x < -12)
        {
            transform.position += new Vector3(23, 0, 0);
        }
        else if (transform.position.y > 7)
        {
            transform.position -= new Vector3(0, 13, 0);
        }
        else if (transform.position.y < -7)
        {
            transform.position += new Vector3(0, 13, 0);
        }
    }
}
