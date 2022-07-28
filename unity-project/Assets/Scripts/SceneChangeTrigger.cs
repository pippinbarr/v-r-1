using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{

    public AudioSource lowDrone;
    public AudioSource highDrone;
    public int sceneSwitchDelay = 20;
    public float highFadeSpeed = 0.01f;
    public float lowFadeSpeed = 0.01f;

    private bool timerTriggered = false;
    private float lowFadeDir = 1;
    private float highFadeDir = 0;
    private bool switching = false;

    // Use this for initialization
    void Start()
    {
        lowFadeDir = 1;
        lowDrone.pitch = 1 + Random.Range(-0.2f, 0.2f);
        lowDrone.Play();
        lowDrone.volume = 1;

        highDrone.volume = 0;

        Invoke("DelayedSwitchScene", sceneSwitchDelay);
    }
	
    // Update is called once per frame
    void FixedUpdate()
    {
        handleFade(lowDrone, lowFadeDir, lowFadeSpeed);
        handleFade(highDrone, highFadeDir, highFadeSpeed);

        if (highDrone.volume >= 1 && !switching)
        {          
            GameObject globalObject = GameObject.Find("GlobalObject");

            Debug.Log("Previous level was: " + globalObject.GetComponent<GlobalControl>().currentLevel);
            globalObject.GetComponent<GlobalControl>().currentLevel++;


            // Added to have infinite scenes
//            if (globalObject.GetComponent<GlobalControl>().currentLevel >= globalObject.GetComponent<GlobalControl>().theLevels.Length)
//            {
//                globalObject.GetComponent<GlobalControl>().currentLevel = 0;
//            }
            // end add infinite scenes

            int sceneIndex = globalObject.GetComponent<GlobalControl>().currentLevel;
            string nextScene = "";


            Debug.Log("Scene index pre-calculate level is: " + sceneIndex);
            Debug.Log("currentLevel pre-calculate level is: " + globalObject.GetComponent<GlobalControl>().currentLevel);

            // Commented out for infinite scenes


            if (sceneIndex == 15)
            {
                globalObject.GetComponent<GlobalControl>().currentLevel = -1;
                nextScene = "_End";
            }
            else
            {
                nextScene = globalObject.GetComponent<GlobalControl>().theLevels [sceneIndex];
            }
            // end commenting for infinite scenes

            Debug.Log("Scene index pre-load is: " + sceneIndex);
            Debug.Log("currentLevel pre-load is: " + globalObject.GetComponent<GlobalControl>().currentLevel);


            switching = true;
            SceneManager.LoadScene(nextScene);
        }
    }

    void handleFade(AudioSource drone, float fadeDir, float fadeSpeed)
    {
        drone.volume = Mathf.Clamp(drone.volume + (fadeDir * fadeSpeed), 0, 1);
    }

    void OnTriggerEnter(Collider other)
    {
        if (highFadeDir != 1)
        {
            highFadeDir = 1;
            highDrone.Play();
            highDrone.volume = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (timerTriggered)
            return;

        highFadeDir = -1;
    }

    void DelayedSwitchScene()
    {

        // Code to execute after the delay
        highFadeDir = 1;
        highDrone.Play();
        highDrone.volume = 0;

        timerTriggered = true;

    }
}
