using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    private AudioMixer audioMixer;
    private AudioMixerSnapshot unpausedSnapshot;
    private AudioMixerSnapshot pausedSnapshot;

    void Start()
    {
        // Bet�ltj�k az AudioMixer-t a Resources mapp�b�l
        audioMixer = Resources.Load<AudioMixer>("MainAudioMixer");

        // Lek�rj�k a Snapshot-okat
        unpausedSnapshot = audioMixer.FindSnapshot("Unpaused");
        pausedSnapshot = audioMixer.FindSnapshot("Paused");
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                StartCoroutine(PauseWithTransition());
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        unpausedSnapshot.TransitionTo(0.3f); // �t�ll�tjuk a norm�l Snapshot-ra
    }

    IEnumerator PauseWithTransition()
    {
        pauseMenuUI.SetActive(true);
        pausedSnapshot.TransitionTo(0.3f); // �t�ll�tjuk a sz�neteltetett Snapshot-ra
        yield return new WaitForSecondsRealtime(0.3f); // V�runk, hogy az �tmenet befejez�dj�n
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1f;
        var playerConfigManager = FindObjectOfType<PlayerConfigurationManager>();
        if (playerConfigManager != null)
        {
            playerConfigManager.ResetPlayerWins();
            Destroy(playerConfigManager.gameObject);
        }
        SceneManager.LoadScene("MainMenu");
        unpausedSnapshot.TransitionTo(2.0f);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
