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
        if (Input.GetKeyDown("space"))
        {

            if (isGrounded)
            {
                GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, jumpForce, forwardsJump), ForceMode.Impulse);
                amountOfJumps = 1;
            }
            else if (amountOfJumps < 2 && allowDoubleJump)
            {
                GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, jumpForce, forwardsJump), ForceMode.Impulse);
                amountOfJumps = 2;
            }

        }
    }
}
