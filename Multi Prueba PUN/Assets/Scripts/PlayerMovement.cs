using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    public float speed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            // Movimiento en los ejes horizontal y vertical
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Aplicar movimiento al Rigidbody
            Vector3 movement = new Vector3(moveX, 0, moveZ) * speed;
            rb.velocity = movement;
        }
    }
}