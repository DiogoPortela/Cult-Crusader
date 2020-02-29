using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour
{
    public float moveForce;
    private new Rigidbody rigidbody;
    public AudioSource walkSound;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(Settings.Instance.playerUp) && !Input.GetKey(Settings.Instance.playerDown))
            rigidbody.AddForce(0, 0, moveForce * Time.deltaTime, ForceMode.Acceleration);
        else if (Input.GetKey(Settings.Instance.playerDown) && !Input.GetKey(Settings.Instance.playerUp))
            rigidbody.AddForce(0, 0, -moveForce * Time.deltaTime, ForceMode.Acceleration);
        if (Input.GetKey(Settings.Instance.playerLeft) && !Input.GetKey(Settings.Instance.playerRight))
            rigidbody.AddForce(-moveForce * Time.deltaTime, 0, 0, ForceMode.Acceleration);
        else if (Input.GetKey(Settings.Instance.playerRight) && !Input.GetKey(Settings.Instance.playerLeft))
            rigidbody.AddForce(moveForce * Time.deltaTime, 0, 0, ForceMode.Acceleration);
    }

    public float acc;
    private void Update() {
        if (rigidbody.velocity.magnitude > 0.1f && !walkSound.isPlaying)
        {
            walkSound.Stop();
            walkSound.Play();
        }
        walkSound.volume = rigidbody.velocity.magnitude / 7.0f;
    }
    private void OnDisable() {
        walkSound.Stop();
    }
}
