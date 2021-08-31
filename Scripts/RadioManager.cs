using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SkinWalkers.Interfaces;

namespace SkinWalkers
{
	public class RadioManager : MonoBehaviour, IPickup
	{
		public static bool WAS_USED;
		[SerializeField] private float pickupDistance;
		[Space]
		[SerializeField] private UnityEvent gameEvent;

		[Header ("SubtitleConfig:")]
		[SerializeField] private string text;
		[SerializeField] private Text subtitleText;

		private Camera playerCamera;

		void Start()
		{
			playerCamera = Camera.main;
		}

		void Update()
		{
			if (IsHoveringOver("Radio", pickupDistance) && Input.GetKeyDown(KeyCode.E))
			{
				if (!WAS_USED)
				{
					gameEvent.Invoke();
					subtitleText.text = text;
					Invoke(nameof(EraseText), 3f);
					WAS_USED = true;
				}
			}
		}

		public bool IsHoveringOver(string tag, float distance)
		{
			var ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
			var mask = 1 << 8;

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
