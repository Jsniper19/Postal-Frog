using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5.0f;
    public float maxGroundDistance = 1.5f;
    [SerializeField] private float radius = 0.05f;
    private bool isGrounded;
    private int amountOfJumps;
    [SerializeField] private float forwardsJump = 1.0f;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private AudioSource LandSound;

    [SerializeField] private ChargeUp chargeUp;
    [SerializeField] private GameObject bodyIdle;
    [SerializeField] private GameObject bodyLeap;
    public bool PLAY;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        LandSound = GetComponent<AudioSource>();
        PLAY = true;
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
        if (PLAY)
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
