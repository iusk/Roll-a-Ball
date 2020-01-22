using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    private AudioSource pickup;
    private AudioSource winner;
    private AudioSource source;

    void Start() {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        AudioSource[] source = GetComponents<AudioSource>();
        pickup = source[0];
        winner = source[1];
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
            pickup.Play();
        }
    }

    void SetCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 10) {
            winner.Play();
            winText.text = "Hey, that's pretty good!";
        }
    }
}