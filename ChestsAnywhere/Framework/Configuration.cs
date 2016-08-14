﻿using System;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI;

namespace ChestsAnywhere.Framework
{
    /// <summary>The mod configuration.</summary>
    internal class Configuration : Config
    {
        /*********
        ** Accessors
        *********/
        /// <summary>The keyboard input map.</summary>
        public InputMapConfiguration<string> Keyboard { get; set; }

        /// <summary>The controller input map.</summary>
        public InputMapConfiguration<string> Controller { get; set; }


        /*********
        ** Public methods
        *********/
        /// <summary>Construct a default instance.</summary>
        public Configuration()
        {
            this.Keyboard = new InputMapConfiguration<string>
            {
                Toggle = Keys.B.ToString(),
                PrevChest = Keys.Left.ToString(),
                NextChest = Keys.Right.ToString()
            };
            this.Controller = new InputMapConfiguration<string>
            {
                Toggle = "",
                PrevChest = "",
                NextChest = ""
            };
        }

        /// <summary>Get the keyboard mapping.</summary>
        public InputMapConfiguration<Keys> GetKeyboard()
        {
            Keys parsed;
            return new InputMapConfiguration<Keys>
            {
                Toggle = Enum.TryParse(this.Keyboard.Toggle, out parsed) ? parsed : Keys.B,
                PrevChest = Enum.TryParse(this.Keyboard.PrevChest, out parsed) ? parsed : Keys.Left,
                NextChest = Enum.TryParse(this.Keyboard.NextChest, out parsed) ? parsed : Keys.Right
            };
        }

        /// <summary>Get the controller mapping.</summary>
        public InputMapConfiguration<Buttons?> GetController()
        {
            Buttons parsed;
            return new InputMapConfiguration<Buttons?>
            {
                Toggle = Enum.TryParse(this.Controller.Toggle, out parsed) ? parsed : null as Buttons?,
                PrevChest = Enum.TryParse(this.Controller.PrevChest, out parsed) ? parsed : null as Buttons?,
                NextChest = Enum.TryParse(this.Controller.NextChest, out parsed) ? parsed : null as Buttons?
            };
        }
    }
}