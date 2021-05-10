using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float maxGroundDistance = 1.5f;
    private bool isGrounded;
    public bool allowDoubleJump = false;
    private int amountOfJumps = 0;
    public float forwardsJump = 1.0f;

    public ChargeUp chargeUp;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance);
        if (isGrounded == true)
        {
            amountOfJumps = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            
            if (isGrounded)
            {
                GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, jumpForce * chargeUp._percentage, forwardsJump * chargeUp._percentage), ForceMode.Impulse);
                amountOfJumps = 1;
            }
            else if (amountOfJumps < 2 && allowDoubleJump)
            {
                GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, jumpForce * chargeUp._percentage, forwardsJump * chargeUp._percentage), ForceMode.Impulse);
                amountOfJumps = 2;
            }
        }

        if (isGrounded)
        {
            animator.SetBool("Leap", false);
        }
        else 
        {
            animator.SetBool("Leap", true);
        }
    }
}
