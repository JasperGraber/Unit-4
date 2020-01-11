using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    
    // Dit maakt een private float aan voor powerUpStrength met als waarde 15.
    private float powerUpStrength = 15.0f;
    
    // Dit maakt een float aan voor speed in Unity met als standaard waarde 5.
    public float speed = 5.0f;

    // Dit maakt een bool aan voor hasPowerup in Unity met als standaard waarde false.
    public bool hasPowerup = false;

    // Dit maakt een gameobject voor powerIndicator.
    public GameObject powerIndicator;
    
    // Dit start alle scripts voor de eerste frame.
    void Start()
    {
        // Dit zorgt ervoor dat de computer weet wat playerRb is.
        playerRb = GetComponent<Rigidbody>();
        
        // Dit zorgt ervoor dat de computer weet wat focalPoint is.
        focalPoint = GameObject.Find("Focal Point");
    }

    // Dit update alle scripts per frame.
    void Update()
    {
        // Dit zorgt er naar dat de input wordt gezocht.
        float forwardInput = Input.GetAxis("Vertical");
        
        // Dit zorgt ervoor dat de spelere kan bewegen.
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        // Dit zorgt ervoor dat als de speler de powerup aanraakt hij word verwijderd en 'opgepakt' is.
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    // Dit zorgt ervoor dat de powerup 7 seconde lang duurt.
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Dit zorgt ervoor dat als de speler de powerup heeft dat de bounce krachtiger wordt.
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            
            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }
}