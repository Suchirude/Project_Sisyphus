using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public int sceneToLoad;
    public void changeScenes()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
