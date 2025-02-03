using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    Rigidbody2D rb;
    [SerializeField] float speedFactor;
    [SerializeField] float maxSpeed;
    [SerializeField] float jump;
    [SerializeField] float drag;

    [Header("Colliders")]
    public bool onFloor = false;
    public bool leftWall = false;
    public bool rightWall = false;
    [SerializeField] float spawnPoint;
    [SerializeField] float deathZone;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();

        if (transform.position.y < deathZone)
        {
            Vector3 spawn = transform.position;
            spawn.y = spawnPoint;
            transform.position = spawn;
        }

    }

    void Movement()
    {
        float moveInput = 0;

        if (Input.GetKey(KeyCode.A) && !leftWall)
            moveInput = -1;
        if (Input.GetKey(KeyCode.D) && !rightWall)
            moveInput = 1;

        rb.AddForce(new Vector2(moveInput * speedFactor, 0), ForceMode2D.Force);

        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        if (moveInput == 0 && onFloor)
            rb.velocity = new Vector2(rb.velocity.x * (1 - drag * Time.deltaTime), rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && onFloor)
        {
            Debug.Log("pulou");
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }
}
