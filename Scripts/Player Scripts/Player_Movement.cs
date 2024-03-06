using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    //Horizontal Info
    public Transform patrolCheck;
    private float speed = 2f;
    public float patrolRayLength;
    public static bool movingRight;
    private int direction;

    //Vertical Info
    private Rigidbody2D rb2d;
    public Transform isGroundedCheck;
    public LayerMask groundLayer;
    private TouchControls touchControls;

    //Jump Variables Controls
    private bool isGrounded;
    public float isGroundedRadius;

    public float jumpStrength;
    private bool isJumping;
    public float jumpTime;
    private float jumpTimeCounter; //0.15 is good
    private bool inputDetected;

    //For Collison Scripts
    public static bool allowMovement = false;

    //For Aninmation
    public Animator seanMovement;

    //For Audio
    public AudioClip[] jumpAudio;
    public AudioSource seanSource;
    private bool playJumpSound = true;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        touchControls = new TouchControls();

        //Direction Controller
        direction = Random.Range(0, 2);
        if (direction == 1)
        {
            direction = -180;
        }

        transform.eulerAngles = new Vector3(0, direction, 0);

        if (direction == 0)
        {
            movingRight = true;
        }
        else
        {
            movingRight = false;
        }

    }

    private void Start()
    {
        touchControls.Touch.TouchPress.started += ctx => PressDown(ctx);
        touchControls.Touch.TouchPress.canceled += ctx => PressRelease(ctx);
    }

    private void OnEnable()
    {
        touchControls.Enable();
    }

    /* private void OnDisable()
    {
        touchControls.Disable();
    } */

    private void PressDown(InputAction.CallbackContext context)
    {
        inputDetected = context.started;
    }

    private void PressRelease(InputAction.CallbackContext context)
    {
        inputDetected = context.started;
    }


    void FixedUpdate()
    {
        //Is Grounded
        isGrounded = Physics2D.OverlapCircle(isGroundedCheck.position, isGroundedRadius, groundLayer);
        if (isGrounded == true) { isGrounded = true; seanMovement.SetBool("Jumping", false); } else { isGrounded = false;}


        //Vertical Movement
        if (allowMovement)
        {
            seanMovement.SetBool("Moving", true);

            //Jump Activation
            if (inputDetected == true && isGrounded == true)
            {
                isJumping = true;
                jumpTimeCounter = jumpTime;
                rb2d.velocity = Vector2.up * jumpStrength;
                seanMovement.SetBool("Jumping", true);
                if (AudioManager.soundEnabled && playJumpSound) 
                {
                    seanSource.PlayOneShot(jumpAudio[Random.Range(0, 4)]);
                    playJumpSound = false;
                }
            }

            if (inputDetected == true && isJumping == true)
            {
                if (jumpTimeCounter > 0)
                {
                    rb2d.velocity = Vector2.up * jumpStrength;
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                    inputDetected = false;
                    playJumpSound = true;
                }

            }
            else
            {
                isJumping = false;
                inputDetected = false;
                playJumpSound = true;
            }

            //Horizontal Movement, and Air Velocity Increase
            if (!isGrounded) { if (speed < 4.0f) { speed += 0.10f; } else { speed = 4.0f; } } else { if (speed > 2.0f) { speed -= 0.10f; } else { speed = 2.0f; } }
            transform.Translate(Vector2.right * speed * Time.deltaTime);

            RaycastHit2D patrolRay = Physics2D.Raycast(patrolCheck.position, Vector2.down, patrolRayLength);
            if (!patrolRay.collider)
            {
                //if(patrolRay.collider) IS A BOX COLLIDER
                
                    if (movingRight == true)
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                        movingRight = false;
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                        movingRight = true;
                    }
                
            }
        }
        else 
        {
            seanMovement.SetBool("Moving", false);
        }
    }
}