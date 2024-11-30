using UnityEngine;

[System.Serializable]
public class Player : Character 
{
    private LayerMask _playerLayer;
    [SerializeField] private float _jumpHeight;
    [SerializeField][Range(0.01f,0.5f)] private float groundCheckDist;
    
    public override void Start()
    {
        _playerLayer = LayerMask.GetMask("Player");
        
        int myLayer = (1 << rb.gameObject.layer) & _playerLayer;
        
        if(myLayer == 0) Debug.LogError("You need to add your player character to a layer called Player!");
    }
    
    public void Jump(){
        rb.velocity += new Vector2(0, _jumpHeight);
    }
    
    public bool GroundCheck()
    {
        RaycastHit2D hit;
        hit = Physics2D.BoxCast(transform.position, transform.localScale, transform.rotation.z, Vector2.down,
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
        if (Input.GetKeyDown(KeyCode.Space)) Jump();
        Move();
    }
}