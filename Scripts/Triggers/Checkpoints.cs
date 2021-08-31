using UnityEngine;
using SkinWalkers.Data;
using SkinWalkers.Compass;

namespace SkinWalkers.Triggers
{
    public class Checkpoints : MonoBehaviour
    {
		public bool IsCheckpointActivated { get; set; }

		//public static int NEXT_CHECKPOINT;

		[SerializeField] private GameObject currentObject;
		[SerializeField] private GameObject nextCheckpointObject;
		[SerializeField] private GameObject[] checkpoints;
		private CompassManager compassManager;

		void Start()
		{
			compassManager = GameObject.Find("PlayerController").GetComponent<CompassManager>();
		}

		void Update()
		{
			if (IsCheckpointActivated)
			{
				if (nextCheckpointObject != null) nextCheckpointObject.SetActive(true);
				currentObject.SetActive(false);
			}
		}

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				if (IsCheckpointActivated) return;

				IsCheckpointActivated = true;
				compassManager.CheckpointNumber++;
				//NEXT_CHECKPOINT++;
				//SaveAndLoadDataManager.Save();
			}
		}
	}
}
