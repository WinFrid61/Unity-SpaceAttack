using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject laserPrefab;
    [SerializeField]
    private float fireRate = 0.9f;
    [SerializeField]
    private float nextFire;
    [SerializeField]
    private int speed = 8;
    [SerializeField]
    private int PlayerLives = 3;
    [SerializeField]
    private GameObject playerexplosionPrefab;
    [SerializeField]
    private GameObject Heart1, Heart2, Heart3;
    void Start()
    {
        transform.position = new Vector3(0, 0, -0.1f);
    }
    void Update()
    {
        SpaceMovement();

        if (Input.GetMouseButton(0))
        {
            if(Time.time > nextFire)
            {
                Instantiate(laserPrefab, transform.position + new Vector3(0.004f, 1.228f, 0), Quaternion.identity);
                nextFire = Time.time + fireRate;
            }
        }
    }
    public void LifeSubstraction()
    {
        PlayerLives--;
        switch (PlayerLives)
        {
            case 3:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(true);
                break;
            case 2:
                Heart1.SetActive(true);
                Heart2.SetActive(true);
                Heart3.SetActive(false);
                break;
            case 1:
                Heart1.SetActive(true);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
            case 0:
                Heart1.SetActive(false);
                Heart2.SetActive(false);
                Heart3.SetActive(false);
                break;
        }
            if (PlayerLives < 1)
        {
            Instantiate(playerexplosionPrefab, new Vector3(transform.position.x, transform.position.y, -0.00001f), Quaternion.identity);
            gameObject.SetActive(false);
            Invoke("Delay", 2.5f);
        }
    }
    private void Delay()
    {
        SceneManager.LoadScene("GameOver");
    }
    private void SpaceMovement()
    {
        float verticinput = Input.GetAxis("Vertical");
        float horizoninput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizoninput);
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticinput);
        if (transform.position.y > 3.9f)
        {
            transform.position = new Vector3(transform.position.x, 3.9f, transform.position.z);
        }
        else if (transform.position.y < -3.9f)
        {
            transform.position = new Vector3(transform.position.x, -3.9f, transform.position.z);
        }
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }
    }
}
