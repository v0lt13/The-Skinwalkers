using UnityEngine;

namespace SkinWalkers.Flashlight
{
    public class FlashlightManager : MonoBehaviour
    {
		public static bool HAS_FLASHLIGHT;
		public static bool IS_FLASHLIGHT_ON = false;

		[SerializeField] private GameObject flashlightObject;
		[SerializeField] private GameObject playerCameraObject;
		[Space]
		[SerializeField] private AudioSource flashLightAudioSource;

		void Start()
		{
			//LoadFlashlight();
		}

		void Update()
		{
			// Gives the flashlight smooth movement
			flashlightObject.transform.SetPositionAndRotation(transform.position, Quaternion.Slerp(flashlightObject.transform.rotation, playerCameraObject.transform.rotation, Time.deltaTime * 10f));

			if (HAS_FLASHLIGHT)
			{
				if (Input.GetKeyDown(KeyCode.F) && !PaperPickup.IS_READING)
				{
					if (!IS_FLASHLIGHT_ON)
					{
						flashlightObject.SetActive(true);
						IS_FLASHLIGHT_ON = true;
					}
					else
					{
						flashlightObject.SetActive(false);
						IS_FLASHLIGHT_ON = false;
					}

					flashLightAudioSource.Play();
				}
			}
		}

		/*
		private void LoadFlashlight()
		{
			if (HAS_FLASHLIGHT)
			{
				if (!IS_FLASHLIGHT_ON)
				{
					flashLight.SetActive(false);
				}
				else
				{
					flashLight.SetActive(true);
				}
			}
		}
		*/
	}
}
