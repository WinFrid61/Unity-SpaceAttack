using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidControls : MonoBehaviour
{
    [SerializeField]
    private int speed = 16;
    public AudioClip AsteroidHit;
    void Update()
    {
        transform.Translate(Vector3.left / speed);

        if (transform.position.x < -9.89)
        {
            transform.position = new Vector3(9.89f, Random.Range(-4.1f, 4.1f), transform.position.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(AsteroidHit, transform.position, 1.0f);
        }
        else if (collision.tag == "Player")
        {
            PlayerController PlayerController = collision.GetComponent<PlayerController>();

            if (PlayerController != null)
            {
                PlayerController.LifeSubstraction();
            }
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(AsteroidHit, transform.position, 1.0f);
        }
        else if (collision.tag == "Enemy")
        {
            AudioSource.PlayClipAtPoint(AsteroidHit, transform.position, 1.0f);
        }
    }
}