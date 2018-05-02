using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeMotion : MonoBehaviour
{
    [SerializeField] private GameObject target = null;
    private Transform thisTransform = null;

    void Awake()
    {
        thisTransform = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 dir = target.gameObject.transform.position - thisTransform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        thisTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
