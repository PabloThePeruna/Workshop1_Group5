using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public bool peliAktiivinen;
    public bool jantteriAktiivinen;
    public GameObject aloitaButton;

    public Text timerText;
    private float alkuAika;

    public Text scoreText;
    private int scores;

    public List<GameObject> jantterit = new List<GameObject>();



    void Start()
    {
        scores = 0;
        alkuAika = 60;

        aloitaButton.SetActive(true);
        peliAktiivinen = false;
        /*
        //Deaktivoi jantterit
        for (int i = 0; i < jantterit.Count; i++)
        {
            jantterit[i].SetActive(false);
        }
        */

    }

    void Update()
    {


        if (peliAktiivinen == true)
        {

            alkuAika -= Time.deltaTime;

            scoreText.text = "Pisteet: " + scores.ToString();
            timerText.text = "Aika: " + alkuAika.ToString("F0");



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
        InvokeRepeating("JanterAktiivinen", 1f, 2f);  //yhden sekunnin viive, toistaa joka toinen sekunti

    }

}
