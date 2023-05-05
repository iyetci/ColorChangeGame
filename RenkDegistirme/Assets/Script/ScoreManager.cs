using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    private int score = 0;
    private List<GameObject> scoredObjects = new List<GameObject>();

    private void Start()
    {
        scoreText = GameObject.Find("scoreText").GetComponent<TMP_Text>();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score") && !scoredObjects.Contains(collision.gameObject))
        {
            scoredObjects.Add(collision.gameObject);
            AddScore(5);
        }
    }
}