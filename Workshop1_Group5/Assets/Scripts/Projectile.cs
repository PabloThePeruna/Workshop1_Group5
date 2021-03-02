using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private GameManager gameManagerScript;
    private Janter janterScript;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        janterScript = GameObject.FindGameObjectWithTag("Jantteri").GetComponent<Janter>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Jantteri"))
        {
            gameManagerScript.scores++;
            Debug.Log("Osuma");
            janterScript.KaadaJantteri();
            source.Play();
        }
    }
}
