using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUp : MonoBehaviour
{
    [SerializeField] float _maxTime = 3f;

    float _elapsedTime = 0f;
    public float _percentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        _elapsedTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _percentage = _elapsedTime / _maxTime;
            _elapsedTime = 0;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (_elapsedTime >= _maxTime)
            {
                _elapsedTime = _maxTime;
            }
            else
            {
                _elapsedTime += Time.deltaTime;
            }
        }

        _percentage = _elapsedTime / _maxTime;
    }
}
