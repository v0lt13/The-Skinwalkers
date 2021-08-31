using UnityEngine;

namespace SkinWalkers
{
    public class RotateSky : MonoBehaviour
    {
		[SerializeField] private float rotateSpeed;

		void Update()
		{
			RenderSettings.skybox.SetFloat("_Rotation", Time.time * rotateSpeed);
		}
	}
}
