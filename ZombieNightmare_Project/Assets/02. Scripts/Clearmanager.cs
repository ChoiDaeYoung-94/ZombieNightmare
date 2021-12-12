using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clearmanager : MonoBehaviour
{
    private int score;
    public Text scoreText;

    public GameObject gameOver_text, gameOver_constent_Object;
    public Text gameOver_constent;
    public GameObject gameOver_Image;

    public GameObject clear_text, clear_constent_Object;
    public Text clear_constent;

    public GameObject clear_backImage;
    public GameObject over_backImage;

    string clearT;
    string gameoverT;

    public GameObject menu;

    AudioSource Source_GM;

    public AudioSource Source;
    public AudioSource Source_2;
    public AudioClip clearSound;
    public AudioClip overSound;
    public AudioClip keyboard;
    public AudioClip keyboard_clear;

    void Start()
    {
        Source_GM = gameManager.instance_GM.GetComponent<AudioSource>();
        Source_GM.Stop();

        score = gameManager.instance_GM.score;
        scoreText.text = "Score: " + score.ToString();

        clearT = ".,.,.,.,여,긴, ,어,디,지,?, ,\n여,기,는, ,장,윤,철, ,연,구,소,네, ,\n이,미, ,좀,비,가, ,되,어,버,린, ,사,람,들,은, ,모,두, ,소,탕,하,였,다,네,.,.,.," +
            "\n자,네,가, ,가,지,고, ,온, ,백,신, ,덕,분,에, ,좀,비,의, ,확,산,을, ,막,을, ,수, ,있,게, ,되,었,어, ,고,맙,네,., ,\n이,렇,게, ,좀,비, ,사,건,은, " +
            "끝,나,게, ,되,었,고, ,무,분,별,한, ,약,물, ,연,구,는, ,중,단,되,었,다,.";
        gameoverT = "이,름,:, ,박, ,대, ,철,\n나,이,:,2,5,\n혈,액,형,:, ,A,B,형,\n좀,비,와,의, ,전,투, ,중, ,사,망";

        if(gameManager.instance_GM.gameOver == true)
        {
            PlayerPrefs.SetInt("nowScore", score);
            Source.PlayOneShot(overSound, 1.0f);
            gameOver_text.SetActive(true);
            gameOver_constent_Object.SetActive(true);
            gameOver_Image.SetActive(true);
            over_backImage.SetActive(true);
            StartCoroutine(PlusText_over(gameoverT));
            Source_2.PlayOneShot(keyboard, 1.0f);
        }
        else
        {
            PlayerPrefs.SetInt("nowScore", score);
            Source.PlayOneShot(clearSound, 1.0f);
            clear_text.SetActive(true);
            clear_constent_Object.SetActive(true);
            clear_backImage.SetActive(true);
            StartCoroutine(PlusText_clear(clearT));
            Source_2.PlayOneShot(keyboard_clear, 1.0f);
        }
    }

    IEnumerator PlusText_over(string string_text)
    {
        string[] split_text = string_text.Split(',');

        for (int i = 0; i < split_text.Length; i++)
        {
            gameOver_constent.text += split_text[i];
            yield return new WaitForSeconds(0.12f);
        }
        menu.SetActive(true);
    }

    IEnumerator PlusText_clear(string string_text)
    {
        string[] split_text = string_text.Split(',');
        
        for (int i = 0; i < split_text.Length; i++)
        {
            clear_constent.text += split_text[i];
            yield return new WaitForSeconds(0.06f);  
        }
        menu.SetActive(true);
    }
}
