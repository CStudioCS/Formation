using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 7f;

    [SerializeField] GameObject respawnPoint;
    [SerializeField] Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
    }

    void Update()
    {
        // Déplacement gauche / droite
        float horizontal = Input.GetAxisRaw("Horizontal");

        //rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        // Saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            isGrounded = true;
        }
        if (collision.gameObject.TryGetComponent(out Monster monster))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint.transform.position;
    }
}