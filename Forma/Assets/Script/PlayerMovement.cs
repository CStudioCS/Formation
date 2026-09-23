using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private bool touched_bloc;
    void Start(){
    animator.SetBool("isJumping", false);
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        gameObject.transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && touched_bloc)
        {
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            touched_bloc = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Bloc bloc))
        {
            touched_bloc = true;
        }

        if(collision.gameObject.TryGetComponent(out Ennemi enemy))
        {
            Destroy(collision.gameObject);
        }
    }

}
