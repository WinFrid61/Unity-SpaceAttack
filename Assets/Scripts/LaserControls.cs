using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControls : MonoBehaviour
{
    [SerializeField]
    private int laserspeed = 5;
    void Update()
    {
        transform.Translate(Vector3.up / laserspeed);

        if (transform.position.y >= 5.7f)
        {
            Destroy(this.gameObject);
        }
    }
}
