using UnityEngine;
using SkinWalkers.Interfaces;

namespace SkinWalkers.Compass
{
    public class CompassPickup : MonoBehaviour, IPickup
    {
		[SerializeField] private float pickupDistance;

		private Camera cam;

		void Start()
		{
			cam = Camera.main;
		}

		void Update()
		{
			if (IsHoveringOver("Compass", pickupDistance) && Input.GetKeyDown(KeyCode.E))
			{
				CompassManager.HAS_COMPASS = true;
				Destroy(gameObject);
			}
		}

		public bool IsHoveringOver(string tag, float distance)
		{
			var ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

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
