using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool peliAktiivinen;
    public bool jantteriAktiivinen;
    public GameObject aloitaButton;
    public GameObject loppuPanel;

    public Text timerText;
    private float alkuAika;



    public Text scoreText;
    public Text scoreTextEnd;
    private int scores;

    public List<GameObject> jantterit = new List<GameObject>();



    void Start()
    {
        scores = 0;
        alkuAika = 60;

        aloitaButton.SetActive(true);
        loppuPanel.SetActive(false);
        peliAktiivinen = false;
        
        //Deaktivoi jantterit aluksi
        for (int i = 0; i < jantterit.Count; i++)
        {
            jantterit[i].SetActive(false);
        }
        

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

        //Kun aika ja peli loppuu
        if (alkuAika <= 0)
        {
            loppuPanel.SetActive(true);
            scoreText.text = " ";
            scoreTextEnd.text = "Scores: " + scores.ToString();
            timerText.text = " ";
        }
                
    }

    void JanterAktiivinen()
    {

        print("toistaa " + alkuAika.ToString("F0"));

        jantterit[Random.Range(0, jantterit.Count)].SetActive(true);
        jantteriAktiivinen = true;
        print("Satunnainen jantteri aktiiviseksi");
    }



    public void AloitaPeli()
    {
        aloitaButton.SetActive(false);
        peliAktiivinen = true;
        //Aktivoi satunnaisia janttereita
        InvokeRepeating("JanterAktiivinen", 2f, 2f);  //Kahden sekunnin alkuviive, toistaa joka toinen sekunti

    }

}
