using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatforMotion : MonoBehaviour {


	[SerializeField] private Vector3 moveAxes = Vector2.zero;
	[SerializeField] private float distance = 3f;
    [SerializeField] private float speed = 3f;
	[SerializeField] private int direction = 1;


	private Transform thisTransform = null;
	private Vector3 origPos = Vector3.zero;


	// Use this for initialization
	void Awake () {
		thisTransform = GetComponent<Transform> ();
		origPos = thisTransform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		thisTransform.position = origPos + (direction * (moveAxes * Mathf.PingPong (Time.timeSinceLevelLoad * speed, distance))) ;
	}
}
