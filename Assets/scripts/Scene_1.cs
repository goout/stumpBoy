using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_1 : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private Vector3 returnPos1 = new Vector3(3.3f, -10.8f, 0.0f);

    private Vector3 returnPos2 = new Vector3(11f, -2.62f, 0.0f);

    void Start()
    {

        if (PlayerPrefs.GetFloat("PreviousScene") == 2)
        {
            player.transform.position = returnPos1;
        }

        if (PlayerPrefs.GetFloat("PreviousScene") == 4)
        {
            player.transform.position = returnPos2;
        }

    }

}
