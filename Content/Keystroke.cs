using Microsoft.Xna.Framework;
using Terraria;
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
        public Square sq;
        Vector2 left, top, width, height;
        Microsoft.Xna.Framework.Input.Keys key;
        /// <summary>
        /// Constructor for Keystroke
        /// .Y of every Vector2 is percentage
        /// </summary>
        /// <param name="left">.X - distance from left side of the screen</param>
        /// <param name="top">.X - distance from top of the screen</param>
        /// <param name="width">.X - width of keystroke</param>
        /// <param name="height">.X - height of keystroke</param>
        public Keystroke(Microsoft.Xna.Framework.Input.Keys k, Vector2 left, Vector2 top, Vector2 width, Vector2 height)
        {
            this.key = k;
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
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
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            sq.Update(gameTime);
            if (Main.keyState.IsKeyDown(this.key))
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
