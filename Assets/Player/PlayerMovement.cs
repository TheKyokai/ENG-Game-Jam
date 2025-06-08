using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerBody;
    private float horizontalMovement;
    private float moveSpeed = 5f;

    private float verticalMovement;
    private float jumpStrength = 15f;

    public Transform groundCheckPosition;
    public Vector2 groundCheckSize = new Vector2 (0.001f, 0.01f);
    public LayerMask groundLayer;


    private TimeController timeController;

    public Animator animator;
    private bool isFacingRight = true;

    private AudioManager audioManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerBody.linearVelocity = new Vector2 ( horizontalMovement * moveSpeed, playerBody.linearVelocityY);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
        if (context.performed)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if ((!isFacingRight && horizontalMovement > 0) || (isFacingRight && horizontalMovement < 0))
        {
            Flip();
        }
        
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            if (context.performed)
            {
                playerBody.linearVelocity = new Vector2(playerBody.linearVelocityX, jumpStrength);
                audioManager.PlaySound("Jump");
                animator.SetTrigger("JumpTrigger");
            }
        }
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapBox(groundCheckPosition.position, groundCheckSize, 0, groundLayer);
        
    }

    public void MoveIntoPast(InputAction.CallbackContext context)
    {
        
        audioManager.PlaySound("ClockSwish");
        timeController.MoveIntoPast();
        if (!animator.GetBool("IsRunning")){
            animator.SetTrigger("TimeManipulation");
        }
    }

    public void MoveIntoFuture(InputAction.CallbackContext context)
    {
        
        audioManager.PlaySound("ClockSwish");
        timeController.MoveIntoFuture();
        if (!animator.GetBool("IsRunning"))
        {
            animator.SetTrigger("TimeManipulation");
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

}
