using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using Sandi_s_Way;


namespace Space_Invaders_clone
{
    public static class BlockMaker
    {
        static int _howManyBlocks = 4;
        static int _howFarApart = 60;
        public static readonly Vector2 Position = new Vector2(64, 380);

        private static void MakeOneBlock(Vector2 position)
        {
            int blockSide = new Block().Sprite.Image.Height; //Since a block is square shaped it dosen't matter wich side you take

            TileObjectCreator.Create
                (blockSide, blockSide, position,
                
                new Dictionary<char, Type>() 
                {
                    {'x', typeof(Block)},
                    {'0', null}
                },

                "xxxx",
                "xxxx",
                "x00x");
        }

        public static void MakeANewSetOfBlocks()
        {
            int blockStructureWidth = new Block().Sprite.Image.Height * 4;

            for (int i = 0; i < _howManyBlocks; i++)
            {
                MakeOneBlock(new Vector2(Position.X + blockStructureWidth * i + _howFarApart * i, Position.Y));
            }
        }
    }
}
