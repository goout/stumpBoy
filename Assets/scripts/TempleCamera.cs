using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TempleCamera : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject sceneBackground;

    private float borderX;

    private float borderY;

    private Vector3 offset;

    private Vector3 offsetY;

    private Vector3 playerPos;

    private Vector3 transformPos;

    private bool offsetSet = false;

    private Camera cam;


    void Start()
    {
        cam = transform.GetComponent<Camera>();

        float vertExtent = cam.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        SpriteRenderer backgroundRenderer = sceneBackground.GetComponent<SpriteRenderer>();

        borderX = Mathf.Abs(backgroundRenderer.bounds.extents.x) - Mathf.Abs(sceneBackground.transform.position.x - horzExtent);
        borderY = Mathf.Abs(backgroundRenderer.bounds.extents.y) - Mathf.Abs(sceneBackground.transform.position.y - vertExtent);

        offsetY = transform.position - player.transform.position;

    }

    void LateUpdate()
    {
        playerPos = player.transform.position;
        transformPos = transform.position;

        if ((transformPos - playerPos).x < 2 && !offsetSet)
        {
            offsetSet = true;
            offset = transformPos - playerPos;
        }

        if (((playerPos + offset).x >= 0 && (playerPos + offset).x <= borderX))
            transform.position = new Vector3((playerPos + offset).x, transformPos.y, transformPos.z);

        transformPos = transform.position;

        if (((playerPos + offsetY).y >= 0 && (playerPos + offsetY).y <= borderY))
            transform.position = new Vector3(transformPos.x, (playerPos + offsetY).y, transformPos.z);
    }
}
