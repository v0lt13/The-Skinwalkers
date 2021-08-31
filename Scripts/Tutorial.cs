using UnityEngine;

namespace SkinWalkers
{
    public class Tutorial : MonoBehaviour
    {
		public static bool TUTORIAL = true;
		public GameObject[] tutorials;

		void Awake()
		{
			if (!TUTORIAL)
			{
				gameObject.SetActive(false);
			}
		}

		void Update()
		{
			if (tutorials[0].activeSelf)
			{
				if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
				{
					tutorials[0].SetActive(false);
				}
			}

			if (tutorials[1].activeSelf)
			{
				if (Input.GetKeyDown(KeyCode.LeftAlt))
				{
					tutorials[1].SetActive(false);
				}
			}

			if (tutorials[2].activeSelf)
			{
				if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftControl))
				{
					tutorials[2].SetActive(false);
				}
			}

			if (tutorials[3].activeSelf)
			{
				if (Input.GetKeyDown(KeyCode.E))
				{
					tutorials[3].SetActive(false);
				}
			}

			if (tutorials[4].activeSelf)
			{
				if (Input.GetKeyDown(KeyCode.F))
				{
					tutorials[4].SetActive(false);
				}
			}
		}
	}
}
