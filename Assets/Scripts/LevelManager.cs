using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // singleton declaration
    public static LevelManager S;

    [Header("Level Info")]
    // string to display at the level start
    public string levelName;

    // checkpoint location in this level
    public Vector3 checkpoint = Vector3.zero;
    // has the player reached the checkpoint yet?
    private bool checkpointActive = false;

    [Header("Level Objects")]
    // keeps track of the player
    public GameObject playerObject;
    // for respawning the player
    public GameObject playerPrefab;

    // to update camera when player changes
    // public CameraFollow gameCamera;

    // to reset between lives
    public GameObject platformPrefab;
    public GameObject platformObject;
    
    [Header("Scene Info")]
    // name of the scene to go to after this
    public string nextScene;
    // is this the end of the game
    public bool finalScene;

    private void Awake()
    {
        // singleton assignment
        S = this;
    }

    /* LevelManager automatically starts the game */
    private void Start()
    {
        // Start the round
        if (GameManager.S != null)
        {
            /* The CharacterController2D messes up the jumping animation if I use the player gameobject
             * in my Unity Editor hierarchy, but creating it during the game seems to fix the issue? */
            // respawn player
            // playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

            // update the camera follow player
            // gameCamera.UpdatePlayer(playerObject);

            // tell the GameManager to start the game
            // GameManager.S.InitializeNewGame();
            // GameManager.S.StartRound();
        }
    }

    /* If player achieves victory during playing state */
    public void RoundWin()
    {
        SceneManager.LoadScene(nextScene);
    }

    /* If player fails during playing state */
    public void RestartLevel()
    {
        // reload this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // re-initialize the gamemanger
        if (GameManager.S != null)
            GameManager.S.InitializeNewGame();
    }

    /* If player fails and goes back to checkpoint */
    public void RestartLevelCheckpoint()
    {
        // respawn player
        playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);

        // move player to checkpoint
        if (checkpointActive)
            playerObject.transform.position = checkpoint;

        // update the camera follow player
        // gameCamera.UpdatePlayer(playerObject);

        // respawn trigger platform
        Destroy(platformObject);
        platformObject = Instantiate(platformPrefab);

        // start new round
        GameManager.S.StartRound();
    }

    /* After the game is over, or if player backed out of game */
    public void ReturnToMainMenu()
    {
        Destroy(GameManager.S.gameObject);
        SceneManager.LoadScene("TitleMenu");
    }

    /* Allows other scripts to set the checkpoint bool */
    public void SetCheckpoint(bool active)
    {
        checkpointActive = active;
    }
}
