using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkinWalkers.Menus
{
    public class PauseMenu : MonoBehaviour
    {
		[HideInInspector] public static bool IS_PAUSED = false;
		
		private AudioSource[] audioSources;
		
		[SerializeField] private GameObject pauseMenuObject;
		[SerializeField] private GameObject crosshairObject;

		void Start()
		{
			audioSources = FindObjectsOfType<AudioSource>();
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape) && !PaperPickup.IS_READING)
			{
				if (IS_PAUSED)
				{
					Resume();
				}
				else
				{
					Pause();
				}
			}
		}

		private void Pause()
		{
			pauseMenuObject.SetActive(true);
			crosshairObject.SetActive(false);
			IS_PAUSED = true;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			Time.timeScale = 0;

			foreach (var audioSource in audioSources)
			{
				audioSource.Pause();
			}
		}

		public void Resume()
		{
			pauseMenuObject.SetActive(false);
			crosshairObject.SetActive(true);
			IS_PAUSED = false;
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1;

			foreach (var audioSource in audioSources)
			{
				audioSource.UnPause();
			}
		}

		public void Exit()
		{
			IS_PAUSED = false;
			Time.timeScale = 1;
			SceneManager.LoadScene("MainMenu");
		}
	}
}
