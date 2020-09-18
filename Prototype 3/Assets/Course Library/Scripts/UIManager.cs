/* Broc Edson
 * Prototype 3
 * Makes score and UI work
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public int score = 0;
    public Text scoretext;

    public PlayerController playerController;

    public bool won = false;

    // Start is called before the first frame update
    void Start()
    {
        if(scoretext == null)
        {
            scoretext = FindObjectOfType<Text>();
        }
        if (playerController == null)
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        scoretext.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerController.gameOver)
        {
            scoretext.text = "Score: " + score;
        }
        if(playerController.gameOver && !won)
        {
            scoretext.text = "You Lose!";
        }
        if(score >= 10)
        {
            playerController.gameOver = true;
            won = true;

            //playerController.StopRunning();
            scoretext.text = "You Win!";
        }
        if(playerController.gameOver)
        {
            scoretext.text += "\nPress R To Try Again!";
        }

        if(playerController.gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
