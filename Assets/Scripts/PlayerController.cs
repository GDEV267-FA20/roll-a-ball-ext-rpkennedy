using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI healthText;
    public GameObject winTextObject;
    public GameObject loseTextObject;

    private float movementX;
    private float movementY;

    private Rigidbody rb;
    private float count;
    private int health;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 30;
        health = 5;

        SetCountText();
        SetHealthText();

        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
    }

    void Update()
    {
        if(count > 0)
        {
            count -= Time.deltaTime;
        }
        else
        {
            count = 0;
        }
        SetCountText();
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);

            health = health - 1;

            SetHealthText();
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementY = v.y;
    }

    void SetHealthText()
    {
        if (health <= 0 && count > 0)
        {
            healthText.text = "Health: " + health.ToString();
            loseTextObject.SetActive(true);

        }
        else
        {
            healthText.text = "Health: " + health.ToString();
        }             
    }

    void SetCountText()
    {
        countText.text = "Time Left: " + count.ToString() + "s";

        if (count <= 0 && health > 0)
        {
            winTextObject.SetActive(true);
        }
    }
}

