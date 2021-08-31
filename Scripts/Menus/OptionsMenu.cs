using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;
using SkinWalkers.Data;
using UnityEngine.Audio;

namespace SkinWalkers
{
    public class OptionsMenu : MonoBehaviour
    {
		private readonly OptionsData optionsSave = new OptionsData();

		[Header ("Components:")]
		[SerializeField] private Toggle fullscreenToggle;
		[SerializeField] private Toggle vsyncToggle;
		[SerializeField] private Toggle fpsToggle;
		[SerializeField] private Toggle tutorialToggle;
		[Space]
		[SerializeField] private Slider musicSlider;
		[SerializeField] private Slider sfxSlider;
		[Space]
		[SerializeField] private Dropdown resolutionDropdown;
		[Space]
		[SerializeField] private AudioMixer sfxMixer;
		[SerializeField] private AudioMixer musicMixer;

		[Header ("GameObjects:")]
		[SerializeField] private GameObject mainMenuObject;
		[SerializeField] private GameObject audioSettingsObject;
		[SerializeField] private GameObject videoSettingssObject;
		[SerializeField] private GameObject otherSettingssObject;
		[Space]
		[SerializeField] private GameObject[] resolutionObjects;

		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				MainMenu();
			}

			if (fullscreenToggle.isOn)
			{
				foreach (var resolutionObject in resolutionObjects)
				{
					resolutionObject.SetActive(false);
				}
			}
			else
			{
				foreach (var resolutionObject in resolutionObjects)
				{
					resolutionObject.SetActive(true);
				}
			}
		}

		public void MainMenu()
		{
			mainMenuObject.SetActive(true);
			gameObject.SetActive(false);
		}

		public void AudioSettings()
		{
			audioSettingsObject.SetActive(true);
			videoSettingssObject.SetActive(false);
			otherSettingssObject.SetActive(false);
		}

		public void VideoSettings()
		{
			videoSettingssObject.SetActive(true);
			audioSettingsObject.SetActive(false);
			otherSettingssObject.SetActive(false);
		}

		public void OtherSettings()
		{
			otherSettingssObject.SetActive(true);
			videoSettingssObject.SetActive(false);
			audioSettingsObject.SetActive(false);
		}

		public void SfxVolume(float volume)
		{
			sfxMixer.SetFloat("SFX", volume);

			SaveSettings();
		}

		public void MusicVolume(float volume)
		{
			musicMixer.SetFloat("Music", volume);

			SaveSettings();
		}

		public void ToogleFullScreen(bool fullScreen)
		{
			if (fullScreen)
			{
				resolutionDropdown.value = 0;
				Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
			}
			else
			{
				Screen.fullScreenMode = FullScreenMode.Windowed;
			}

			SaveSettings();
		}

		public void ToogleVsync(bool vsync)
		{
			if (vsync)
			{
				QualitySettings.vSyncCount = 1;
			}
			else
			{
				QualitySettings.vSyncCount = 0;
			}

			SaveSettings();
		}

		public void SetResolution(int resolution)
		{
			switch (resolution)
			{
				case 0:
					Screen.SetResolution(1920, 1080, false);
					break;

				case 1:
					Screen.SetResolution(1768, 992, false);
					break;

				case 2:
					Screen.SetResolution(1600, 900, false);
					break;

				case 3:
					Screen.SetResolution(1366, 768, false);
					break;

				case 4:
					Screen.SetResolution(1280, 720, false);
					break;

				case 5:
					Screen.SetResolution(1176, 664, false);
					break;
			}

			SaveSettings();
		}

		public void ToogleFPS(bool fps)
		{
			if (fps)
			{
				Framerate.FPS = true;
			}
			else
			{
				Framerate.FPS = false;
			}

			SaveSettings();
		}

		public void ToogleTutorial(bool tutorial)
		{
			if (tutorial)
			{
				Tutorial.TUTORIAL = true;
			}
			else
			{
				Tutorial.TUTORIAL = false;
			}

			SaveSettings();
		}

		public void LoadSettings()
		{
			if (File.Exists(Application.dataPath + "/Options.xml"))
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.Load(Application.dataPath + "/Options.xml");

				XmlNodeList musicVol = xmlDocument.GetElementsByTagName("MusicVol");
				optionsSave.musicVolume = float.Parse(musicVol[0].InnerText);

				XmlNodeList sfxVol = xmlDocument.GetElementsByTagName("SFXVol");
				optionsSave.sfxVolume = float.Parse(sfxVol[0].InnerText);

				XmlNodeList isFullscreen = xmlDocument.GetElementsByTagName("IsFullscreenOn");
				optionsSave.isFullscreenOn = bool.Parse(isFullscreen[0].InnerText);

				XmlNodeList isVsync = xmlDocument.GetElementsByTagName("IsVsyncOn");
				optionsSave.isVsyncOn = bool.Parse(isVsync[0].InnerText);

				XmlNodeList isFps = xmlDocument.GetElementsByTagName("IsShowFpsOn");
				optionsSave.isShowFpsOn = bool.Parse(isFps[0].InnerText);

				XmlNodeList isTutorial = xmlDocument.GetElementsByTagName("IsTutorialOn");
				optionsSave.isTutorialOn = bool.Parse(isTutorial[0].InnerText);

				XmlNodeList resolutionVal = xmlDocument.GetElementsByTagName("ResolutionValue");
				optionsSave.resolutionValue = int.Parse(resolutionVal[0].InnerText);

				sfxSlider.value = optionsSave.sfxVolume;
				resolutionDropdown.value = optionsSave.resolutionValue;
				musicSlider.value = optionsSave.musicVolume;
				fullscreenToggle.isOn = optionsSave.isFullscreenOn;
				vsyncToggle.isOn = optionsSave.isVsyncOn;
				fpsToggle.isOn = optionsSave.isShowFpsOn;
				tutorialToggle.isOn = optionsSave.isTutorialOn;
			}
		}

		private void SaveSettings()
		{
			OptionsData optionsSave = CreateSaveOptionsObject();
			XmlDocument xmlDocument = new XmlDocument();

			XmlElement root = xmlDocument.CreateElement("Options");
			root.SetAttribute("FileName", "Options.xml");

			XmlElement musicVolElement = xmlDocument.CreateElement("MusicVol");
			musicVolElement.InnerText = optionsSave.musicVolume.ToString();
			root.AppendChild(musicVolElement);

			XmlElement sfxVolElement = xmlDocument.CreateElement("SFXVol");
			sfxVolElement.InnerText = optionsSave.sfxVolume.ToString();
			root.AppendChild(sfxVolElement);

			XmlElement isFullscreenElement = xmlDocument.CreateElement("IsFullscreenOn");
			isFullscreenElement.InnerText = optionsSave.isFullscreenOn.ToString();
			root.AppendChild(isFullscreenElement);

			XmlElement isVsyncElement = xmlDocument.CreateElement("IsVsyncOn");
			isVsyncElement.InnerText = optionsSave.isVsyncOn.ToString();
			root.AppendChild(isVsyncElement);

			XmlElement isFpsElement = xmlDocument.CreateElement("IsShowFpsOn");
			isFpsElement.InnerText = optionsSave.isShowFpsOn.ToString();
			root.AppendChild(isFpsElement);

			XmlElement isTutorialElement = xmlDocument.CreateElement("IsTutorialOn");
			isTutorialElement.InnerText = optionsSave.isTutorialOn.ToString();
			root.AppendChild(isTutorialElement);

			XmlElement resolutionValueElement = xmlDocument.CreateElement("ResolutionValue");
			resolutionValueElement.InnerText = optionsSave.resolutionValue.ToString();
			root.AppendChild(resolutionValueElement);

			xmlDocument.AppendChild(root);

			xmlDocument.Save(Application.dataPath + "/Options.xml");
		}

		private OptionsData CreateSaveOptionsObject()
		{
			OptionsData optionsSave = new OptionsData
			{
				sfxVolume = sfxSlider.value,
				musicVolume = musicSlider.value,
				isFullscreenOn = fullscreenToggle.isOn,
				isVsyncOn = vsyncToggle.isOn,
				isShowFpsOn = fpsToggle.isOn,
				isTutorialOn = tutorialToggle.isOn,
				resolutionValue = resolutionDropdown.value
			};

			return optionsSave;
		}
	}
}
