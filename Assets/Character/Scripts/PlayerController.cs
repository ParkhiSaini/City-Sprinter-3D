using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10;
    public float sideSpeed = 10;
    public float jumpForce = 10;
    private bool isJumping = false;

    private float originalSpeed ;
    private bool isFasterSpeed=false;
    private float fasterSpeedTime ;

    private bool canDoubleJump = false;
    private int remainingDoubleJumps = 0;
    private float doubleJumpEndTime;

    private Rigidbody playerRigidbody;
    private Animator playerAnimator;
    
    public ParticleSystem particle;

    public GameManager gameManager;

    private void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponentInChildren<Animator>();
        if (particle != null)
        {
            particle.Stop();
        }


    }

    public void ActivateDoubleJump(float duration)
    {
        canDoubleJump = true;
        remainingDoubleJumps = 2;
        doubleJumpEndTime = Time.time + duration;
    }

    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.left * Time.deltaTime * horizontalInput * sideSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJumping || (canDoubleJump && remainingDoubleJumps > 0 && Time.time <= doubleJumpEndTime))
            {
                Jump();
                if (isJumping && canDoubleJump && remainingDoubleJumps > 0)
                {
                    remainingDoubleJumps--;
                }
            }
        }
    }

    void Jump()
    {
        isJumping = true;
        playerAnimator.SetTrigger("Jump");  // Trigger the jump animation
        playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            playerAnimator.SetTrigger("Stumble"); 
            gameManager.GameOver();
            Debug.Log("GameOver");
        }
    }

    public void ActivateSpeed(float multiplier, float duration)
    {
        if(!isFasterSpeed)
        {
            
            originalSpeed=moveSpeed;
            moveSpeed *=multiplier;
            isFasterSpeed=true;
            fasterSpeedTime=Time.time +duration;
            if (particle != null)
            {
                particle.Play();
            }
            StartCoroutine(DeactivateSpeedPowerUp(duration));

        }
    }

    private IEnumerator DeactivateSpeedPowerUp(float duration)
    {
        yield return new WaitForSeconds(fasterSpeedTime);
        moveSpeed=originalSpeed;
        isFasterSpeed=false;
        particle.Stop();
        
    }

    

  

     
}
