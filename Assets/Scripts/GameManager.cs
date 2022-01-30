using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { getReady, playing, oops, gameOver, roundWin };

public class GameManager : MonoBehaviour
{
    /* Used by other classes, GameManager shared info */
    // Singleton defintion
    public static GameManager S;
    // Game State
    public GameState gameState = GameState.playing;

    // UI Elements
    //public TextMeshProUGUI messageOverlay, livesOverlay, scoreOverlay, countdownOverlay;

    /* Used internally for tracking gameplay info */

    /* Before anything happens, initialization of object */

    public int coinCount = 8;

    private void Awake()
    {
        // check if singleton exists already
        if (S == null)
            S = this;
        else
            Destroy(gameObject);

        // initialize game variables
        // InitializeNewGame();
    }

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    /* Used to start the game/round */

    public void InitializeNewGame()
    {
        // reset game variables
    }

    public void StartRound()
    {
        // put the game into the getReady state
        gameState = GameState.getReady;

        // get ready coroutine
        StartCoroutine(GetReadyState());
    }

    /* GameState: initialize gameplay */

    public IEnumerator GetReadyState()
    {
        // start displaying game UI

        // start playing background sounds
        // SoundManager.S.StartAmbientSounds();

        // pause for 2 seconds
        yield return new WaitForSeconds(2.0f);

        // turn off the message

        // start playing the game
        // PlayRound();
    }

    private void PlayRound()
    {
        // set gameState to playing
        gameState = GameState.playing;
    }

    /* GameState: while playing */

    public void PlayerCollectedCoin()
    {
        coinCount--;

        // Game is over when all coins are gone.
        if (coinCount < 1)
        {
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Title");
    }

    /* GameState: after playing is over */

    /*
    public void PlayerLost()
    {
        // remove a life
        livesLeft--;

        // update the lives overlay
        livesOverlay.text = livesLeft.ToString();

        // check if player is out of lives
        if (livesLeft > 0)
        {
            // Make the player death sound
            SoundManager.S.PlayDeathSound();

            // go into oops state
            StartCoroutine(OopsState());
        }
        else
        {
            // go into game over (lose) state
            GameOverState(false);
        }
    }

    public IEnumerator OopsState()
    {
        // go into oops state
        gameState = GameState.oops;

        // stop the game timer
        if (levelTimer != null)
        {
            StopCoroutine(levelTimer);
            levelTimer = null;
        }

        // turn on the oops message
        messageOverlay.enabled = true;
        messageOverlay.text = "Lives Left: " + livesLeft;

        // brief wait for the message & player destruction
        yield return new WaitForSeconds(4.0f);

        // turn the overlay message off
        messageOverlay.enabled = false;

        // reset the round from checkpoint
        LevelManager.S.RestartLevelCheckpoint();
    }

    public void GameOverState(bool victory)
    {
        // go into gameover state
        gameState = GameState.gameOver;

        // stop the game timer
        if (levelTimer != null)
        {
            StopCoroutine(levelTimer);
            levelTimer = null;
        }

        // diverges here based on whether the player won
        if (victory)
            StartCoroutine(LevelComplete());
        else
            StartCoroutine(GameOverLose());
    }

    private IEnumerator LevelComplete()
    {
        // transition state while we wait after winning
        gameState = GameState.roundWin;

        // play victory fanfare
        SoundManager.S.PlayFanfareClip();

        // turn on the level complete message
        messageOverlay.enabled = true;
        messageOverlay.text = "Congratulations!\nYou Win!";

        // pause here for a moment
        yield return new WaitForSeconds(4.0f);

        if (LevelManager.S.finalScene)
        {
            // send back to main menu
            // messageOverlay.text = "Press the Back button\nto return to main menu";

            // turn on the back button
            // backButton.SetActive(true);
        }
        else
        {
            // go to the next round
            LevelManager.S.RoundWin();
        }
    }

    private IEnumerator GameOverLose()
    {
        // play the game over sound
        SoundManager.S.PlayGameoverClip();

        // turn on the game over message
        messageOverlay.enabled = true;

        messageOverlay.text = "You Lose...";
        // messageOverlay.text += "\nPress the Back button\nto return to main menu";
        messageOverlay.text += "\nFinal Score: " + score.ToString("0000");

        // pause here for a moment
        yield return new WaitForSeconds(4.0f);

        // turn on the back button
        // backButton.SetActive(true);

        // reset the level
        // LevelManager.S.RestartLevel();
    }
    */

}
