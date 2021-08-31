using UnityEngine;
using SkinWalkers.Data;
using SkinWalkers.Menus;

namespace SkinWalkers.Player
{
	public class PlayerManager : MonoBehaviour
	{
		public enum GroundType 
		{ 
			Terrain,
			Metal,
			Wood
		};

		[HideInInspector] public GroundType groundType;
		[HideInInspector] public bool isWalking;
		[HideInInspector] public bool isGrounded;
		[HideInInspector] public bool isRunning;

		[Header ("PlayerConfig:")]
		public float playerSpeed;
		[SerializeField] private float gravity;

		public CharacterController characterControler;
		private HeadBob headBob;
		private PlayerFootsteps playerFootsteps;
		private PlayerCrouch playerCrouch;

		private Vector3 velocity;

		void Awake()
		{
			//GameManager.INSTANCE.player = this;
			//if (PlayMenu.IS_CONTINUE) SaveAndLoadDataManager.Load();

			if (!PlayMenu.IS_CONTINUE)
			{
				Flashlight.FlashlightManager.IS_FLASHLIGHT_ON = false;
				Flashlight.FlashlightManager.HAS_FLASHLIGHT = false;
				Compass.CompassManager.HAS_COMPASS = false;
			}
		}

		void Start()
		{
			headBob = GetComponent<HeadBob>();
			playerFootsteps = GetComponent<PlayerFootsteps>();
			playerCrouch = GetComponent<PlayerCrouch>();
		}

		void Update()
		{
			if (isGrounded && velocity.y < 0)
			{
				velocity.y = -2f;
			}

			if (Input.GetKeyDown(KeyCode.LeftShift) && isWalking && !playerCrouch.isCrouching)
			{
				playerSpeed = 5;
				headBob.bobSpeed = 13;
				playerFootsteps.deafultTimeBetwenFootsteps = 0.4f;
				isRunning = true;
			}
			else if (Input.GetKeyUp(KeyCode.LeftShift) && !playerCrouch.isCrouching)
			{
				playerSpeed = 3;
				headBob.bobSpeed = 10;
				playerFootsteps.deafultTimeBetwenFootsteps = 0.6f;
				isRunning = false;
			}

			CheckGround();
			Move();
		}

		void FixedUpdate()
		{
			var targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			if (targetVelocity.x != 0 || targetVelocity.z != 0 && isGrounded)
			{
				isWalking = true;
			}
			else
			{
				isWalking = false;
			}
		}

		private void Move()
		{
			float x = Input.GetAxis("Horizontal");
			float z = Input.GetAxis("Vertical");

			var move = transform.right * x + transform.forward * z;

			characterControler.Move(playerSpeed * Time.deltaTime * move);

			if (velocity.y > -20f)
			{
				velocity.y += gravity * Time.deltaTime;
			}

			characterControler.Move(velocity * Time.deltaTime);
		}

		private void CheckGround()
		{
			// Checking if the player is grounded using raycast
			var origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * 0.5f), transform.position.z);
			var direction = transform.TransformDirection(Vector3.down);
			float distance = 0.75f;

			if (Physics.Raycast(origin, direction, out RaycastHit hit, distance))
			{
				isGrounded = true;

				// Checking for the floor type to play the correct footstep sounds
				if (hit.collider.CompareTag("WoodFloor"))
				{
					groundType = GroundType.Wood;
				}
				else if (hit.collider.CompareTag("MetalFloor"))
				{
					groundType = GroundType.Metal;
				}
				else
				{
					groundType = GroundType.Terrain;
				}
			}
			else
			{
				isGrounded = false;
			}
		}
	}
}
