using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_2 : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private Vector3 returnPos = new Vector3(11.11f, -4.32f, 0.0f);


    void Start()
    {
        if (PlayerPrefs.GetFloat("PreviousScene") == 3)
        {
            player.transform.position = returnPos;

        }
    }

}
