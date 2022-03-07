using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    private Image[] hearts;
    private int heartsShown;

    [Tooltip("sprite. Meaning .jpg .png or some fiel like that.")]
    public Sprite heart;
    [Tooltip("just drag a Player GameObject that has Elamat component, here")]
    public Health player;

    [Header("Heart Layout")]
    [Tooltip("hearts can form a vertical or horizontal line.")]
    public bool verticalHearts = false;
    [Tooltip("the line of hearts can point to the negative or positive direction of the axel.")]
    public bool flip = false;

    private float imageScale = 0.4f; 

    private void Start()
    {
        float offset = imageScale * 100;
        int hp = player.amount;
        hearts = new Image[hp];
        for (int i = 0; i < hp; i++)
        {
            hearts[i] = new GameObject().AddComponent<Image>();
            hearts[i].sprite = heart;
            hearts[i].transform.SetParent(transform, false);
            float pos = flip ? -i*offset : i*offset; // if : else
            hearts[i].transform.position = new Vector3(Convert.ToInt32(!verticalHearts) * pos, Convert.ToInt32(verticalHearts) * pos) + transform.position;
            hearts[i].transform.localScale = new Vector3(imageScale, imageScale, imageScale);
        }
        heartsShown = hearts.Length;
    }

    // Update is called once per frame
    void Update ()
    {
        if (player == null)
            Destroy(gameObject);

        //tämä on melkoisen epätehokas tapa hoitaa tämä toiminnallisuus. Jos haluat niin voit tallentaa tarjota tämän komponentin pelaajan Elamat scriptille
        //käytetäväksi ja kutsua UpdateHealthBar() methodia tämän sijainnin sijaan sieltä pelaajan Elamat scriptistä siinä kohdassa koodia missä Elamat ottaa damagea.
        UpdateHealthBar(player.amount);
    }

    public void UpdateHealthBar(int currentHealth)
    {
        while (heartsShown > currentHealth)
        {
            Destroy(hearts[heartsShown - 1].gameObject);
            heartsShown--;
        }
    }
}
