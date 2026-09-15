using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // scroll the object
        rb2d.linearVelocity = new Vector2(GameControl.instance.scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // stop scrolling when game finishes
        if (GameControl.instance.gameOver == true)
        {
            rb2d.linearVelocity = Vector2.zero;
        }
    }
}
