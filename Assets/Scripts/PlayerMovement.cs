using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public Transform KeyFollowPoint;

    public key followingKey;

    [SerializeField] private AudioSource jumpSoundEffect;

    // Update is called once per frame
    void Update()
    {

     
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            jumpSoundEffect.Play();
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }


    private void FixedUpdate()
    {
        //Move our Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Powerup1")
        {
            Destroy(collision.gameObject);
            runSpeed = 80f;
            StartCoroutine(ResetPower());
        }
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(10);
        runSpeed = 56f;

    }
}
