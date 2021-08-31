using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SkinWalkers.Data;
using UnityEngine.SceneManagement;

namespace SkinWalkers.Menus
{
	// Unused menu
    public class PlayMenu : MonoBehaviour
    {
		public static bool IS_CONTINUE;
		[SerializeField] private GameObject mainMenuObject;
		[SerializeField] private GameObject continueButtonObject;

		void Start()
		{
			if (File.Exists(Application.dataPath + "/Save.tsw"))
			{
				continueButtonObject.GetComponent<Image>().raycastTarget = true;
				continueButtonObject.GetComponent<Button>().interactable = true;
			}
		}

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				MainMenu();
			}
		}

		public void MainMenu()
		{
			mainMenuObject.SetActive(true);
			gameObject.SetActive(false);
		}

		public void NewGame()
		{
			SceneManager.LoadScene("LoadingScreen");
			IS_CONTINUE = false;
		}

		public void Continue()
		{
			SceneManager.LoadScene("LoadingScreen");
			IS_CONTINUE = true;
		}
	}
}
