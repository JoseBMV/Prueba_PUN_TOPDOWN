using UnityEngine;
using Photon.Pun;

public class PlayerShooting : MonoBehaviourPun
{
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de disparo
    public float bulletSpeed = 10f;

    void Update()
    {
        if (photonView.IsMine)
        {
            // Disparar al presionar el botón de disparo (clic izquierdo del ratón)
            if (Input.GetButtonDown("Fire1"))
            {
                photonView.RPC("Shoot", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void Shoot()
    {
        // Instanciar el proyectil en red
        GameObject bullet = PhotonNetwork.Instantiate("Bullet", firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet>().Initialize(bulletSpeed, photonView.Owner);
    }
}