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
		public static int posY = -120;
		static string ConfigPath = Path.Combine(Main.SavePath, "ModConfigs", "Keystrokes.json");
		static Preferences Configuration = new Preferences(ConfigPath);
		public static Microsoft.Xna.Framework.Input.Keys up = Microsoft.Xna.Framework.Input.Keys.W;
		static int i_up = (int)up;
		public static Microsoft.Xna.Framework.Input.Keys down = Microsoft.Xna.Framework.Input.Keys.S;
		static int i_down = (int)down;
		public static Microsoft.Xna.Framework.Input.Keys left = Microsoft.Xna.Framework.Input.Keys.A;
		static int i_left = (int)left;
		public static Microsoft.Xna.Framework.Input.Keys right = Microsoft.Xna.Framework.Input.Keys.D;
		static int i_right = (int)right;
		public static Microsoft.Xna.Framework.Input.Keys jump = Microsoft.Xna.Framework.Input.Keys.Space;
		static int i_jump = (int)jump;
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
				// Keys
				Configuration.Get("KeyUp", ref i_up);
				up = (Microsoft.Xna.Framework.Input.Keys)i_up;
				Configuration.Get("KeyDown", ref i_down);
				down = (Microsoft.Xna.Framework.Input.Keys)i_down;
				Configuration.Get("KeyLeft", ref i_left);
				left = (Microsoft.Xna.Framework.Input.Keys)i_left;
				Configuration.Get("KeyRight", ref i_right);
				right = (Microsoft.Xna.Framework.Input.Keys)i_right;
				Configuration.Get("KeyJump", ref i_jump);
				jump = (Microsoft.Xna.Framework.Input.Keys)i_jump;
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
			// Keys
			Configuration.Put("KeyUp", i_up);
			Configuration.Put("KeyDown", i_down);
			Configuration.Put("KeyLeft", i_left);
			Configuration.Put("KeyRight", i_right);
			Configuration.Put("KeyJump", i_jump);
			Configuration.Save();
		}
	}
}
