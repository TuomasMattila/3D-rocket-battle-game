using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public GameObject laser;
    public KeyCode shootKey;
    public AudioClip laserSound;
    public float laserSpeed;
    double cooldown;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
        gameManager = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(shootKey) && cooldown < 0)
        {
            gameManager.PlaySound(laserSound);
            cooldown = 1.05;
            GameObject instatiatedObject = Instantiate(laser, transform.position + (float)1.1 * transform.up, Quaternion.identity);
            instatiatedObject.GetComponent<Rigidbody>().velocity = laserSpeed * transform.up;
        }
        cooldown -= Time.deltaTime;
    }
}
