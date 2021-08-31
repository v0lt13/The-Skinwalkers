using UnityEngine;
using UnityEngine.UI;

namespace SkinWalkers.Triggers
{
    public class SubtitleTrigger : MonoBehaviour
    {
		private bool isTriggered;

		//public static int NEXT_SUB_TRIGGER;

		[SerializeField] private string text;
		[Space]
		[SerializeField] private Text subtitleText;
		[Space]
		[SerializeField] private GameObject currentObject;
		[SerializeField] private GameObject nextSubtitleTriggerObject;
		[SerializeField] private GameObject[] triggers;

		void Update()
		{
			if (isTriggered)
			{
				if (nextSubtitleTriggerObject != null) nextSubtitleTriggerObject.SetActive(true);
				currentObject.SetActive(false);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				//NEXT_SUB_TRIGGER++;
				isTriggered = true;
				subtitleText.text = text;
				Invoke(nameof(EraseText), 3f);
			}
		}

		private void EraseText()
		{
			subtitleText.text = string.Empty;
		}
	}
}
