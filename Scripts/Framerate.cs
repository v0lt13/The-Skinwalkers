using UnityEngine;
using UnityEngine.UI;

namespace SkinWalkers
{
    public class Framerate : MonoBehaviour
    {
		public static bool FPS;
		private int frameCounter = 0;
		private float timeCounter = 0.0f;
		private const float REFRESH_TIME = 0.1f;

		[SerializeField] private Text framerateText;

		void Awake()
		{
			if (!FPS)
			{
				gameObject.SetActive(false);
			}
		}

		void Update()
		{
			// Calculating and displaying the game's framerate if the setting is enabled
			if (timeCounter < REFRESH_TIME)
			{
				timeCounter += Time.deltaTime;
				frameCounter++;
			}
			else
			{
				var lastFramerate = frameCounter / timeCounter;
				frameCounter = 0;
				timeCounter = 0.0f;
				framerateText.text = $"FPS: {lastFramerate:n1}";
			}
		}
	}
}
