using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace Keystrokes.Content
{
	// Sources
	// https://forums.terraria.org/index.php?threads/tutorial-creating-simple-ui-custom-resource-bars.53417/
	// https://forums.terraria.org/index.php?threads/terraria-interface-for-dummies.79356/
	public class Keystroke : UIState
    {
		public static bool visible;
        public static Color border = Config.borderColor;
        public static Color background = Config.backgroundColor;
        public static Color pressedBackground = Config.pressedBackgroundColor;
        public UIText text;
        public Square sq;
        Vector2 left, top, width, height;
        float t_width;
        float t_height;
        bool big;

		Microsoft.Xna.Framework.Input.Keys key;
        /// <summary>
		/// Constructor for Keystroke
		/// .Y of every Vector2 is percentage
		/// </summary>
		/// <param name="left">.X - distance from left side of the screen</param>
		/// <param name="top">.X - distance from top of the screen</param>
		/// <param name="width">.X - width of keystroke</param>
		/// <param name="height">.X - height of keystroke</param>
		public Keystroke(Microsoft.Xna.Framework.Input.Keys k, Vector2 left, Vector2 top, Vector2 width, Vector2 height, float t_width, float t_height, bool big)
		{
			key = k;
			this.left = left;
			this.top = top;
			this.width = width;
			this.height = height;
			this.t_width = t_width;
			this.t_height = t_height;
			this.big = big;
		}

		 public override void OnInitialize()
        {
            visible = true;

            sq = new Square();
            sq.Left.Set(left.X, left.Y);
            sq.Top.Set(top.X, top.Y);
            sq.Width.Set(width.X, width.Y);
            sq.Height.Set(height.X, height.Y);
			Append(sq); 
			text = new UIText(key.ToString());
            if(big)
            {
				text.Left.Set(left.X + 0.25f * (sq.Width.Pixels - text.Width.Pixels), left.Y);
			}
            else
            {
				text.Left.Set(left.X + 0.02f * (sq.Width.Pixels - text.Width.Pixels), left.Y);
			}
			text.Top.Set(top.X +  0.25f * (sq.Height.Pixels + text.Height.Pixels), top.Y);
			text.Width.Set(t_width, 0f);
			text.Height.Set(t_height, 0f);
            Append(text);
		}
		public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            sq.Update(gameTime);
            if (Main.keyState.IsKeyDown(key))
            {
                sq.BackgroundColor = pressedBackground;
            }
            else
            {
                sq.BackgroundColor = background;
                sq.BorderColor = border;
            }
        }
    }
}
