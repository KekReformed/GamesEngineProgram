using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class Player : Character 
{
    private LayerMask _playerLayer;
    [FormerlySerializedAs("_jumpHeight")] public float jumpHeight;
    [SerializeField][Range(0.01f,0.5f)] private float groundCheckDist;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashCooldown;
    [SerializeField] float dashAttackLingerTime;
    float _dashClock;
    float _origSpeedCap;
    Vector3 _origPoint;
    public bool attacking;
    
    public override void Start()
    {
        _playerLayer = LayerMask.GetMask("Player");

        _origSpeedCap = speedCap;
        _origPoint = transform.position;
        
        int myLayer = (1 << rb.gameObject.layer) & _playerLayer;
        
        if(myLayer == 0) Debug.LogError("You need to add your player character to a layer called Player!");
    }
    
    public override void Jump(){
        rb.velocity += new Vector2(0, jumpHeight);
    }

    public override void Attack()
    {
        if (dashCooldown > _dashClock) return;
        rb.velocity = new Vector2(rb.velocity.x + dashSpeed * Mathf.Sign(Input.GetAxisRaw("Horizontal")), rb.velocity.y);
        _dashClock = 0;
        speedCap = dashSpeed;
        attacking = true;
    }

    public void Respawn()
    {
        transform.position = _origPoint;
    }
    
    public bool GroundCheck()
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.position, transform.localScale*0.5f, transform.rotation.z, Vector2.down,
            groundCheckDist, ~_playerLayer);
        return hit;
    }
    
    public override void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            rb.velocity += new Vector2(acceleration * horizontalInput * Time.deltaTime, 0);
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-speedCap,speedCap), rb.velocity.y);
        }
        else
        {
            Vector2 moveChange = rb.velocity + new Vector2(-deceleration * Mathf.Sign(rb.velocity.x) * Time.deltaTime, 0);
            if (Mathf.Sign(rb.velocity.x) != Mathf.Sign(moveChange.x)) moveChange.x = 0;
            rb.velocity = moveChange;
        };
    }
    
    public override void Update()
    {
        _dashClock += Time.deltaTime;
        if (_dashClock > dashAttackLingerTime && attacking)
        {
            attacking = false;
            speedCap = _origSpeedCap;
        }
        
        if(transform.position.y < -100) Respawn();
    }
}