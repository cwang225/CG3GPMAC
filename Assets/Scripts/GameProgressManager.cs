using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressManager : MonoBehaviour
{
    public static GameProgressManager instance;
    public bool[] levelCompleteStates = new bool[6];
    // Start is called before the first frame update
    void Awake() {
        if (instance != null && instance != this) {
            Destroy(instance);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        for (int i = 1; i < 6; i++) {
            levelCompleteStates[i] = false;
        }
        levelCompleteStates[0] = true;
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
