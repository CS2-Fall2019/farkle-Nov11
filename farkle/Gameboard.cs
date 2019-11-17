//-----------------------------------------------------------------------
// <copyright file="Gameboard.cs" company="Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze">
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
    /// Class representing the Gameboard.
    /// </summary>
    public class Gameboard
    {
        /// <summary>
        /// Field for the scoreboard. This may not be used.
        /// </summary>
        private int scoreBoard;

        /// <summary>
        /// Field for the round of the game.
        /// </summary>
        private int round;

        /// <summary>
        /// Gets or sets the scoreboard. This may be deleted.
        /// </summary>
        public int ScoreBoard
        {
            get { return this.scoreBoard; }
            set { this.scoreBoard = value; }
        }

        /// <summary>
        /// Gets or sets the round.
        /// </summary>
        public int Round
        {
            get { return this.round; }
            set { this.round = value; }
        }
    }
}