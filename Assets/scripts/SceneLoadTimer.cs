using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadTimer : MonoBehaviour
{

    [SerializeField] private int sceneID = 1;
    [SerializeField] private float timeDelay = 4f;

    [SerializeField] private bool IsSpash = false;

    // Death Particles! don't delete
    void Start()
    {
        Invoke("loadScene", timeDelay);
        if (IsSpash)
        {
            PlayerPrefs.DeleteAll();
        }
    }

    void loadScene()
    {
        SceneManager.LoadScene(sceneID);
    }

}
