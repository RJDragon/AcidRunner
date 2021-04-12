using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // bool to state if game has ended
    private bool gameHasEnded = false;
    

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            //if statement with bool prevents looping;
            gameHasEnded = true;
            // message game over in console
            Debug.Log("Game Over");
            // using invoke so we have time for death and falling animation
            // resetting values (see below)
            Invoke("resetVal", 2.5f);
            //personal highscore updating
            Invoke("comparingScore",2.5f);
            // actual restart
            Invoke("Restart", 2.5f);
            
        }
    }

    void Restart()
    {
        // restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void resetVal()
    {
        //sets CoinCounter to 0; sets actual health to 3 again and also the livesCounter for the text to 3;
        CoinCounter.scoreCounter = 0;
        GetComponent<Player>().health += GetComponent<Player>().antihealth;
        LivesCounter.livesCounter += GetComponent<Player>().antihealth;
        // stopping death and flying animations
        GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDead", false);
        GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isFalling", false);
        
    }
    
    void comparingScore()
    {
        // when player reached a higher score than before
        if (GetComponent<DistanceFromStart>().distance > HighScore.highScore)
        {
            // set new highscore to score just reached
            HighScore.highScore = GetComponent<DistanceFromStart>().distance;
        }
    }
}