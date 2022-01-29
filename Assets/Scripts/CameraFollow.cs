using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothTime;
    public float floorBound, ceilingBound;
    public float floorOffset, ceilingOffset;

    private float xVelocity = 0.0f, yVelocity = 0.0f;

    private void FixedUpdate()
    {
        // don't track if the player is dead right now
        if (player == null)
            return;

        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = transform.position;

        // move the camera to the right
        if (playerPosition.x > cameraPosition.x)
        {
            cameraPosition.x = Mathf.SmoothDamp(cameraPosition.x, playerPosition.x, ref xVelocity, smoothTime);
        }

        // adjust the height of the camera
        if (cameraPosition.y - playerPosition.y > floorOffset)
        {
            float yPos = Mathf.SmoothDamp(cameraPosition.y, Mathf.Max(playerPosition.y, floorBound), ref yVelocity, smoothTime);            
            cameraPosition.y = yPos;
        }
        else if (playerPosition.y - cameraPosition.y > ceilingOffset)
        {
            float yPos = Mathf.SmoothDamp(cameraPosition.y, Mathf.Min(playerPosition.y, ceilingBound), ref yVelocity, smoothTime);
            cameraPosition.y = yPos;
        }
        
        transform.position = cameraPosition;
    }

    public void UpdatePlayer(GameObject newPlayer)
    {
        // update the player tracking object
        player = newPlayer;

        // move the camera to player (since we need to go left)
        Vector3 playerPosition = player.transform.position;
        Vector3 cameraPosition = transform.position;

        // update to center on player x
        cameraPosition.x = playerPosition.x;

        // adjust the height within bounds
        cameraPosition.y = Mathf.Max(Mathf.Min(playerPosition.y, ceilingBound), floorBound);

        // update camera position
        transform.position = cameraPosition;
    }
}
