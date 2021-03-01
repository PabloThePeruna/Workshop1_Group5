using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject kiilto;

    private int kiiltoSpeed = 900;


    private void Update()
    {
        kiilto.transform.position += new Vector3(1 * Time.deltaTime * kiiltoSpeed, 0, 0);

        if (kiilto.transform.position.x > 4000)
        {
            kiilto.transform.position = new Vector3(-570, 0, 0);
        }

    }


    public void PlayGame()
    {
        Debug.Log("Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
       
    }
}
