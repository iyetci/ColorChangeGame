using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float jumpforce = 5f;
    public Rigidbody2D rb;

    string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorMagenta;

    public SpriteRenderer sr;

    public GameObject menuEkrani;
    public GameObject settings;

    void Start()
    {
        SetRandomColor();
    }


    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpforce;
        }

        if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Changer")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Score")
        {
            return;
        }
        else if (collision.tag == "Key")
        {
            return;
        }
        else if (collision.tag != currentColor)
        {
            Debug.Log("Game Over");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
     }

 

    void SetRandomColor()
    {
        int currentColorIndex = Random.Range(0, 4);

        if (currentColorIndex == 0)
        {
            currentColor = "Yellow";
            sr.color = colorYellow;
        }
        else if (currentColorIndex == 1)
        {
            currentColor = "Pink";
            sr.color = colorPink;
        }
        else if (currentColorIndex == 2)
        {
            currentColor = "Cyan";
            sr.color = colorCyan;
        }
        else if (currentColorIndex == 3)
        {
            currentColor = "Magenta";
            sr.color = colorMagenta;
        }


    }

   

    public void oyunaBasla()
    {
        menuEkrani.SetActive(false);
    }

    public void setTings()
    {
        settings.SetActive(false);
    }

        
}


