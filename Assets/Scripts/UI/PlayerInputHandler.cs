using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerConfiguration playerConfig; // A j�t�kos konfigur�ci�
    private PlayerMovement playerMovement; // A j�t�kos mozg�s script
    private PlayerControls controls; // Az Input System vez�rl�k

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>(); // PlayerMovement inicializ�l�sa
        controls = new PlayerControls(); // PlayerControls p�ld�ny
    }

    private void OnEnable()
    {
        controls.Player.Enable(); // Player input enged�lyez�se
    }

    private void OnDisable()
    {
        controls.Player.Disable(); // Player input letilt�sa
    }

    public void InitializePlayer(PlayerConfiguration config)
    {
        playerConfig = config;
        config.Input.onActionTriggered += OnActionTriggered; // Feliratkoz�s az akci� ind�t�si esem�nyekre
    }

    public PlayerConfiguration GetPlayerConfig()
    {
        return playerConfig;
    }

    private void OnActionTriggered(CallbackContext context)
    {
        if (context.action.name == "Movement")
        {
            HandleMovement(context); // Kezelj�k a mozg�st
        }
        else if (context.action.name == "PlaceBomb")
        {
            HandleBombPlace(context); // Kezelj�k a bomba elhelyez�s�t
        }
        else if (context.action.name == "Detonate")
        {
            HandleDetonate(context); // Kezelj�k a deton�ci�t
        }
    }

    private void HandleMovement(CallbackContext context)
    {
        if (playerMovement != null)
        {
            Vector2 movement = context.ReadValue<Vector2>();
            playerMovement.OnMove(context); // Adjuk �t a mozg�si bemeneteket

        }
    }

    private void HandleBombPlace(CallbackContext context)
    {
        if (context.performed)
        {
            playerMovement.OnBombPlace(context); // Kezelj�k a bomba elhelyez�s�t
        }
    }

    private void HandleDetonate(CallbackContext context)
    {
        if (context.performed)
        {
            playerMovement.OnDetonate(context); // Kezelj�k a deton�ci�t
        }
    }
}
