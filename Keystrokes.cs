using Keystrokes.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Keystrokes
{
	public class Keystrokes : ModSystem
    {
        public void KeystrokeInit()
        {
            Upkeystroke.Initialize();
            TopInterface = new UserInterface();
            TopInterface.SetState(Upkeystroke);


            Downkeystroke.Initialize();
            BottomInterface = new UserInterface();
            BottomInterface.SetState(Downkeystroke);

            Leftkeystroke.Initialize();
            LeftInterface = new UserInterface();
            LeftInterface.SetState(Leftkeystroke);

            Rightkeystroke.Initialize();
            RightInterface = new UserInterface();
            RightInterface.SetState(Rightkeystroke);

            Spacekeystroke.Initialize();
            JumpInterface = new UserInterface();
            JumpInterface.SetState(Spacekeystroke);
        }

		internal Keystroke Upkeystroke;
        internal Keystroke Downkeystroke;
        internal Keystroke Leftkeystroke;
        internal Keystroke Rightkeystroke;
        internal Keystroke Spacekeystroke;
        public UserInterface TopInterface, BottomInterface, LeftInterface, RightInterface, JumpInterface;

		public override void Load()
        {
			Config.Load();
			if (!Main.dedServ)
            {

                Upkeystroke = new Keystroke(Config.up, new Vector2(Config.posX + 32, 0), new Vector2(Config.posY + 128, 0), new Vector2(32, 0), new Vector2(32, 0), 32, 32, false);
                Downkeystroke = new Keystroke(Config.down, new Vector2(Config.posX + 32, 0), new Vector2(Config.posY + 160, 0), new Vector2(32, 0), new Vector2(32, 0), 32, 32, false);
                Leftkeystroke = new Keystroke(Config.left, new Vector2(Config.posX, 0), new Vector2(Config.posY + 160, 0), new Vector2(32, 0), new Vector2(32, 0), 32, 32, false);
                Rightkeystroke = new Keystroke(Config.right, new Vector2(Config.posX + 64, 0), new Vector2(Config.posY + 160, 0), new Vector2(32, 0), new Vector2(32, 0), 32, 32, false);
                Spacekeystroke = new Keystroke(Config.jump, new Vector2(Config.posX, 0), new Vector2(Config.posY + 192, 0), new Vector2(96, 0), new Vector2(32, 0), 32, 32, true);
                KeystrokeInit();
            }
        }

       public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
      {
           layers.Add(new LegacyGameInterfaceLayer("Keystrokes", DrawKeystroke, InterfaceScaleType.UI));
        }
        public override void UpdateUI(GameTime gameTime)
        {
            base.UpdateUI(gameTime);
            Upkeystroke.Update(gameTime);
            Downkeystroke.Update(gameTime);
            Leftkeystroke.Update(gameTime);
            Rightkeystroke.Update(gameTime);
            Spacekeystroke.Update(gameTime);
        }
        private bool DrawKeystroke()
        {
            if (!Main.gameMenu
                && Keystroke.visible)
            {
                TopInterface.Draw(Main.spriteBatch, new GameTime());
				BottomInterface.Draw(Main.spriteBatch, new GameTime());
				LeftInterface.Draw(Main.spriteBatch, new GameTime());
				RightInterface.Draw(Main.spriteBatch, new GameTime());
				JumpInterface.Draw(Main.spriteBatch, new GameTime());

			}
            return true;
        }
    }
}