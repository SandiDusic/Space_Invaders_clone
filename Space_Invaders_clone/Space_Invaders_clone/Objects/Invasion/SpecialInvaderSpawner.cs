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
    public class SpecialInvaderSpawner : GameObject
    {
        public SpecialInvaderSpawner()
            : base()
        {
        }
        public SpecialInvaderSpawner(Vector2 position)
            : base(position)
        {
        }

        private int _spawnTimeTop = 60 * 20;
        private int _spawnTimeBottom = 60 * 15;

        public override void Create(GameObject createdObject)
        {
            if (createdObject == this)
            {
                Visable = false;
                Solid = false;
                Alarms.Add("spawn", new Alarm(ObjectManager.Rand.Next(_spawnTimeBottom, _spawnTimeTop)));
            }
        }

        public override void Alarm(string name)
        {
            if (name == "spawn")
            {
                SpecialInvader.MakeIt();
                Alarms["spawn"].Restart(ObjectManager.Rand.Next(_spawnTimeBottom, _spawnTimeTop));
            }
        }
    }
}
