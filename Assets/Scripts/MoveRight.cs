using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed;
    private PlayerController playerControllerScript;
    private float rightBound = 20;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the right
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        // destroy off screen
        if (transform.position.x < rightBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
