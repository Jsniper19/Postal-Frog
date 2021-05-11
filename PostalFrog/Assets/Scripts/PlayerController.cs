using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float maxGroundDistance = 1.5f;
    public float radius = 0.05f;
    private bool isGrounded;
    public bool allowDoubleJump = false;
    private int amountOfJumps = 0;
    public float forwardsJump = 1.0f;
    [SerializeField] LayerMask layerMask;

    public ChargeUp chargeUp;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        var colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        isGrounded = colliders.Length > 0;
        //isGrounded = Physics.Raycast(transform.position, Vector3.down, maxGroundDistance, layerMask);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }
}
