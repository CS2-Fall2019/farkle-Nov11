//-----------------------------------------------------------------------
// <copyright file="Dice.cs" company="Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze">
//     Copyright (c) Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace farkle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class representing the Dice.
    /// </summary>
    public class Dice
    {
        /// <summary>
        /// The value of the die.
        /// </summary>
        private int pips = 0;

        /// <summary>
        /// Locked value for first round of rolling.
        /// </summary>
        private bool locked1 = false;

        /// <summary>
        /// Locked value for second round of rolling.
        /// </summary>
        private bool locked2 = false;

        /// <summary>
        /// Locked value for third round of rolling.
        /// </summary>
        private bool locked3 = false;

        /// <summary>
        /// Locked value for fourth round of rolling.
        /// </summary>
        private bool locked4 = false;

        /// <summary>
        /// Locked value for fifth round of rolling.
        /// </summary>
        private bool locked5 = false;

        /// <summary>
        /// Position of die.
        /// </summary>
        private int position = 0;

        /// <summary>
        /// Gets or sets pips.
        /// </summary>
        public int Pips
        {
            get => this.pips;
            set => this.pips = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether locked1 is true or false.
        /// </summary>
        public bool Locked1
        {
            get => this.locked1;
            set => this.locked1 = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether locked2 is true or false.
        /// </summary>
        public bool Locked2
        {
            get => this.locked2;
            set => this.locked2 = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether locked3 is true or false.
        /// </summary>
        public bool Locked3
        {
            get => this.locked3;
            set => this.locked3 = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether locked4 is true or false.
        /// </summary>
        public bool Locked4
        {
            get => this.locked4;
            set => this.locked4 = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether locked5 is true or false.
        /// </summary>
        public bool Locked5
        {
            get => this.locked5;
            set => this.locked5 = value;
        }

        /// <summary>
        /// Gets or sets position.
        /// </summary>
        public int Position
        {
            get => this.position;
            set => this.position = value;
        }

        /// <summary>
        /// Method to reset dice locked fields.
        /// </summary>
        public void ResetLockedDice()
        {
            this.Locked1 = false;
            this.Locked2 = false;
            this.Locked3 = false;
            this.Locked4 = false;
            this.Locked5 = false;
        }
    }
}
