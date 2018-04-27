using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCameraCntrl : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private float offset;

    void Start()
    {
        offset = transform.position.y - player.transform.position.y;
    }

    void LateUpdate()
    {
        if (player != null)
            transform.position = new Vector3(transform.position.x, player.transform.position.y + offset, transform.position.z);

    }
}
