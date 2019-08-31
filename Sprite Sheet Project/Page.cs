using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet_Project
{
    class Page
    {
        #region Data
        public Texture2D Tex { get; set; }
        public List<Rectangle> recs = new List<Rectangle>();
        public List<Vector2> origins = new List<Vector2>();
        #endregion Data
        public Page(Character character, State state)
        {
            Tex = Globals.cm.Load<Texture2D>(character.ToString() + "/" + state.ToString());
            Color[] c = new Color[Tex.Width];
            Tex.GetData<Color>(0, new Rectangle(0,Tex.Height-1,Tex.Width, 1), c, 0, Tex.Width);
            List<int> blackip = new List<int>();

            #region Black Dots
            //Taking all black dots positions
            for (int i = 0; i < Tex.Width; i++)
            {
                if (c[i] == c[0])
                { blackip.Add(i); }
            } 
            #endregion Black Dots

            #region Origins
            //Taking all origins positions
            for (int i = 1; i < blackip.Count; i++)
            {
                if (i % 2 == 0)
                {
                    int xOrg = blackip[i] - blackip[i - 1];
                    int yOrg = Tex.Height - 1;
                    origins.Add(new Vector2(xOrg, yOrg));
                }
            }
            #endregion Origins

            #region Rectangles
            //Gettting rectangles
            for (int i = 1; i < blackip.Count; i += 2)
            {
                recs.Add(new Rectangle(blackip[i-1], 0, blackip[i + 1] - blackip[i - 1], Tex.Height - 2));
            }
            #endregion Rectangles

            #region Clear Background
            // Clearing the background of the images
            c = new Color[Tex.Width * Tex.Height];
            Tex.GetData<Color>(c);
            Color backColor = c[0];
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == backColor)
                { c[i] = Color.Transparent; }
            }
            Tex.SetData<Color>(c);
            #endregion Clear Background
        }
    }
}