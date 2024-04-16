using Keystrokes.Content;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameInput;
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

                Upkeystroke = new Keystroke(Microsoft.Xna.Framework.Input.Keys.W, new Vector2(Config.posX + 32, 0), new Vector2(Config.posY + 128, 0), new Vector2(32, 0), new Vector2(32, 0));
                Downkeystroke = new Keystroke(Microsoft.Xna.Framework.Input.Keys.S, new Vector2(Config.posX + 32, 0), new Vector2(Config.posY + 160, 0), new Vector2(32, 0), new Vector2(32, 0));
                Leftkeystroke = new Keystroke(Microsoft.Xna.Framework.Input.Keys.A, new Vector2(Config.posX, 0), new Vector2(Config.posY + 160, 0), new Vector2(32, 0), new Vector2(32, 0));
                Rightkeystroke = new Keystroke(Microsoft.Xna.Framework.Input.Keys.D, new Vector2(Config.posX + 64, 0), new Vector2(Config.posY + 160, 0), new Vector2(32, 0), new Vector2(32, 0));
                Spacekeystroke = new Keystroke(Microsoft.Xna.Framework.Input.Keys.Space, new Vector2(Config.posX, 0), new Vector2(Config.posY + 192, 0), new Vector2(96, 0), new Vector2(32, 0));
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