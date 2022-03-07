using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject winnerText;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Use this function to play sounds
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void GameEnded(string looser)
    {
        if (looser == "Red")
        {
            winnerText.GetComponent<Text>().text = "Blue wins!";
            winnerText.SetActive(true);
        }
        if (looser == "Blue")
        {
            winnerText.GetComponent<Text>().text = "Red wins!";
            winnerText.SetActive(true);
        }
    }
}
