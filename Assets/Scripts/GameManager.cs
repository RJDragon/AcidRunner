using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameHasEnded = false;
    
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            //if statement with bool prevents looping;
            gameHasEnded = true;
            Debug.Log("Game Over");
            //Invoke gives us a delay of the called methods; here resetting the counters and then restarting the game
            Invoke("resetVal", 1f);
            //personal highscore updating
            Invoke("comparingScore",1f);
            Invoke("Restart", 1f);
            
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
    }
    
    void comparingScore()
    {
        if (GetComponent<DistanceFromStart>().distance > HighScore.highScore)
        {
            HighScore.highScore = GetComponent<DistanceFromStart>().distance;
        }
    }
}