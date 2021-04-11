using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    public bool stopMoving;

    /*private void Start()
    {
        stopMoving = false;
    }*/

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            //if statement with bool prevents looping;
            gameHasEnded = true;
            Debug.Log("Game Over");
            //StopMoving();
            //Invoke gives us a delay of the called methods; here resetting the counters and then restarting the game
            Invoke("resetVal", 2.5f);
            //personal highscore updating
            Invoke("comparingScore",2.5f);
            Invoke("Restart", 2.5f);
            
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void resetVal()
    {
        //sets CoinCounter to 0; sets actual health to 3 again and also the livesCounter for the text to 3;
        CoinCounter.scoreCounter = 0;
        GetComponent<Player>().health += GetComponent<Player>().antihealth;
        LivesCounter.livesCounter += GetComponent<Player>().antihealth;
        GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isDead", false);
        GameObject.Find("kaya").GetComponent<Animations>().animator.SetBool("isFalling", false);
        //SetFalse();
    }
    
    void comparingScore()
    {
        if (GetComponent<DistanceFromStart>().distance > HighScore.highScore)
        {
            HighScore.highScore = GetComponent<DistanceFromStart>().distance;
        }
    }

    /*void StopMoving()
    {
        stopMoving = true;
        GameObject.Find("Player").GetComponent<Player>().baseSpeed = 0f;
    }

    void SetFalse()
    {
        stopMoving = false;
    }*/
}