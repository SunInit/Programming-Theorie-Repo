using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private Inventar playerInventar;
    [SerializeField] private float speed = 50;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInventar = GameObject.Find("InventarHolder").GetComponent<Inventar>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce( speed * horizontalInput * Time.deltaTime * Vector3.forward);
        playerRb.AddForce( speed * verticalInput * Time.deltaTime * Vector3.left);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {
            playerInventar.collected++;
            Destroy(other.gameObject);
        }
    }
}
