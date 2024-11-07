using UnityEngine;

public class MoreBombsPU : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerObject"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.IncreaseBombCount();
                Destroy(gameObject);  // Elt�vol�tja a Power Up-ot a j�t�kb�l
            }
        }
    }
}
