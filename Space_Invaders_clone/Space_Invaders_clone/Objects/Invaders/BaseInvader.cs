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
    public abstract class BaseInvader : GameObject
    {
        //Moving variables
        public static int HowMuchToMove = 10;
        public static int HowMuchDown = 30;
        public static int BulletSpeed = 3;

        private int _points = 100; //Points for killing

        public static SoundEffect ShootSound;
        public static SoundEffect MoveSound;
        public static SoundEffect ExplodeSound;

        public BaseInvader()
            : base()
        {
        }
        public BaseInvader(Vector2 position)
            : base(position)
        {
        }

        public void Move(DirectionMoving direction)
        {
            if (direction == DirectionMoving.Left) StepAngle(Directions.Left, HowMuchToMove);
            else if (direction == DirectionMoving.Right) StepAngle(Directions.Right, HowMuchToMove);
        }
        public void MoveDown()
        {
            StepAngle(Directions.Down, HowMuchDown);
        }
        public void Shoot()
        {
            Vector2 belowInvader = Sprite.Position + new Vector2(53 / 2 - 5, 32);
            CreateMovingObject(typeof(EnemyBullet), belowInvader, Directions.Down, BulletSpeed);

            ShootSound.Play();
        }

        public override void Collision(List<GameObject> collisions)
        {
            foreach (var obj in collisions)
            {
                if (obj.GetType() == typeof(PlayerBullet))
                {
                    DestroyObject(this);
                }
            }
        }
        public override void Destroy(GameObject destroyedObject)
        {
            if (destroyedObject == this)
            {
                ExplodeSound.Play(0.5f, 0.2f, 0.0f);
                SpaceInvaders.RefScore.AddPoints(_points);
            }
        }
    }
}
