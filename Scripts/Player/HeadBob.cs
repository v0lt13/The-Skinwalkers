using UnityEngine;

namespace SkinWalkers.Player
{
    public class HeadBob : MonoBehaviour
    {
        [Header ("BobConfig:")]
        public float bobSpeed = 10f;
        private float timer = 0f;
        [Space]
        [SerializeField] private Transform joint;
        [SerializeField] private Vector3 bobAmount = new Vector3(0.15f, 0.05f, 0f);

        private PlayerManager playerMovement;
        private Vector3 jointOriginalPos;

		void Awake()
		{
            jointOriginalPos = joint.localPosition;
        }

		void Start()
		{
			playerMovement = GetComponent<PlayerManager>();
		}

		void Update()
		{
            // Making the head bob while walking using math thats definetly not copyed from somewhere else
            if (playerMovement.isWalking)
            {
                timer += Time.deltaTime * bobSpeed;
                joint.localPosition = new Vector3(jointOriginalPos.x + Mathf.Sin(timer) * bobAmount.x, jointOriginalPos.y + Mathf.Sin(timer) * bobAmount.y, jointOriginalPos.z + Mathf.Sin(timer) * bobAmount.z);
            }
            else
            {
                timer = 0;
                joint.localPosition = new Vector3(Mathf.Lerp(joint.localPosition.x, jointOriginalPos.x, Time.deltaTime * bobSpeed), Mathf.Lerp(joint.localPosition.y, jointOriginalPos.y, Time.deltaTime * bobSpeed), Mathf.Lerp(joint.localPosition.z, jointOriginalPos.z, Time.deltaTime * bobSpeed));
            }
        }
	}
}
