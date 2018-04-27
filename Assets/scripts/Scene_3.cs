using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_3 : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private Vector3 returnPos = new Vector3(11.19f, 0.43f, 0.0f);


    // Use this for initialization
    void Start()
    {
        if (PlayerPrefs.GetFloat("PreviousScene") == 5)
        {
            player.transform.position = returnPos;

        }
    }

}
