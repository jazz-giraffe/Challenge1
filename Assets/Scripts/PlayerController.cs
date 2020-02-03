using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private int count;
    private int lives;


    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        lives = 3;
        loseText.text = "";
        SetCountText();
        SetLivesNum();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesNum ();
        }
        if (count == 12)
        {
            transform.position = new Vector2(54.1f, 10.6f);
        }
    }

    void SetLivesNum ()
    {
        livesText.text = "Lives remaining: " + lives.ToString();
        if (lives == 0)
        {
            loseText.text = "Game Over";
            Destroy(gameObject);
        }
    }

    void SetCountText ()
    {
        countText.text = "Jewels: " + count.ToString();
        if (count >= 22)
        {
            winText.text = "Congrats, you won! created by Jazlyn Dukes";
        }
    }
}
