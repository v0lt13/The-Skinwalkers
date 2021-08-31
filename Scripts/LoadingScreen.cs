using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SkinWalkers
{
    public class LoadingScreen : MonoBehaviour
    {
		[SerializeField] private Slider loadingSlider;
		[SerializeField] private RawImage backgorundImage;
		[Space]
		[SerializeField] private Texture[] backgoundImages;

		void Awake()
		{
			backgorundImage.texture = backgoundImages[Random.Range(0, backgoundImages.Length)];
		}

		void Start()
		{
			StartCoroutine(LoadingAsync());
		}

		private IEnumerator LoadingAsync()
		{
			AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

			while (!operation.isDone)
			{
				loadingSlider.value = operation.progress;
				yield return null;
			}
		}
	}
}
