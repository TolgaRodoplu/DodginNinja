using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float health = 3f;
    float moveSpeed = 50f;
    float jumpSpeed = 3f;
    float gravity = -20f;
    Rigidbody rb;
    Animator animController;
    float dir;
    bool isGrounded = true;
    public Transform child;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        EventSystem.instance.gameEnded += Disable;
        animController= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = Input.GetAxisRaw("Horizontal") * moveSpeed;

        
        if (dir < 0)
        {
            child.rotation = Quaternion.Euler(0, 270, 0);
            animController.SetBool("isRunning", true);
        }
        
        else if (dir > 0)
        {
            child.localRotation = Quaternion.Euler(0, 0, 0);
            animController.SetBool("isRunning", true);
        }
        else
            animController.SetBool("isRunning", false);



        Debug.Log(dir);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            animController.SetTrigger("Jump");
        }
    }

    void FixedUpdate()
    {
            rb.velocity = new Vector3(dir * Time.fixedDeltaTime, rb.velocity.y, 0);
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Floor"))
            isGrounded = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        health--;
        EventSystem.instance.UpdateHealth(health);

        if (health == 0)
        {
            Death();
        }
    }

    void Death()
    {
        EventSystem.instance.EndGame("YOU DIED");
    }

    private void Disable(object sender, string str)
    {
        this.enabled = false;
    }
}
