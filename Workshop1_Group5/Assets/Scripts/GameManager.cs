using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool peliAktiivinen;
    public bool jantteriAktiivinen;
    public GameObject aloitaButton;

    private float turnSpeed = 2.0f;


    public List<GameObject> jantterit = new List<GameObject>();

    private IEnumerator janterSelectCoroutine;


    void Start()
    {
        aloitaButton.SetActive(true);
        peliAktiivinen = false;

        janterSelectCoroutine = JanterSelectAjastin(Random.Range(2.0f, 5.0f));

        
        //Deaktivoi jantterit
        for (int i = 0; i < jantterit.Count; i++)
        {
            jantterit[i].SetActive(false);
        }
        

    }

    void Update()
    {
        if (peliAktiivinen == true)
        {
            StartCoroutine(janterSelectCoroutine);

        }


    }

    void JanterAktiivinen()
    {

    }

    private IEnumerator JanterSelectAjastin(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);


            jantterit[Random.Range(0, jantterit.Count)].SetActive(true);
            jantteriAktiivinen = true;
            print("Satunnainen jantteri aktiiviseksi");
        



        
    }


    public void AloitaPeli()
    {
        aloitaButton.SetActive(false);
        peliAktiivinen = true;
    }

}
