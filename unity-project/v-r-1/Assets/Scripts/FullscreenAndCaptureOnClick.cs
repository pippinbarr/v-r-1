using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class FullscreenAndCaptureOnClick : MonoBehaviour
{

    private bool ready = false;

    // Use this for initialization
    void Start()
    {
	
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ready)
        {
            // Get highest resolution supported by the current screen.
            Resolution resolution = Screen.resolutions [Screen.resolutions.Length - 1];
 
            // The last parameter "true" denotes if it should be fullscreen or not.

            Screen.SetResolution(resolution.width, resolution.height, true);

            Screen.fullScreen = true;

            Screen.lockCursor = true;

            ready = true;

            StartCoroutine(NextScene());

        }
    }

    IEnumerator NextScene()
    {

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("_Title");
    }
}
