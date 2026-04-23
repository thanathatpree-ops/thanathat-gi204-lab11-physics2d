using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float jumpForce = 450;
    private Rigidbody2D Rigidbody;
    private float moveInputValue;
    private bool isGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current != null)
        {
            moveInputValue = (Keyboard.current.dKey.isPressed ? 1 : 0)
               - (Keyboard.current.aKey.isPressed ? 1 : 0);
        }
        Rigidbody.linearVelocity = new Vector2(moveInputValue * speed, Rigidbody.linearVelocity.y);
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            {
                Rigidbody.AddForce(new Vector2(Rigidbody.linearVelocity.x, jumpForce));
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

