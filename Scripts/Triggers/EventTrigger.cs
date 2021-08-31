using UnityEngine;
using UnityEngine.Events;

namespace SkinWalkers.Triggers
{
    public class EventTrigger : MonoBehaviour
    {
		[SerializeField] private UnityEvent gameEvent;

		void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				gameEvent.Invoke();
			}
		}
	}
}
