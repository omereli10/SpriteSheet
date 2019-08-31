using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sprite_Sheet_Project
{
    class GameObject : Animation
    {
        #region Data
        public BaseKeyboard baseKeyboard { get; private set; }
        const int user_walk_moving_speed = 5;
        const int user_run_moving_speed = 7;
        const int bot_walk_moving_speed = 2;
        const int bot_distanceX_from_user = 50;
        const int bot_distanceY_from_user = 0;
        const int character_running_animation_speed = 6;
        #endregion Constractors

        #region Constractors
        public GameObject(Character character, State state, Vector2 position, Color color, Vector2 scale, BaseKeyboard baseKeyboard, float rotation = 0f, SpriteEffects effects = SpriteEffects.None, float layerDepth = 0)
                         : base(character, state, position, color, scale, rotation, effects, layerDepth)
        {
            this.baseKeyboard = baseKeyboard;
        }
        #endregion Constractors

        #region Methods
        public void Update()
        {
            // The animation speed is set to default unless other state says so.
            this.animation_speed = this.default_animation_speed;
            if (this.baseKeyboard.IsNone())
            {
                this.state = State.Stand;
            }
            if (this.baseKeyboard.IsWalkRight())
            {
                this.state = State.Walk;
                this.effects = SpriteEffects.None;
                this.position.X += user_walk_moving_speed;
            }
            if (this.baseKeyboard.IsWalkLeft())
            {
                this.state = State.Walk;
                this.effects = SpriteEffects.FlipHorizontally;
                this.position.X -= user_walk_moving_speed;
            }
            if (this.baseKeyboard.IsWalkUp())
            {
                this.state = State.Walk;
                this.position.Y -= user_walk_moving_speed;
            }
            if (this.baseKeyboard.IsWalkDown())
            {
                this.state = State.Walk;
                this.position.Y += user_walk_moving_speed;
            }
            if (this.baseKeyboard.IsRunRight())
            {
                this.state = State.Walk;
                this.effects = SpriteEffects.None;
                this.position.X += user_run_moving_speed;
                this.animation_speed = character_running_animation_speed;
            }
            if (this.baseKeyboard.IsRunLeft())
            {
                this.state = State.Walk;
                this.effects = SpriteEffects.FlipHorizontally;
                this.position.X -= user_run_moving_speed;
                this.animation_speed = character_running_animation_speed;
            }
            if (this.baseKeyboard.IsRunUp())
            {
                this.state = State.Walk;
                this.position.Y -= user_run_moving_speed;
                this.animation_speed = character_running_animation_speed;
            }
            if (this.baseKeyboard.IsRunDown())
            {
                this.state = State.Walk;
                this.position.Y += user_run_moving_speed;
                this.animation_speed = character_running_animation_speed;
            }
            if (this.baseKeyboard.IsPunch())
            {
                this.state = State.Punch;
            }
            if (this.baseKeyboard.IsKick())
            {
                this.state = State.Kick;
            }
            if (this.baseKeyboard.IsPower())
            {
                this.state = State.Power;
            }
            if (this.baseKeyboard.IsPower_Attack())
            {
                this.state = State.Power_Attack;
            }
            if (this.baseKeyboard.IsFade())
            {
                this.state = State.Fade;
            }
            
        }
        public void moveAfterUser(GameObject gameObject)
        {
            // The state of the character is standing by default unless it needs to change.
            this.state = State.Stand;
            if (this.position.X < gameObject.position.X - bot_distanceX_from_user)
            {
                this.state = State.Walk;
                this.effects = SpriteEffects.None;
                if (this.position.X + bot_walk_moving_speed <= gameObject.position.X - bot_distanceY_from_user)
                { this.position.X += bot_walk_moving_speed; }
                else
                { this.position.X += 1; }
                    
            }
            if (this.position.X > gameObject.position.X + bot_distanceX_from_user)
            {
                this.state = State.Walk;
                this.effects = SpriteEffects.FlipHorizontally;
                if (this.position.X - bot_walk_moving_speed >= gameObject.position.X + bot_distanceY_from_user)
                { this.position.X -= bot_walk_moving_speed; }
                else
                { this.position.X -= 1; }
            }
            if (this.position.Y < gameObject.position.Y - bot_distanceY_from_user)
            {
                this.state = State.Walk;
                if (this.position.Y + bot_walk_moving_speed <= gameObject.position.Y - bot_distanceY_from_user)
                { this.position.Y += bot_walk_moving_speed; }
                else
                { this.position.Y += 1; }
                
            }
            if (this.position.Y > gameObject.position.Y + bot_distanceY_from_user)
            {
                this.state = State.Walk;
                if (this.position.Y - bot_walk_moving_speed >= gameObject.position.Y + bot_distanceY_from_user)
                { this.position.Y -= bot_walk_moving_speed; }
                else
                { this.position.Y -= 1; }
            }
        }
        #endregion Methods
    }
}