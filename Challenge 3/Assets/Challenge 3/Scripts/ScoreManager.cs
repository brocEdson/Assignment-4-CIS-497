/* Broc Edson
 * Challenge 3
 * Manages the score and text
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static bool ended = false;
    public static bool won = false;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
        score = 0;
        ended = false;
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ended)
        {
            scoreText.text = "Score: " + score;
            // I made the score threshold 10 because making it 30 was painfully long to do
            if(score >= 10)
            {
                ended = true;
                won = true;
            }
        }
        else if(won)
        {
            scoreText.text = "You Won!\nPress R To Restart!";
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            } 
        }
        else
        {
            scoreText.text = "Game Over!\nPress R To Restart!";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
