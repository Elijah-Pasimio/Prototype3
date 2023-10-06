using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float leftBound = -15;

    public float moveSpeed;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if(transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
