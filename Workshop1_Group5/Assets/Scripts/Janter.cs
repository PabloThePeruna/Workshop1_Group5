using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Janter : MonoBehaviour
{

    private HingeJoint hinge;

    private JointMotor motor;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();

        hinge = GetComponent<HingeJoint>();



    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.jantteriAktiivinen == true)
        {
            motor.force = 10;
            motor.targetVelocity = 200;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
            print("Pitäisi kääntyä pystyyn");

        }

        else
        {
            motor.force = 10;
            motor.targetVelocity = -200;
            motor.freeSpin = false;
            hinge.motor = motor;
            hinge.useMotor = true;
            print("Pitäisi kaatua");

        }

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



}
