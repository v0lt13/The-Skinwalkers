using UnityEngine;
using System.Collections;

namespace SkinWalkers.Player
{
	public class PlayerCrouch : MonoBehaviour
	{
		[HideInInspector] public bool isCrouching;
		[HideInInspector] public bool isUnderObject;

		private PlayerManager playerMovement;
		private PlayerFootsteps playerFootsteps;
		private HeadBob headBob;

		void Start()
		{
			playerMovement = GetComponent<PlayerManager>();
			playerFootsteps = GetComponent<PlayerFootsteps>();
			headBob = GetComponent<HeadBob>();
		}

		void Update()
		{
			CheckCeiling();

			if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching && playerMovement.isGrounded)
			{
				Crouch();
			}

			else if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching && playerMovement.isGrounded && !isUnderObject)
			{
				UnCrouch();
			}
		}

		private void Crouch()
		{
			playerMovement.playerSpeed = 1;
			headBob.bobSpeed = 5;
			isCrouching = true;
			playerFootsteps.deafultTimeBetwenFootsteps = 0.8f;

			StartCoroutine(CrouchSmooth());
		}

		private void UnCrouch()
		{
			playerMovement.playerSpeed = 3;
			headBob.bobSpeed = 10;
			isCrouching = false;
			playerFootsteps.deafultTimeBetwenFootsteps = 0.6f;

			StartCoroutine(UnCrouchSmooth());
		}

		private void CheckCeiling()
		{
			// Checkinig for objects above the head using raycast
			var origin = new Vector3(transform.position.x, transform.position.y + (transform.localScale.y * 0.5f), transform.position.z);
			var direction = transform.TransformDirection(Vector3.up);
			float distance = 0.9f;

			if (Physics.Raycast(origin, direction, distance))
			{
				isUnderObject = true;
			}
			else
			{
				isUnderObject = false;
			}
		}

		private IEnumerator CrouchSmooth()
		{
			while (playerMovement.characterControler.height > 1)
			{
				playerMovement.characterControler.height -= 0.2f;
				yield return new WaitForFixedUpdate();
			}
		}

		private IEnumerator UnCrouchSmooth()
		{
			while (playerMovement.characterControler.height < 2)
			{
				playerMovement.characterControler.height += 0.2f;
				yield return new WaitForFixedUpdate();
			}
		}
	}
}
