using UnityEngine;

namespace SkinWalkers
{
    public class PickupArrow : MonoBehaviour
    {
		[SerializeField] private float activationDistance;
		[SerializeField] private GameObject playerObject;

		void Update()
		{
			transform.LookAt(GameObject.Find("Main Camera").transform);
			transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

			// Claculating the distance from the player using M A T H
			if ((playerObject.transform.position - transform.position).sqrMagnitude < activationDistance * activationDistance)
			{
				gameObject.GetComponent<SpriteRenderer>().enabled = true;
			}
			else
			{
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
			}
		}
    }
}
