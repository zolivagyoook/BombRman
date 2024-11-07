using UnityEngine;

public class AddPlayerConfigManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerConfigManagerPrefab;  // Hivatkoz�s a PlayerConfigurationManager prefabra

    public void AddPlayerConfigM()
    {
        // Ellen�rizz�k, hogy a PlayerConfigurationManager.Instance m�r l�tezik-e
        if (PlayerConfigurationManager.Instance == null)
        {
            // Ha nincs, akkor l�trehozzuk a prefabb�l
            GameObject newPlayerConfigManager = Instantiate(playerConfigManagerPrefab);

            // Gy�z�dj meg r�la, hogy ez a gy�k�robjektum, �s nem egy al�rendelt objektum
            newPlayerConfigManager.transform.SetParent(null);

            // DontDestroyOnLoad biztos�t�sa a jelenetv�lt�sok t�l�l�s�hez
            DontDestroyOnLoad(newPlayerConfigManager);

            Debug.Log("PlayerConfigurationManager instantiated and added to the scene.");
        }
        else
        {
            Debug.Log("PlayerConfigurationManager already exists.");
        }
    }
}
