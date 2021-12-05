using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : PlayerPrefs
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("x", 0);
        PlayerPrefs.SetInt("y", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
