using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Transform _startingTransform;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] float _distance = 100f;
    [SerializeField] private Text deathCount;
    [SerializeField] private GameObject Panel;
    public DeathManager DM;

    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        DM = GameObject.Find("DeathManager").GetComponent<DeathManager>();
        var ray = new Ray(transform.position, -Vector3.up);
        if (Physics.Raycast(ray, out RaycastHit hit, _distance, _layerMask))
        {
            transform.position = _startingTransform.position;
            _rb.velocity = Vector3.zero;
            transform.rotation = _startingTransform.rotation;
            DM.deaths++;
        }

        if (transform.position.y <= 0)
        {
            transform.position = _startingTransform.position;
            _rb.velocity = Vector3.zero;
            transform.rotation = _startingTransform.rotation;
            DM.deaths++;
        }

        if (DM.deaths >= 1)
        {
            Panel.SetActive(true);
            deathCount.text = "Death Count: " + DM.deaths;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, - Vector3.up * _distance);
    }
}
