using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [Range(1, 10)]
    public float jumpForce;
    public int jumpAmount;
    private int jumpAmountConstant;
    private int jumpAmountReal;
    private Rigidbody2D rb;
    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAmountConstant = jumpAmount;
        jumpAmountReal = jumpAmount - 1;

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpAmountReal--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = Vector2.up * jumpForce;

        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && jumpAmountReal > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (jumpAmount == 0 || isGrounded)
        {
            jumpAmountReal = jumpAmountConstant;
        }

    }
}
