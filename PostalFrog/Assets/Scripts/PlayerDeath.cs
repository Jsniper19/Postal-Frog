using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerDeath : MonoBehaviour
{
    [SerializeField] Transform _startingTransform;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] float _distance = 100f;
    public Text deathCount;
    public int deaths;

    Camera _mainCam;
    Rigidbody _rb;

    private void Awake()
    {
        _mainCam = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var ray = new Ray(transform.position, -Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _distance, _layerMask))
        {
            transform.position = _startingTransform.position;
            _rb.velocity = Vector3.zero;
            transform.rotation = _startingTransform.rotation;
            deaths = deaths + 1;
            deathCount.text = "Death Count: " + deaths;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, - Vector3.up * _distance);
    }
}
