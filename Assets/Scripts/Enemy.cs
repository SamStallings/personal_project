using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.0f;
    public float enemySpeed = 5.0f;
    private Rigidbody enemyRb;
    private GameObject playerGate;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGate = GameObject.FindWithTag("PlayerGate");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
