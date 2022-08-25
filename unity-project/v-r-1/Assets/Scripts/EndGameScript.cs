using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class EndGameScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("CutToBlack", 15);

    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void CutToBlack()
    {
//        GetComponent<AudioSource>().Play();
//        SceneManager.LoadScene("_Black");
        SceneManager.LoadScene("_Start");

    }
}
