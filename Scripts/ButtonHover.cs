using UnityEngine;
using SkinWalkers.Interfaces;

namespace SkinWalkers
{
    public class ButtonHover : MonoBehaviour, IPointerEnter, IButtonClick
    {
		[SerializeField] private AudioSource buttonsAudioSource;
		[SerializeField] private AudioClip[] buttonsAudioClips;

		public void OnButtonClick()
		{
			buttonsAudioSource.clip = buttonsAudioClips[0];
			buttonsAudioSource.Play();
		}

		public void OnPointerEnter()
		{
			buttonsAudioSource.clip = buttonsAudioClips[1];
			buttonsAudioSource.Play();
		}
	}
}
