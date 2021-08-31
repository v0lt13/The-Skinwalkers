using UnityEngine;
using UnityEngine.UI;

namespace SkinWalkers.Compass
{
    public class CompassManager : MonoBehaviour
    {
		public int CheckpointNumber { get; set; }

        public static bool HAS_COMPASS;

		[SerializeField] private Text checkpointDistanceText;

		[Header ("Gameobjects:")]
		[SerializeField] private GameObject checkpointDistanceUIObject;
		[Space]
		[SerializeField] private GameObject[] checkpoints;

		void Update()
		{
			if (HAS_COMPASS)
			{
				checkpointDistanceUIObject.SetActive(true);
			}

			// Tries to calculate the distance betwen the player and the next checkpoint and displays it
			// Returns if there are no more checkpoints
			try
			{
				checkpointDistanceText.text = Vector3.Distance(transform.position, checkpoints[CheckpointNumber].transform.position).ToString("n0") + "m";
			} 
			catch (System.IndexOutOfRangeException)
			{
				if (checkpointDistanceUIObject.activeSelf) checkpointDistanceUIObject.SetActive(false);
				return;
			}
		}
    }
}
