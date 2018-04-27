using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] private int sceneDestination = 0;

    private Animator fadeAnimator = null;

    private int fadeOutTrigger = Animator.StringToHash("FadeIn");
    private int fadeInTrigger = Animator.StringToHash("FadeOut");
	private float fadeOutTriggerDelay = 1.9f;


    void Start()
    {
        fadeAnimator = GetComponent<Animator>();

        if (fadeAnimator != null)
            fadeAnimator.SetTrigger(fadeInTrigger);
    }


    public void SceneChange()
    {
        int y = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Pervious scene: " + y);
        PlayerPrefs.SetFloat("PreviousScene", y);
        SceneManager.LoadScene(sceneDestination);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;

        if (Time.timeSinceLevelLoad >= fadeOutTriggerDelay)
            fadeAnimator.SetTrigger(fadeOutTrigger);
    }

}
