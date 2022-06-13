using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DisplaySceneNumber : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.Find("GlobalObject");

        if (go)
        {
            GlobalControl gc = go.GetComponent<GlobalControl>();

            int levelNum = gc.currentLevel;
            if (levelNum == -1)
            {
                GetComponent<Text>().text = "" + 1;
            }
            else if (SceneManager.GetActiveScene().name == "_End")//levelNum == 15)
            {
                GetComponent<Text>().text = "" + 17;
            }
            else
            {
                GetComponent<Text>().text = "" + gc.theLevelNumbers [levelNum];
            }
        }
        else
        {
            GetComponent<Text>().text = "No global.";
        }
        StartCoroutine(DelayedRemoveText());
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    IEnumerator DelayedRemoveText()
    {
        GetComponent<Text>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<Text>().enabled = true;
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        GetComponent<Text>().enabled = false;

    }
}
