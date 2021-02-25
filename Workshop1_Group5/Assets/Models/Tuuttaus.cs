using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuuttaus : MonoBehaviour
{
    AudioSource ac;
    public AudioClip myclip;

    // Start is called before the first frame update
    void Start()
    {
        ac = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        ac.PlayOneShot(myclip);
    }
}
