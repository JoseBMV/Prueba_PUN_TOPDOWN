using UnityEngine;
using Photon.Pun;

public class PlayerAiming : MonoBehaviourPun
{
    void Update()
    {
        if (photonView.IsMine)
        {
            // Obtener la posición del cursor en el mundo
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Calcular la dirección hacia el cursor
                Vector3 direction = hit.point - transform.position;
                direction.y = 0; // Ignorar la componente Y (no rotar en el eje vertical)

                // Rotar el jugador hacia la dirección del cursor
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
                }
            }
        }
    }
}