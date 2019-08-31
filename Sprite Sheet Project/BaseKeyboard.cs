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
    abstract class BaseKeyboard
    {
        #region KeyboardOperations
        public abstract bool IsNone();
        public abstract bool IsWalkRight();
        public abstract bool IsWalkLeft();
        public abstract bool IsWalkUp();
        public abstract bool IsWalkDown();
        public abstract bool IsRunRight();
        public abstract bool IsRunLeft();
        public abstract bool IsRunUp();
        public abstract bool IsRunDown();
        public abstract bool IsPunch();
        public abstract bool IsKick();
        public abstract bool IsPower();
        public abstract bool IsPower_Attack();
        public abstract bool IsFade();
        #endregion KeyboardOperations
    }

    class UserKeyboard : BaseKeyboard
    {
        #region Keys
        public Keys Right { get; private set; }
        public Keys Left { get; private set; }
        public Keys Up { get; private set; }
        public Keys Down { get; private set; }
        public Keys Shift { get; private set; }
        public Keys Punch { get; private set; }
        public Keys Kick { get; private set; }
        public Keys Power { get; private set; }
        public Keys Power_Attack { get; private set; }
        public Keys Fade { get; private set; }
        #endregion Keys

        #region Constractors
        public UserKeyboard(Keys right, Keys left, Keys up, Keys down, Keys run_shift, Keys punch, Keys kick, Keys power, Keys power_attack, Keys fade)
        {
            this.Right = right;
            this.Left = left;
            this.Up = up;
            this.Down = down;
            this.Shift = run_shift;
            this.Punch = punch;
            this.Kick = kick;
            this.Power = power;
            this.Power_Attack = power_attack;
            this.Fade = fade;
        }
        #endregion Constractors

        #region KeysStates
        public override bool IsNone()
        {
            return !IsWalkRight() && !IsWalkLeft() && !IsWalkUp() && !IsWalkDown() && !IsRunRight() && !IsRunLeft() && !IsRunUp() && !IsRunDown() && !IsPunch() && !IsKick() && !IsPower() && !IsFade();
        }
        public override bool IsWalkRight()
        {
            return Globals.keyboard.IsKeyDown(Right) && !(Globals.keyboard.IsKeyDown(Shift));
        }
        public override bool IsWalkLeft()
        {
            return Globals.keyboard.IsKeyDown(Left) && !(Globals.keyboard.IsKeyDown(Shift));
        }
        public override bool IsWalkUp()
        {
            return Globals.keyboard.IsKeyDown(Up) && !(Globals.keyboard.IsKeyDown(Shift));
        }
        public override bool IsWalkDown()
        {
            return Globals.keyboard.IsKeyDown(Down) && !(Globals.keyboard.IsKeyDown(Shift));
        }
        public override bool IsRunRight()
        {
            return Globals.keyboard.IsKeyDown(Right) && Globals.keyboard.IsKeyDown(Shift);
        }
        public override bool IsRunLeft()
        {
            return Globals.keyboard.IsKeyDown(Left) && Globals.keyboard.IsKeyDown(Shift);
        }
        public override bool IsRunUp()
        {
            return Globals.keyboard.IsKeyDown(Up) && Globals.keyboard.IsKeyDown(Shift);
        }
        public override bool IsRunDown()
        {
            return Globals.keyboard.IsKeyDown(Down) && Globals.keyboard.IsKeyDown(Shift);
        }
        public override bool IsPunch()
        {
            return Globals.keyboard.IsKeyDown(Punch);
        }
        public override bool IsKick()
        {
            return Globals.keyboard.IsKeyDown(Kick);
        }
        public override bool IsPower()
        {
            return Globals.keyboard.IsKeyDown(Power);
        }
        public override bool IsPower_Attack()
        {
            return Globals.keyboard.IsKeyDown(Power_Attack);
        }
        public override bool IsFade()
        {
            return Globals.keyboard.IsKeyDown(Fade);
        }
        #endregion KeysStates
    }

    class BotKeyboard : BaseKeyboard
    {
        #region BotState
        public bool WalkRight { get; private set; }
        public bool WalkLeft { get; private set; }
        public bool WalkUp { get; private set; }
        public bool WalkDown { get; private set; }
        public bool RunRight { get; private set; }
        public bool RunLeft { get; private set; }
        public bool RunUp { get; private set; }
        public bool RunDown { get; private set; }
        public bool Punch { get; private set; }
        public bool Kick { get; private set; }
        public bool Power { get; private set; }
        public bool Power_Attack { get; private set; }
        public bool Fade { get; private set; }
        #endregion BotState

        #region Constractors
        public BotKeyboard()
        {
            this.WalkRight = false;
            this.WalkLeft = false;
            this.WalkUp = false;
            this.WalkDown = false;
            this.RunRight = false;
            this.RunLeft = false;
            this.RunUp = false;
            this.RunDown = false;
            this.Punch = false;
            this.Kick = false;
            this.Power = false;
            this.Power_Attack = false;
            this.Fade = false;
        }
        public BotKeyboard(bool walkRight, bool walkLeft, bool walkUp, bool walkDown, bool runRight, bool runLeft, bool runUp, bool runDown, bool punch, bool kick, bool power, bool power_attack, bool fade)
        {
            this.WalkRight = walkRight;
            this.WalkLeft = walkLeft;
            this.WalkUp = walkUp;
            this.WalkDown = walkDown;
            this.RunRight = runRight;
            this.RunLeft = runLeft;
            this.RunUp = runUp;
            this.RunDown = runDown;
            this.Punch = punch;
            this.Kick = Kick;
            this.Power = power;
            this.Power_Attack = power_attack;
            this.Fade = fade;
        }
        #endregion Constractors

        #region KeysStates
        public override bool IsNone()
        {
            return !WalkRight && !WalkLeft && !WalkUp && !WalkDown && !RunRight && !RunLeft && !RunUp && !RunDown && !Punch && !Kick && !Power;
        }
        public override bool IsWalkRight()
        {
            return this.WalkRight;
        }
        public override bool IsWalkLeft()
        {
            return this.WalkLeft;
        }
        public override bool IsWalkUp()
        {
            return this.WalkUp;
        }
        public override bool IsWalkDown()
        {
            return this.WalkDown;
        }
        public override bool IsRunRight()
        {
            return this.RunRight;
        }
        public override bool IsRunLeft()
        {
            return this.RunLeft;
        }
        public override bool IsRunUp()
        {
            return this.RunUp;
        }
        public override bool IsRunDown()
        {
            return this.RunDown;
        }
        public override bool IsPunch()
        {
            return this.Punch;
        }
        public override bool IsKick()
        {
            return this.Kick;
        }
        public override bool IsPower()
        {
            return this.Power;
        }
        public override bool IsPower_Attack()
        {
            return this.Power_Attack;
        }
        public override bool IsFade()
        {
            return this.Fade;
        }
        #endregion KeysStates
    }
}