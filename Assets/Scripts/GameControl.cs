using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    

    // Multiplayer Extension
    private bool isBirdDead1 = false;
    private bool isBirdDead2 = false;
    private int score1 = 0;
    private int score2 = 0;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // enforce singleton pattern
        // destroy other instances
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy (gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // reload scene if game is over and player flaps 
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdScored(int playerId)
    {
        // don't count scores when game is over
        if (gameOver){
            return;
        }

        

        // update per-player score text
        if (playerId == 0)
        {
            score1++;
            scoreText1.text = "Score: " + score1.ToString();
        }
        else if (playerId == 1)
        {
            score2++;
            scoreText2.text = "Score: " + score2.ToString();
        }
        
    }

    public void BirdDied(int playerId)
    {
        if (playerId == 0)
        {
            isBirdDead1 = true;
        }
        else
        {
            isBirdDead2 = true;
        }

        if (isBirdDead1 && isBirdDead2)
        {
            gameOver = true;
            gameOverText.SetActive(true);
        }
        
    }

    

}
