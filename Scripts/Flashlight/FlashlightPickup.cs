using UnityEngine;
using SkinWalkers.Interfaces;

namespace SkinWalkers.Flashlight
{
    public class FlashlightPickup : MonoBehaviour, IPickup
    {
		[SerializeField] private float pickupDistance;
	
		private Camera playerCamera;
		private Tutorial tutorial;

		void Start()
		{
			playerCamera = Camera.main;
			if (Tutorial.TUTORIAL) tutorial = GameObject.Find("Tutorials").GetComponent<Tutorial>();
		}

		void Update()
		{
			if (IsHoveringOver("Flashlight", pickupDistance) && Input.GetKeyDown(KeyCode.E))
			{
				// Enables the flashlight tutorial if the option is enabled
				if (Tutorial.TUTORIAL)
				{
					foreach (var tutorial in tutorial.tutorials)
					{
						tutorial.SetActive(false);
					}

					tutorial.tutorials[4].SetActive(true);
				}

				FlashlightManager.HAS_FLASHLIGHT = true;
				Destroy(gameObject);
			}
		}

		public bool IsHoveringOver(string tag, float distance)
		{
			var ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

			if (Physics.Raycast(ray, out RaycastHit hit, distance))
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
	}
}
