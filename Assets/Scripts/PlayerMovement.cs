using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gameManager;
    public GameObject crashParticlesPrefab;
    public float velocity = 100f;
    public float jumpHeight;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && transform.position.y < 4.59)
        {
            rb.velocity = Vector2.up * jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ObjectsToAvoid")
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            Instantiate(crashParticlesPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            gameManager.GameOver();
        }
    }
}
