using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int playerId = 0;
    public float upForce = 200.0f;
    private bool isDead = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (playerId == 0 && Input.GetMouseButtonDown(0))
            {
                Flap();
            }
            else if (playerId == 1 && Input.GetButtonDown("Jump"))
            {
                Flap();
            }
        }
    }

    void Flap()
    {
        rb2d.linearVelocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, upForce));
        anim.SetTrigger("Flap");
    }

    void OnCollisionEnter2D()
    {
        rb2d.linearVelocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied(playerId);
    }


}
