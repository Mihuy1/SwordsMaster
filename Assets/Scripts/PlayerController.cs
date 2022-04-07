using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    Vector3 velocity;
    public LayerMask groundMask;
    public Transform groundCheck;

    public float groundDistance = 0.4f;
    public float turnSmoothTime = 0.1f;

    public float speed;
    public float sprintSpeed;

    public float gravity = -9.81f;
    public float jumpHeight = 1f;

    public int maxHealth = 100;
    public int currentHealth;

    private bool isGrounded;

    float turnSmoothVelocity;

    public HealthBar healthbar;


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(20);
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Player Movement code

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);


        }

        // Sprint code

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
        {
            speed = 6f;
        }

        // Jump code

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Start()
    {
        speed = 6f;
        sprintSpeed = 10f;

        currentHealth = maxHealth;

        healthbar.SetMaxHealth(maxHealth);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene("Main Menu");
    }



   
}
