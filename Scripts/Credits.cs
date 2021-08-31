using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkinWalkers
{
    public class Credits : MonoBehaviour
    {
		void Start()
		{
			Invoke(nameof(MoveScene), 20f);
		}

		void Update()
		{
			if (Input.anyKeyDown)
			{
				MoveScene();
			}
		}

        private void MoveScene()
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			SceneManager.LoadScene(0);
		}
    }
}
