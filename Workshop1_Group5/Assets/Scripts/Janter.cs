using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janter : MonoBehaviour
{

    private HingeJoint hinge;

    private JointMotor motor;

    private GameManager gameManagerScript;

    private IEnumerator janterCoroutine;

    //private int randomJanterPystyyn;



    // Start is called before the first frame update
    void Start()
    {
        //janterCoroutine = Janterajastin();


        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        hinge = GetComponent<HingeJoint>();



    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.jantteriAktiivinen == true)
        {
            StartCoroutine(JanterCoroutine());
        }
        //randomJanterPystyyn = Random.Range(1, 3);


    }

    IEnumerator JanterCoroutine()
    {
        motor.force = 50;
        motor.targetVelocity = 200;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
        print("Pitäisi kääntyä pystyyn");

        yield return new WaitForSeconds(1);

        motor.force = 50;
        motor.targetVelocity = -200;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
        print("Pitäisi kaatua");

        yield return new WaitForSeconds(3);

        this.gameObject.SetActive(false);

    }

    public void KaadaJantteri()
    {
        motor.force = 50;
        motor.targetVelocity = -200;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
        print("Pitäisi kaatua osumasta");
    }


}
