using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearingPlatform : MonoBehaviour
{
    float _timer;
    [SerializeField] float disappearTime;
    [SerializeField] float respawnTime;
    bool _respawning;
    SpriteRenderer _renderer;
    BoxCollider2D _collider2D;

    void Start()
    {
        _collider2D = gameObject.GetComponent<BoxCollider2D>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_respawning && _timer > respawnTime)
        {
            _renderer.enabled = true;
            _collider2D.enabled = true;
        }
        if (!_respawning && _timer > disappearTime)
        {
            _renderer.enabled = false;
            _collider2D.enabled = false;
            _respawning = true;
            _timer = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(_timer < disappearTime) return;
        _timer = 0;
        _respawning = false;
    }
}
