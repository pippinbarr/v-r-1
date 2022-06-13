using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class TitleScript : MonoBehaviour
{

    public AudioSource highDrone;

    public GameObject titleV;
    public GameObject titleR;
    public GameObject title1;

    private float showChance = 0.0f;
    private float titleSpeed = 0.004f;

    // Use this for initialization
    void Start()
    {
        highDrone.volume = 0.0f;
        highDrone.Play();

        titleV.GetComponent<Text>().enabled = false;
        titleR.GetComponent<Text>().enabled = false;
        title1.GetComponent<Text>().enabled = false;

        Screen.lockCursor = true;
        Cursor.visible = false;
    }
	
    // Update is called once per frame
    void Update()
    {
        highDrone.volume += titleSpeed;

        titleV.GetComponent<Text>().enabled = (Random.Range(0f, 1f) < showChance);
        titleR.GetComponent<Text>().enabled = (Random.Range(0f, 1f) < showChance);
        title1.GetComponent<Text>().enabled = (Random.Range(0f, 1f) < showChance);

        showChance += titleSpeed / 2;

        if (highDrone.volume >= 1)
        {
            titleV.GetComponent<Text>().enabled = false;
            titleR.GetComponent<Text>().enabled = false;
            title1.GetComponent<Text>().enabled = false;

            SceneManager.LoadScene("_Start");
        }
    }
}
