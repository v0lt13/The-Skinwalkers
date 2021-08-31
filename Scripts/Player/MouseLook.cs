using UnityEngine;
using SkinWalkers.Menus;

namespace SkinWalkers.Player
{
    public class MouseLook : MonoBehaviour
    {
        public float mouseLockAngle;
		[SerializeField] private float mouseSensitivity;
		private float xRotation = 0f;

        [SerializeField] private Transform playerTransform;

		void Start()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		void Update()
		{
			if (!PauseMenu.IS_PAUSED)
			{
				float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
				float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

				xRotation -= mouseY;
				xRotation = Mathf.Clamp(xRotation, -mouseLockAngle, mouseLockAngle);

				transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
				playerTransform.Rotate(Vector3.up * mouseX);
			}
		}
	}
}
