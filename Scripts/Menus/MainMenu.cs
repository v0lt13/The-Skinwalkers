using UnityEngine;

namespace SkinWalkers.Menus
{
    public class MainMenu : MonoBehaviour
    {
		[SerializeField] private GameObject optionsMenuObject;
		[SerializeField] private GameObject playMenuObject;
		private OptionsMenu optionsMenu;

		void Awake()
		{
			optionsMenu = optionsMenuObject.GetComponent<OptionsMenu>();
			optionsMenu.LoadSettings();
		}

		public void Play()
		{			
			/*
			playMenuObject.SetActive(true);
			gameObject.SetActive(false);
			*/

			UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScreen");
			PlayMenu.IS_CONTINUE = false;
		}

        public void OptionsMenu()
		{
			optionsMenuObject.SetActive(true);
			gameObject.SetActive(false);
		}

        public void Exit()
		{
			Application.Quit();
		}

		public void Discord()
		{
			Application.OpenURL("https://discord.gg/jKXvXyTzYn");
		}
    }
}
