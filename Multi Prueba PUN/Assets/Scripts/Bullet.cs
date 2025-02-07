using UnityEngine;
using Photon.Pun;

public class Bullet : MonoBehaviourPun
{
    private float speed;
    private Photon.Realtime.Player owner;

    public void Initialize(float bulletSpeed, Photon.Realtime.Player bulletOwner)
    {
        speed = bulletSpeed;
        owner = bulletOwner;
    }

    void Start()
    {
        // Destruir el proyectil después de un tiempo
        if (photonView.IsMine)
        {
            Invoke("DestroyBullet", 2f); // Destruir después de 2 segundos
        }
    }

    void Update()
    {
        // Mover el proyectil hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (photonView.IsMine && !other.CompareTag("Player"))
        {
            // Destruir el proyectil si choca con algo que no sea un jugador
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        if (photonView.IsMine)
        {
            PhotonNetwork.Destroy(gameObject); // Destruir en todos los clientes
        }
    }
}