using System.IO;
using UnityEngine;
using SkinWalkers.Compass;
using SkinWalkers.Triggers;
using SkinWalkers.Flashlight;
using System.Runtime.Serialization.Formatters.Binary;

namespace SkinWalkers.Data
{
	// Unfinished data saving due to buggyness
	public class SaveAndLoadDataManager
	{
		/*private static readonly BinaryFormatter bf = new BinaryFormatter();

		public static void Save()
		{
			GameData save = CreateSaveGameObject();

			FileStream fileStream = File.Create(Application.dataPath + "/Save.tsw");

			bf.Serialize(fileStream, save);
			fileStream.Close();
		}

		public static void Load()
		{
			if (File.Exists(Application.dataPath + "/Save.tsw"))
			{
				FileStream fileStream = File.Open(Application.dataPath + "/Save.tsw", FileMode.Open);

				GameData gameData = bf.Deserialize(fileStream) as GameData;
				fileStream.Close();

				FlashlightManager.HAS_FLASHLIGHT = gameData.hasFlashlight;
				CompassManager.HAS_COMPASS = gameData.hasCompass;
				FlashlightManager.IS_FLASHLIGHT_ON = gameData.hasFlashlightOn;
				Checkpoints.NEXT_CHECKPOINT = gameData.currentCheckpoint;
				SubtitleTrigger.NEXT_SUB_TRIGGER = gameData.currentSubTrigger;
				RadioManager.WAS_USED = gameData.isRadioOn;

				GameManager.INSTANCE.player.transform.position = new Vector3(gameData.playerPositionX, gameData.playerPositionY, gameData.playerPositionZ);
			}
		}

		private static GameData CreateSaveGameObject()
		{
			GameData gameData = new GameData
			{
				currentCheckpoint = Checkpoints.NEXT_CHECKPOINT,
				currentSubTrigger = SubtitleTrigger.NEXT_SUB_TRIGGER,

				hasFlashlight = FlashlightManager.HAS_FLASHLIGHT,
				hasCompass = CompassManager.HAS_COMPASS,
				hasFlashlightOn = FlashlightManager.IS_FLASHLIGHT_ON,
				isRadioOn = RadioManager.WAS_USED,

				playerPositionX = GameManager.INSTANCE.player.transform.position.x,
				playerPositionY = GameManager.INSTANCE.player.transform.position.y,
				playerPositionZ = GameManager.INSTANCE.player.transform.position.z
			};

			return gameData;
		}*/
	}
}
