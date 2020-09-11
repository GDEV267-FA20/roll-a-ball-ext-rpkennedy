using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    private Rigidbody rb;
    private float acc;
    private float time;
    private float max;
    private Vector3 move;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        acc = 2f;
        max = 5f;
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            move = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            time += acc;
        }

        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);        
    }

    void OnTriggerEnter()
    {
        move.x = move.x * -1;
    }

    void FixedUpdate()
    {
        rb.AddForce(move * max);
    }
}