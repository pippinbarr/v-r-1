using UnityEngine;
using System.Collections;

public class GlobalControl : MonoBehaviour
{

    //    public string[] theLevels = new string[2]
    //    {
    //        "Intersection",
    //        "Door down",
    ////        "Door in floor",
    ////        "Door to door",
    //    };

    //    public int[] theLevelNumbers = new int[2]
    //    {
    //        2,
    //        3,
    ////        3,
    ////        4,
    //    };

    
    public string[] theLevels = new string[15]
    {
        "Intersection",
        "Door down",
        "Door in floor",
        "Door to door",
        "Floating objects",
        "Floating room",
        "Hole in floor",
        "Lean",
        "Locked out",
        "No light",
        "Organised",
        "Pieces",
        "Sunken",
        "Upside down",
        "Window to window",
    };
    
    public int[] theLevelNumbers = new int[15]
    {
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15
    };

    public int currentLevel = -1;

    // Use this for initialization
    void Start()
    {
        Debug.Log(theLevels.Length);
        DontDestroyOnLoad(gameObject);  
        reshuffle(theLevels, theLevelNumbers);
        for (int i = 0; i < theLevels.Length; i++)
        {
            Debug.Log(theLevels [i]);
        }
    }
	
    // Update is called once per frame
    void Update()
    {
	
    }

    void reshuffle(string[] texts, int[] levelNumbers)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            string tmp = texts [t];
            int r = Random.Range(t, texts.Length);
            texts [t] = texts [r];
            texts [r] = tmp;

            int tmp2 = levelNumbers [t];
            levelNumbers [t] = levelNumbers [r];
            levelNumbers [r] = tmp2;
        }
    }
}
