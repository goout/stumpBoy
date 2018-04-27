
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class QuestItem : MonoBehaviour
{

    [SerializeField] private string questName;
    private AudioSource audioSource = null;
    private SpriteRenderer spriteRenderer = null;
    private Collider2D itemCollider = null;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        itemCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        //Hide object
        gameObject.SetActive(false);

        //Show object if quest is assigned
        if (PlayerPrefs.GetInt(questName) == 1)
            gameObject.SetActive(true);
    }

    //If item is visible and collected
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (!gameObject.activeSelf) return;

        PlayerPrefs.SetInt(questName, 2);

        spriteRenderer.enabled = itemCollider.enabled = false;

        if (audioSource != null) audioSource.Play();
    }
 
}

