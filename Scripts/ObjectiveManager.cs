using UnityEngine;
using UnityEngine.UI;

namespace SkinWalkers
{
    public class ObjectiveManager : MonoBehaviour
    {
		[SerializeField] private Animator objectiveAnimator;
		[SerializeField] private Text objectiveText;

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.LeftAlt))
			{
				SetAnimationParameterTrue();
			}
		}

		private void SetAnimationParameterFalse()
		{
			objectiveAnimator.SetBool("Activate", false);
		}

		public void SetAnimationParameterTrue()
		{
			objectiveAnimator.SetBool("Activate", true);
			Invoke(nameof(SetAnimationParameterFalse), 3f);
		}

		public void SetObjective(string objective)
		{
			objectiveText.text = objective;
		}
    }
}
