using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    public float speed = 10f;
    public float lifetime = 2f;

    void Start()
    {
        // Destruir el proyectil después de un tiempo
        if (photonView.IsMine)
        {
            Destroy(gameObject, lifetime);
        }
    }

    void Update()
    {
        // Mover el proyectil
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine && other.CompareTag("Player"))
        {
            // Aquí puedes añadir lógica para dañar al jugador
            Debug.Log("Jugador golpeado!");
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
