using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SkinWalkers.Player;
using SkinWalkers.Interfaces;

namespace SkinWalkers
{
	public class PaperPickup : MonoBehaviour, IPickup
	{
		public bool WasRead { get; set; }

		public static bool IS_READING = false;

		[SerializeField] [TextArea] private string writing;
		[Space]
		[SerializeField] private float pickupDistance;
		[Space]
		[SerializeField] private UnityEvent gameEvent;

		[Header ("SubtitleConfig:")]
		[SerializeField] private string text;
		[Space]
		[SerializeField] private Text subtitleText;

		[Header ("Overlay:")]
		[SerializeField] private Text paperText;
		[SerializeField] private GameObject readingOverlayObject;

		private Camera playerCamera;

		void Start()
		{
			playerCamera = Camera.main;
		}

		void Update()
		{
			if (IsHoveringOver("Paper", pickupDistance) && !IS_READING && Input.GetKeyDown(KeyCode.E))
			{
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;

				readingOverlayObject.SetActive(true);
				Time.timeScale = 0f;
				IS_READING = true;
				paperText.text = writing;
			}			
			else if (IS_READING && Input.GetKeyDown(KeyCode.E))
			{
				GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;

				readingOverlayObject.SetActive(false);
				Time.timeScale = 1f;
				IS_READING = false;

				if (!WasRead)
				{
					subtitleText.text = text;
					Invoke(nameof(EraseText), 3f);
					gameEvent.Invoke();
					WasRead = true;
				}
			}
		}

		public bool IsHoveringOver(string tag, float distance)
		{
			var ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			var mask = 1 << 9;

			if (Physics.Raycast(ray, out RaycastHit hit, distance, mask))
			{
				if (hit.collider.CompareTag(tag))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		private void EraseText()
		{
			subtitleText.text = string.Empty;
		}
	}
}
