using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float fireRate = .5f;
    private float nextShot = -1f;
    private bool canShoot = true;
    
    private PointManager pointManager;

    public GameObject[] prefab;
    
    public float moveSpeed;
    public Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    public KeyCode jumpKey = KeyCode.Space;
    public float jumpForce;
    public float jumpCooldown;
    public float airMulitplier;
    bool readyToJump = true;
    // Ground check parameters

    public float playerHeight;
    public float groundDrag;
    public LayerMask whatIsGround;
    bool grounded;

    public Camera playerCamera;
    public GameObject bulletPrefab;
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextShot)
        {
            canShoot = true ;
        }
        if (Input.GetMouseButton(0) && canShoot == true)
        {
            Fire(); 
        }
       
        GetInput();
        IsGrounded();
        LimitSpeed();
        Place();
        
    }
    private void FixedUpdate()
    {

        MovePlayer();
    }
    private void Fire()
    {
            canShoot = false;
            GameObject bulletObject = Instantiate(bulletPrefab);
            bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
            bulletObject.transform.forward = playerCamera.transform.forward;
            nextShot = Time.time + fireRate;
    }
    private void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        /*
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            // Repeat jump on spacbar being held
            Invoke(nameof(ResetJump), jumpCooldown);
        }
        */
    }
    private void MovePlayer()
    {
        // Calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMulitplier, ForceMode.Force);
        }
    }
    // Method limits player velocity based on moveSpeed value
    private void LimitSpeed()
    {
        Vector3 Velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (Velocity.magnitude > moveSpeed)
        {
            Vector3 limitedVelocity = Velocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, limitedVelocity.y, limitedVelocity.z);
        }
    }
    private void IsGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }
    private void Jump()
    {
        // Reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
    private void Place()
    {
        pointManager = GameObject.Find("GameManager").GetComponent<PointManager>();
        var input = Input.inputString;
        switch (input)
        {
            // Instantiate Regular Totem
            case "1":
                if (pointManager.points >= 50)
                {
                    pointManager.points -= 50;
                    Instantiate(prefab[0], transform.position + (transform.forward * 2), transform.rotation);
                }
                break;
            // Instantiate Slowing Totem
                case "2":
                if (pointManager.points >= 25)
                {
                    pointManager.points -= 25;
                    Instantiate(prefab[1], transform.position + (transform.forward * 2), transform.rotation);
                }
                break;
            // Instantiate Healing Totem
            case "3":
                if (pointManager.points >= 100)
                {
                    pointManager.points -= 100;
                    Instantiate(prefab[2], transform.position + (transform.forward * 2), transform.rotation);
                }
                break;
        }
        
    }
    
}
