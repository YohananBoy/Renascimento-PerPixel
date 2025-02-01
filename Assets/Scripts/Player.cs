using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    Vector3 speed = new Vector3(0, 0, 0);
    Vector3 acceleration = new Vector3(0, 0, 0);
    [SerializeField] float speedfactor;
    [SerializeField] float jump;
    [SerializeField] float drag;

    [Header("Colliders")]
    bool onFloor;
    void Start()
    {

    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (drag > 1) drag = 1;
        if (drag < 0) drag = 0;

        acceleration = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.A))
        {
            acceleration += new Vector3(-speedfactor, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            acceleration += new Vector3(speedfactor, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.W) && onFloor)
        {
            acceleration += new Vector3(0, jump, 0);
            onFloor = false;
        }

        speed += acceleration;
        speed *= drag;

        transform.position += speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            onFloor = true;
        }
    }
}
