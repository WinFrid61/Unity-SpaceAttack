using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyControls : MonoBehaviour
{
    [SerializeField]
    private int speed = 10;
    private float timer = 10.0f;

    [SerializeField]
    private GameObject enemyExplosionPrefab;
    private GameObject a;
    void Update()
    {
        transform.Translate(Vector3.down / speed);

        if (transform.position.y < -6.7)
        {
            transform.position = new Vector3(Random.Range(-7.5f, 7.5f), 6.7f, transform.position.z);
        }
    }
        private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.tag == "Laser")
            {
                Destroy(collision.gameObject);
                a = Instantiate(enemyExplosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Destroy(this.gameObject);
            Destroy(a, 2.5f);
            }
        else if (collision.tag == "Player")
        {
            PlayerController PlayerController = collision.GetComponent<PlayerController>();

            if (PlayerController != null)
            {
                PlayerController.LifeSubstraction();
            }
                a = Instantiate(enemyExplosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                Destroy(this.gameObject);
                Destroy(a, 2.5f);
        }
        else if (collision.tag == "Asteroid")
        {
            Destroy(collision.gameObject);
            a = Instantiate(enemyExplosionPrefab, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Destroy(this.gameObject);
            Destroy(a, 2.5f);
        }
    }
}
