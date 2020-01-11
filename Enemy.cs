using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    
    // Dit maakt een float aan voor speed in Unity met als standaard waarde 3.
    public float speed = 3.0f;
    
    // Dit start alle scripts voor de eerste frame.
    void Start()
    {
        // Dit zorgt ervoor dat de computer weet wat enemyRb is.
        enemyRb = GetComponent<Rigidbody>();

        // Dit zorgt ervoor dat de computer weet wat player is.
        player = GameObject.Find("Player");
    }

    // Dit update alle scripts per frame.
    void Update()
    {
        // Dit zorgt ervoor dat de enemy de speler kan volgen. 
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection* speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
