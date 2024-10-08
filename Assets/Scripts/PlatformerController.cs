using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlatformerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float acceleration;
    [SerializeField] private float deceleration;
    [SerializeField] private float speedCap;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            _rb.velocity += new Vector2(acceleration * Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0);
            _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x,-speedCap,speedCap), _rb.velocity.y);
        }
        else
        {
            Vector2 moveChange = _rb.velocity + new Vector2(-deceleration * Mathf.Sign(_rb.velocity.x) * Time.deltaTime, 0);
            if (Mathf.Sign(_rb.velocity.x) != Mathf.Sign(moveChange.x)) moveChange.x = 0;
            _rb.velocity = moveChange;
        };
    }
}