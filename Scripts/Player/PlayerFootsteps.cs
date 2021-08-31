using UnityEngine;

namespace SkinWalkers.Player
{
    public class PlayerFootsteps : MonoBehaviour
    {
		public float TimeBetwenFootsteps { get; set; }

		public float deafultTimeBetwenFootsteps;

		[Header ("Components:")]
		[SerializeField] private AudioSource footstepsAudioSource;
		[Space]
		[SerializeField] private AudioClip[] footsteps;
		[SerializeField] private AudioClip[] metalFootsteps;
		[SerializeField] private AudioClip[] woodFootsteps;
		private PlayerManager playerMovement;

		void Start()
		{
			playerMovement = GetComponent<PlayerManager>();

			TimeBetwenFootsteps = deafultTimeBetwenFootsteps;
		}

		void Update()
		{
			if (playerMovement.isWalking)
			{
				TimeBetwenFootsteps -= Time.deltaTime;
			}

			if (TimeBetwenFootsteps <= 0)
			{
				switch (playerMovement.groundType)
				{
					case PlayerManager.GroundType.Terrain:
						footstepsAudioSource.clip = footsteps[Random.Range(0, footsteps.Length)];
						break;

					case PlayerManager.GroundType.Metal:
						footstepsAudioSource.clip = metalFootsteps[Random.Range(0, metalFootsteps.Length)];
						break;

					case PlayerManager.GroundType.Wood:
						footstepsAudioSource.clip = woodFootsteps[Random.Range(0, woodFootsteps.Length)];
						break;
				}

				footstepsAudioSource.PlayOneShot(footstepsAudioSource.clip);

				TimeBetwenFootsteps = deafultTimeBetwenFootsteps;
			}
		}
	}
}
