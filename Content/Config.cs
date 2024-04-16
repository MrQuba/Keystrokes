using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace Keystrokes.Content
{
	// based on: https://forums.terraria.org/index.php?threads/modders-guide-to-config-files-and-optional-features.48581/
	public static class Config
	{
		static int bCr = 50, bCg = 70, bCb = 122, bCa = 200;
		public static Color backgroundColor = new(bCr, bCg, bCb, bCa);
		static int boCr = 40, boCg = 40, boCb = 40, boCa = 255;
		public static Color borderColor = new(boCr, boCg, boCb, boCa);
		static int pbCr = 60, pbCg = 83, pbCb = 143, pbCa = 180;
		public static Color pressedBackgroundColor = new(pbCr, pbCg, pbCb, pbCa);
		public static int posX = 850;
		public static int posY = 250;
		static string ConfigPath = Path.Combine(Main.SavePath, "ModConfigs", "KeyStrokes.json");
		static Preferences Configuration = new Preferences(ConfigPath);

		public static void Load()
		{
			bool success = ReadConfig();

			if (!success)
			{
				CreateConfig();
			}
		}

		//Returns "true" if the config file was found and successfully loaded.
		static bool ReadConfig()
		{
			if (Configuration.Load())
			{
				// Background Color
				Configuration.Get("BackgroundColorR", ref bCr);
				Configuration.Get("BackgroundColorG", ref bCg);
				Configuration.Get("BackgroundColorB", ref bCb);
				Configuration.Get("BackgroundColorA", ref bCa);
				backgroundColor = new(bCr, bCg, bCb, bCa);
				// Pressed Background Color
				Configuration.Get("PressedBackgroundColorR", ref pbCr);
				Configuration.Get("PressedBackgroundColorG", ref pbCg);
				Configuration.Get("PressedBackgroundColorB", ref pbCb);
				Configuration.Get("PressedBackgroundColorA", ref pbCa);
				borderColor = new(boCr, boCg, boCb, boCa);
				//Border Color
				Configuration.Get("BorderColorR", ref boCr);
				Configuration.Get("BorderColorG", ref boCg);
				Configuration.Get("BorderColorB", ref boCb);
				Configuration.Get("BorderColorA", ref boCa);
				pressedBackgroundColor = new(pbCr, pbCg, pbCb, pbCa);
				// Position
				Configuration.Get("PositionX", ref posX);
				Configuration.Get("PositionY", ref posY);
				return true;
			}
			return false;
		}

		//Creates a config file. This will only be called if the config file doesn't exist yet or it's invalid. 
		static void CreateConfig()
		{
			Configuration.Clear();// Background Color
			Configuration.Put("BackgroundColorR", bCr);
			Configuration.Put("BackgroundColorG", bCg);
			Configuration.Put("BackgroundColorB", bCb);
			Configuration.Put("BackgroundColorA", bCa);
			// Pressed Background Color
			Configuration.Put("PressedBackgroundColorR", pbCr);
			Configuration.Put("PressedBackgroundColorG", pbCg);
			Configuration.Put("PressedBackgroundColorB", pbCb);
			Configuration.Put("PressedBackgroundColorA", pbCa);
			//Border Color
			Configuration.Put("BorderColorR", boCr);
			Configuration.Put("BorderColorG", boCg);
			Configuration.Put("BorderColorB", boCb);
			Configuration.Put("BorderColorA", boCa);
			// Position
			Configuration.Put("PositionX", posX);
			Configuration.Put("PositionY", posY);
			Configuration.Save();
		}
	}
}
