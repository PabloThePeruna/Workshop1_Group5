using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janter : MonoBehaviour
{

    private HingeJoint hinge;

    private JointMotor motor;

    private GameManager gameManagerScript;

    private IEnumerator janterCoroutine;


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


            StartCoroutine(ExampleCoroutine());




        }
        /*
        else
        {
            motor.force = 10;
            motor.targetVelocity = -200;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
            print("Pitäisi kaatua");

        }
        */
        /*
        //Tähän "kun osuu, niin kaatuu)
        if (osuma)
        {
            motor.force = 10;
            motor.targetVelocity = -200;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
            print("Pitäisi kaatua");
        }
        */
    }

    IEnumerator ExampleCoroutine()
    {
        motor.force = 10;
        motor.targetVelocity = 200;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
        print("Pitäisi kääntyä pystyyn");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        motor.force = 10;
        motor.targetVelocity = -200;
        motor.freeSpin = false;
        hinge.motor = motor;
        hinge.useMotor = true;
        print("Pitäisi kaatua");

        yield return new WaitForSeconds(2);

        this.gameObject.SetActive(false);

    }




}
