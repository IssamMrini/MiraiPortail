using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perso : MonoBehaviour
{
   
    [SerializeField]
    public float moveSpeed = 5f;
    public float jumpForce;

    public Rigidbody2D rb;

    public Animator animator;

    public CircleCollider2D persoCollider;
    public BoxCollider2D bCollider;
    public SpriteRenderer spriteRenderer;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    private float moveInput;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    [HideInInspector]
    public bool isClimbing;
    

    private Transform playerSpawn;

    public static Perso instance;

    private void Awake(){
        if(instance != null){
            Debug.LogWarning("il y a plus d'une instance de Perso dans la scene");
            return;
        }

        instance = this;
        playerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform; 
    }

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();  

    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround );

        if (!isClimbing){
            if(isGrounded == true && Input.GetKeyDown(KeyCode.Space)){
                        isJumping = true;
                        jumpTimeCounter = jumpTime;
                        rb.velocity = Vector2.up * jumpForce;
                    }

                    if (Input.GetKey(KeyCode.Space) && isJumping == true){

                        

                        if(jumpTimeCounter > 0 ){
                            //animator.SetBool("Jump", true);
                            rb.velocity = Vector2.up * jumpForce;
                            jumpTimeCounter -= Time.deltaTime;
                        }
                        else{
                            isJumping = false;

                        }
                        
                    }

                    if(Input.GetKeyUp(KeyCode.Space)){
                        isJumping = false;
                        //animator.SetBool("Jump", false);
                    }
        }


        
            float characterVelocity = Mathf.Abs(rb.velocity.x);
            animator.SetFloat("Speed" , characterVelocity);
            animator.SetBool("Climb", isClimbing);
            animator.SetBool("Ground", isGrounded);
            animator.SetBool("Jump", isJumping);
        

    }

    void FixedUpdate(){

        if (!isClimbing){
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2 (moveInput * moveSpeed, rb.velocity.y);

        }
        else{
            moveInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector2 (rb.velocity.x, moveInput * moveSpeed);
        }

        
        
        Flip(rb.velocity.x);


    }

    public void Die(){
        //animator.SetBool("Dead", true);
        /*Perso.instance.enabled = false ;
        Perso.instance.rb.bodyType = RigidbodyType2D.Kinematic;
        Perso.instance.rb.velocity = Vector3.zero;
        Perso.instance.persoCollider.enabled = false;
        Perso.instance.bCollider.enabled = false;
        */
        Perso.instance.transform.position = playerSpawn.position;

    }

    public void Flip(float _velocity){

        if(_velocity > 0.1f){

            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f){
            spriteRenderer.flipX = true;

        }

    }

}
