using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
	private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool doubleJumped;
	
	private Animator anim;
	
	public Transform firePoint;
	public GameObject ninjaStar;
	
	public float shotDelay;
	private float shotDelayCounter;
	
	public float knockback;
	public float knockbackLength;
	public float knockbackCount;
	public bool knockFromRight;
	
	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		
		gravityStore = GetComponent<Rigidbody2D>().gravityScale;
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update() {

        if (grounded)
            doubleJumped = false;

		anim.SetBool("Grounded", grounded);
		
        if (Input.GetButtonDown("Jump") && grounded)
        {

            // GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {

            //GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Jump();
            doubleJumped = true;

        }

		moveVelocity = moveSpeed * Input.GetAxisRaw("Horizontal");
		
		if(knockbackCount <= 0 ){
			GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
		} else{
			if(knockFromRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2(-knockback, knockback);
			if(!knockFromRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2(knockback, knockback);
			knockbackCount -= Time.deltaTime;
		}
		anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		
		if(GetComponent<Rigidbody2D>().velocity.x > 0)
			transform.localScale = new Vector3(1f, 1f, 1f);
		else if(GetComponent<Rigidbody2D>().velocity.x < 0)
			transform.localScale = new Vector3(-1f, 1f, 1f);
		
		if(Input.GetButtonDown("Fire1"))
		{
			Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			shotDelayCounter = shotDelay;
		}

		if(Input.GetButton("Fire1"))
		{
			shotDelayCounter -= Time.deltaTime;
			
			if(shotDelayCounter <= 0)
			{
				shotDelayCounter = shotDelay;
				Instantiate(ninjaStar, firePoint.position, firePoint.rotation);
			}
		}
		
		if(anim.GetBool("Sword"))
			anim.SetBool("Sword", false);
		
		if(Input.GetButtonDown("Fire2")){
			anim.SetBool("Sword", true);	
		}
		
		if(onLadder){
			GetComponent<Rigidbody2D>().gravityScale = 0f;
			
			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
			
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, climbVelocity);
		}
		if(!onLadder){
			GetComponent<Rigidbody2D>().gravityScale = gravityStore;
		}
}
    public void Jump ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }
}
