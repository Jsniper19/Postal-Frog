using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 5.0f;
    public float maxGroundDistance = 1.5f;
    public float radius = 0.05f;
    private bool isGrounded;
    private int amountOfJumps;
    public float forwardsJump = 1.0f;
    [SerializeField] LayerMask layerMask;
    public AudioSource LandSound;

    public ChargeUp chargeUp;
    public Animator animator;
    public GameObject bodyIdle;
    public GameObject bodyLeap;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LandSound = GetComponent<AudioSource>();
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
                GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0.0f, jumpForce * chargeUp.percentage, forwardsJump * chargeUp.percentage), ForceMode.Impulse);
                amountOfJumps = 1;
            }
        }

        if (isGrounded)
        {
            bodyIdle.SetActive(true);
            bodyLeap.SetActive(false);
        }
        else 
        {
            bodyIdle.SetActive(false);
            bodyLeap.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radius);
    }

    private void OnCollisionEnter(Collision collision)
    {
        LandSound.Play();
    }
}
