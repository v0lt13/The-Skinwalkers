using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkinWalkers
{
    public class Endgame : MonoBehaviour
    {
		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				SceneManager.LoadScene(3);
			}
		}
	}
}
