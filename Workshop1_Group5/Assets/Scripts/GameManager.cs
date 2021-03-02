using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool peliAktiivinen;
    public bool jantteriAktiivinen;

    private bool playAudio = true;
    private bool playAudio2 = true;
    private bool playAudio3 = true;
    private bool playAudio4 = true;


    public GameObject aloitaButton;
    public GameObject loppuPanel;

    public AudioClip intro;
    public AudioClip afterFirstShot;
    public AudioClip ceaseFire;
    public AudioClip GO;
    public AudioClip sec5;
    public AudioClip sec15;
    public AudioClip sec30;
    public AudioClip oneTwoThree;

    public AudioSource leftSpeaker;
    public AudioSource rightSpeaker;

    //private IEnumerator WaitCoroutine2;


    public Text timerText;
    private float alkuAika;



    public Text scoreText;
    public Text scoreTextEnd;
    public int scores;

    public List<GameObject> jantterit = new List<GameObject>();



    void Start()
    {
        scores = 0;
        alkuAika = 60;

        aloitaButton.SetActive(false);
        loppuPanel.SetActive(false);
        peliAktiivinen = false;

        leftSpeaker.PlayOneShot(intro);
        rightSpeaker.PlayOneShot(intro);



        StartCoroutine(WaitCoroutine());



        //Aktivoi jantterit aluksi
        for (int i = 0; i < jantterit.Count; i++)
        {
            jantterit[i].SetActive(true);
        }
        WaitCoroutine();


    }

    void Update()
    {
        //Päivittää pisteet ja ajankulun teksteihin
        if (peliAktiivinen == true)
        {

            alkuAika -= Time.deltaTime;

            scoreText.text = "Scores: " + scores.ToString();
            timerText.text = "Time: " + alkuAika.ToString("F0");



        }

        if (alkuAika <= 30)
        {
            if (playAudio)
            {
                leftSpeaker.PlayOneShot(sec30);
                rightSpeaker.PlayOneShot(sec30);
                playAudio = false;

            }
        }

        if (alkuAika <= 15)
        {
            if (playAudio2)
            {
                leftSpeaker.PlayOneShot(sec15);
                rightSpeaker.PlayOneShot(sec15);
                playAudio2 = false;
            }
        }

        if (alkuAika <= 5)
        {
            if (playAudio3)
            {
                leftSpeaker.PlayOneShot(sec5);
                rightSpeaker.PlayOneShot(sec5);
                playAudio3 = false;
            }
        }

        //Kun aika ja peli loppuu
        if (alkuAika <= 0)
        {
            loppuPanel.SetActive(true);

            // Saadaan toi "Aloita peli" teksti pisteiden edestä pois
            aloitaButton.SetActive(false);

            scoreText.text = " ";
            scoreTextEnd.text = "Scores: " + scores.ToString();
            timerText.text = " ";
            peliAktiivinen = false;
            jantteriAktiivinen = false;


            if (playAudio4)
            {
                leftSpeaker.PlayOneShot(ceaseFire);
                rightSpeaker.PlayOneShot(ceaseFire);
                playAudio4 = false;
            }



        }

    }

    void JanterAktiivinen()
    {
        if (peliAktiivinen == true)
        {
            print("toistaa " + alkuAika.ToString("F0"));

            jantterit[Random.Range(0, jantterit.Count)].SetActive(true);
            jantteriAktiivinen = true;
            print("Satunnainen jantteri aktiiviseksi");
        }

    }



    public void AloitaPeli()
    {


        aloitaButton.SetActive(false);
        peliAktiivinen = true;
        //Aktivoi satunnaisia janttereita



        InvokeRepeating("JanterAktiivinen", 2f, 2f);  //Kahden sekunnin alkuviive, toistaa joka toinen sekunti

    }

    public void Restart()
    {
        SceneManager.GetActiveScene();
        SceneManager.LoadScene("TahdonOllaLääkintäMies");
    }

    IEnumerator WaitCoroutine()
    {

        yield return new WaitForSeconds(4);
        leftSpeaker.PlayOneShot(afterFirstShot);
        rightSpeaker.PlayOneShot(afterFirstShot);
        yield return new WaitForSeconds(5);

        peliAktiivinen = true;
        AloitaPeli();

    }


}
