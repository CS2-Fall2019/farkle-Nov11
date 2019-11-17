//-----------------------------------------------------------------------
// <copyright file="Player.cs" company="Ian Burroughs, Mike Boudreau, Brandon Biles & James A. Schulze">
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
    using System.Windows;

    /// <summary>
    /// Class representing a player.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The players score.
        /// </summary>
        private int score;

        /// <summary>
        /// The current players pending score for the round.
        /// </summary>
        private int pendingScore;

        /// <summary>
        /// Players temporary current score for this round. Can be added to w/ hot dice or lost if farkled.
        /// </summary>
        private int tempScore = 0;

        /// <summary>
        /// The current score for the player.
        /// </summary>
        private int currentScore;

        /// <summary>
        /// The this.numbered value of the die between 1 and 6.
        /// </summary>
        private int[] dieKept = new int[6];

        /// <summary>
        /// Bool value to hold true if all the dice kept are scorable.
        /// </summary>
        private bool validDice = false;

        /// <summary>
        /// Bool value to hold true if all 6 dice are kept, scorable, and ready for re-roll.
        /// </summary>
        private bool hotDice;

        /// <summary>
        /// Bool value to hold true if hotDice was previously true on the last roll.
        /// </summary>
        private bool wasHotDice;

        /// <summary>
        /// Integer value to increment every time the player gets hot dice. Resets on new turn.
        /// </summary>
        private int round;

        /// <summary>
        /// Integer value to increment every time the player gets hot dice. Resets on new turn.
        /// </summary>
        private int oldTemp;

        /// <summary>
        /// Field to keep track of the this.tempScore if hotDice happens.
        /// </summary>
        private int hotDiceAccumulator;

        /// <summary>
        /// Field to keep track of the this.tempScore of locked1List.
        /// </summary>
        private int locked1ListScore;

        /// <summary>
        /// Field to keep track of the this.tempScore of locked2List.
        /// </summary>
        private int locked2ListScore;

        /// <summary>
        /// Field to keep track of the this.tempScore of locked3List.
        /// </summary>
        private int locked3ListScore;

        /// <summary>
        /// Field to keep track of the this.tempScore of locked4List.
        /// </summary>
        private int locked4ListScore;

        /// <summary>
        /// Field to keep track of the this.tempScore of locked5List.
        /// </summary>
        private int locked5ListScore;

        /// <summary>
        /// Field to keep track of the this.tempScore if hotDice happens.
        /// </summary>
        private int number;

        /// <summary>
        /// Field to keep track of the tempScore if hotDice happens.
        /// </summary>
        private bool isAI;

        /// <summary>
        /// Field to keep track of the tempScore if hotDice happens.
        /// </summary>
        public bool IsAI
        {
            get => isAI;
            set => isAI = value;
        }

        /// <summary>
        /// Gets or sets validDice.
        /// </summary>
        public int Number
        {
            get => this.number;
            set => this.number = value;
        }

        /// <summary>
        /// Gets or sets validDice.
        /// </summary>
        public int OldTemp
        {
            get => this.oldTemp;
            set => this.oldTemp = value;
        }

        /// <summary>
        /// Gets or sets dice value.
        /// </summary>
        public int[] DieKept
        {
            get { return this.dieKept; }
            set { this.dieKept = value; }
        }

        /// <summary>
        /// Gets or sets Score.
        /// </summary>
        public int Score
        {
            get { return this.score; }
            set { this.score = value; }
        }

        /// <summary>
        /// Gets or sets Pending Score. for specific roll
        /// </summary>
        public int PendingScore
        {
            get { return this.pendingScore; }
            set { this.pendingScore = value; }
        }

        /// <summary>
        /// Gets or sets the current score.
        /// </summary>
        public int CurrentScore
        {
            get => this.currentScore;
            set => this.currentScore = value;
        }

        /// <summary>
        /// Gets or sets this.tempScore. 
        /// </summary>
        public int TempScore
        {
            get => this.tempScore;
            set => this.tempScore = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether validDice is true or false.
        /// </summary>
        public bool ValidDice
        {
            get => this.validDice;
            set => this.validDice = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether hotDice is true or false.
        /// </summary>
        public bool HotDice
        {
            get => this.hotDice;
            set => this.hotDice = value;
        }

        /// <summary>
        /// Gets or sets round.
        /// </summary>
        public int Round
        {
            get => this.round;
            set => this.round = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether wasHotDice is true or false.
        /// </summary>
        public bool WasHotDice
        {
            get => this.wasHotDice;
            set => this.wasHotDice = value;
        }

        /// <summary>
        /// Gets or sets hotDiceAccumulator.
        /// </summary>
        public int HotDiceAccumulator
        {
            get => this.hotDiceAccumulator;
            set => this.hotDiceAccumulator = value;
        }

        /// <summary>
        /// Gets or sets locked1ListScore.
        /// </summary>
        public int Locked1ListScore
        {
            get => this.locked1ListScore;
            set => this.locked1ListScore = value;
        }

        /// <summary>
        /// Gets or sets locked2ListScore.
        /// </summary>
        public int Locked2ListScore
        {
            get => this.locked2ListScore;
            set => this.locked2ListScore = value;
        }

        /// <summary>
        /// Gets or sets locked3ListScore.
        /// </summary>
        public int Locked3ListScore
        {
            get => this.locked3ListScore;
            set => this.locked3ListScore = value;
        }

        /// <summary>
        /// Gets or sets locked4ListScore.
        /// </summary>
        public int Locked4ListScore
        {
            get => this.locked4ListScore;
            set => this.locked4ListScore = value;
        }

        /// <summary>
        /// Gets or sets locked5ListScore.
        /// </summary>
        public int Locked5ListScore
        {
            get => this.locked5ListScore;
            set => this.locked5ListScore = value;
        }

        /// <summary>
        /// Method to score the dice.
        /// </summary>
        /// <param name="savedDieList">The saved die list.</param>
        /// <param name="locked1List">The first locked list.</param>
        /// <param name="locked2List">The second locked list.</param>
        /// <param name="locked3List">The third locked list.</param>
        /// <param name="locked4List">The fourth locked list.</param>
        /// <param name="locked5List">The fifth locked list.</param>
        public void ScoreDice(
            List<Dice> savedDieList, List<Dice> locked1List, List<Dice> locked2List, List<Dice> locked3List, List<Dice> locked4List, List<Dice> locked5List)
        {
            // Variable for total score from the dice roll.
            // int totalScore = 0;
            // Scoring 
            // Set bool valid dice and bool hot dice to false.
            this.validDice = false;
            this.hotDice = false;

            // Set up variables to hold the scores for a single 1 or single 5 rolled.
            // int die1 = 100;
            // int die5 = 50;
            // Create variables to keep count of each die.
            int oneCounter = 0;
            int twoCounter = 0;
            int threeCounter = 0;
            int fourCounter = 0;
            int fiveCounter = 0;
            int sixCounter = 0;

            // Set up a bool value to hold true if all 6 dice are kept.
            // bool hotDice = false;
            // we are using a field of player to do this
            // Set up a boolean value to hold true if there is a straight.
            bool straight = false;

            // Set up bool values to hold true if counters are pairs.
            bool pairOnes = false;
            bool pairTwos = false;
            bool pairThrees = false;
            bool pairFours = false;
            bool pairFives = false;
            bool pairSixes = false;

            // Set up a bool value to hold true if there are three pairs.
            bool threePairs = false;

            // Set up bool values to hold true if counters are 3.
            bool threeOnes = false;
            bool threeTwos = false;
            bool threeThrees = false;
            bool threeFours = false;
            bool threeFives = false;
            bool threeSixes = false;

            // Set up a bool value to hold true if there are two three of a kinds.
            bool threeOfAKinds = false;

            // Set up a bool value to hold true if there are dice that can be scored.
            bool keptDiceScorable = false;

            // Loop through the diceKept list and increment the counters of each die rolled.
            foreach (Dice die in savedDieList)
            {
                // if (die.isLocked == false)
                if (!die.Locked1 && !die.Locked2 && !die.Locked3 && !die.Locked4 && !die.Locked5)
                {
                    // If the current die is a 1.
                    if (die.Pips == 1)
                    {
                        // Increment the one counter.
                        oneCounter++;
                    }
                    else if (die.Pips == 2)
                    {
                        // Increment the two counter
                        twoCounter++;
                    }
                    else if (die.Pips == 3)
                    {
                        // Increment the three counter.
                        threeCounter++;
                    }
                    else if (die.Pips == 4)
                    {
                        // Increment the four counter.
                        fourCounter++;
                    }
                    else if (die.Pips == 5)
                    {
                        // Increment the five counter.
                        fiveCounter++;
                    }
                    else
                    {
                        // Increment the six counter.
                        sixCounter++;
                    }
                }
            }

            // todo right here check if there are scorable dice by comparing the one/fiveCounters and 
            // the other counters compared to the total counter?

            // If there are ones to be scored.
            if (oneCounter > 0)
            {
                // If there are less than 3 ones rolled.
                if (oneCounter < 3)
                {
                    // Add 100 for each one rolled.
                    this.pendingScore += oneCounter * 100;
                }
                else
                {
                    // If there are 3 or more ones rolled.
                    if (oneCounter == 3)
                    {
                        // If oneCounter is 3 add 1000.
                        this.pendingScore += 1000;

                        // Set threeOnes to true;
                        threeOnes = true;
                    }
                    else if (oneCounter == 4)
                    {
                        // If oneCounter is 4 add 2000.
                        this.pendingScore += 2000;
                    }
                    else if (oneCounter == 5)
                    {
                        // If oneCounter is 5 add 4000.
                        this.pendingScore += 4000;
                    }
                    else
                    {
                        // If oneCounter is 6 add 8000.
                        this.pendingScore += 8000;
                    }
                }
            }
            else
            {
                // Pending score remains the same.
            }

            // If there are twos to be scored.
            if (twoCounter >= 3)
            {
                // If there are 3 or more twos rolled.
                if (twoCounter == 3)
                {
                    // If twoCounter is 3 add 200.
                    this.pendingScore += 200;

                    // Set threeTwos to true;
                    threeTwos = true;
                }
                else if (twoCounter == 4)
                {
                    // If twoCounter is 4 add 400.
                    this.pendingScore += 400;
                }
                else if (twoCounter == 5)
                {
                    // If twoCounter is 5 add 800.
                    this.pendingScore += 800;
                }
                else
                {
                    // If twoCounter is 6 add 1600.
                    this.pendingScore += 1600;
                }
            }
            else
            {
                // Pending score remains the same.
            }

            // If there are threes to be scored.
            if (threeCounter >= 3)
            {
                // If there are 3 or more threes rolled.
                if (threeCounter == 3)
                {
                    // If threeCounter is 3 add 300.
                    this.pendingScore += 300;

                    // Set threeThrees to true;
                    threeThrees = true;
                }
                else if (threeCounter == 4)
                {
                    // If threeCounter is 4 add 600.
                    this.pendingScore += 600;
                }
                else if (threeCounter == 5)
                {
                    // If threeCounter is 5 add 1200.
                    this.pendingScore += 1200;
                }
                else
                {
                    // If threeCounter is 6 add 2400.
                    this.pendingScore += 2400;
                }
            }
            else
            {
                // Pending score remains the same.
            }

            // If there are fours to be scored.
            if (fourCounter >= 3)
            {
                // If there are 3 or more fours rolled.
                if (fourCounter == 3)
                {
                    // If fourCounter is 3 add 400.
                    this.pendingScore += 400;

                    // Set threeFours to true;
                    threeFours = true;
                }
                else if (fourCounter == 4)
                {
                    // If fourCounter is 4 add 800.
                    this.pendingScore += 800;
                }
                else if (fourCounter == 5)
                {
                    // If fourCounter is 5 add 1600.
                    this.pendingScore += 1600;
                }
                else
                {
                    // If fourCounter is 6 add 3200.
                    this.pendingScore += 3200;
                }
            }
            else
            {
                // Pending score remains the same.
            }

            // If there are fives to be scored.
            if (fiveCounter > 0)
            {
                // If there are less than 3 fives rolled.
                if (fiveCounter < 3)
                {
                    // Add 50 for each 5 rolled.
                    this.pendingScore += fiveCounter * 50;

                    // WARNING-------------------------------------------WARNING----------------------------------------------WARNING-------------------------------
                    // Problem were pending score gets added to itself several times over if an unscoreable die 
                    // is entered before a scoreable die and then removed after the scorable die.
                    // Delete comment after problem is sovled.
                    // if (!threeOnes && !threeTwos && !threeThrees && !threeFours && !threeFives && !threeSixes && savedDieList[0].pips != 1 && savedDieList[0].pips != 5)
                    // {
                    //     this.pendingScore = 0;
                    // }
                    // !keptDiceScorable && savedDieList[0].pips == 1 && savedDieList[0].pips == 5
                    // Current if statement not working correctly.
                    // If worst comes to worst try and move the all 5 dice value abouve dice 2,3,4, and 6 but below 1.
                    // if (!threeOnes && !threeTwos && !threeThrees && !threeFours && !threeFives && !threeSixes && savedDieList[0].Pips != 1 && savedDieList[0].Pips != 5)
                    // {
                    //    this.pendingScore = 0;
                    // }
                    // this.pendingScore += fiveCounter * 50;
                }
                else
                {
                    // If there are 3 or more fives rolled.
                    if (fiveCounter == 3)
                    {
                        // If fiveCounter is 3 add 500.
                        this.pendingScore += 500;

                        // Set threeFives to true;
                        threeFives = true;
                    }
                    else if (fiveCounter == 4)
                    {
                        // If fiveCounter is 4 add 1000.
                        this.pendingScore += 1000;
                    }
                    else if (fiveCounter == 5)
                    {
                        // If fiveCounter is 5 add 2000.
                        this.pendingScore += 2000;
                    }
                    else
                    {
                        // If fiveCounter is 6 add 4000.
                        this.pendingScore += 4000;
                    }
                }
            }
            else
            {
                // Pending score remains the same.
            }

            // If there are sixes to be scored.
            if (sixCounter >= 3)
            {
                // If there are 3 or more sixes rolled.
                if (sixCounter == 3)
                {
                    // If sixCounter is 3 add 600.
                    this.pendingScore += 600;

                    // Set threeSixes to true;
                    threeSixes = true;
                }
                else if (sixCounter == 4)
                {
                    // If sixCounter is 4 add 1200.
                    this.pendingScore += 1200;
                }
                else if (sixCounter == 5)
                {
                    // If sixCounter is 5 add 2400.
                    this.pendingScore += 2400;
                }
                else
                {
                    // If sixCounter is 6 add 4800.
                    this.pendingScore += 4800;
                }
            }
            else
            {
                // Pending score remains the same.
            }

            // Check to see if the player rolled a straight or three pairs.
            if (savedDieList.Count == 6)
            {
                // Set hotDice to true.
                this.HotDice = true;

                // Check for pairs.
                // If theres a pair of ones.
                if (oneCounter == 2)
                {
                    // Set pairOnes as true.
                    pairOnes = true;
                }

                // If theres a pair of twos.
                if (twoCounter == 2)
                {
                    // Set pairTwos as true.
                    pairTwos = true;
                }

                // If theres a pair of threes.
                if (threeCounter == 2)
                {
                    // Set pairThrees as true.
                    pairThrees = true;
                }

                // If theres a pair of fours.
                if (fourCounter == 2)
                {
                    // Set pairFours as true.
                    pairFours = true;
                }

                // If theres a pair of fives.
                if (fiveCounter == 2)
                {
                    // Set pairFives as true.
                    pairFives = true;
                }

                // If theres a pair of sixes.
                if (sixCounter == 2)
                {
                    // Set pairSixes as true.
                    pairSixes = true;
                }

                // Check for a straight.
                if (oneCounter == 1 && twoCounter == 1 && threeCounter == 1 &&
                    fourCounter == 1 && fiveCounter == 1 && sixCounter == 1)
                {
                    // Set bool straight to true.
                    straight = true;

                    // Add 3000 to the pending score for a straight.
                    this.pendingScore = 3000;
                }
                else
                {
                    // Check for three pairs.
                    // If theres a pair of ones.
                    if (pairOnes)
                    {
                        // Check if theres another pair.
                        if (pairTwos)
                        {
                            // Check if theres a third pair.
                            if (pairThrees)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFours)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairThrees)
                        {
                            // Check if theres a third pair.
                            if (pairFours)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFours)
                        {
                            // Check if theres a third pair.
                            if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else if (pairTwos)
                    {
                        // Check if theres another pair.
                        if (pairThrees)
                        {
                            // Check if theres a third pair.
                            if (pairFours)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFours)
                        {
                            // Check if theres a third pair.
                            if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else if (pairThrees)
                    {
                        // Check if theres another pair.
                        if (pairFours)
                        {
                            // Check if theres a third pair.
                            if (pairFives)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else if (pairFours)
                    {
                        // Check if theres another pair.
                        if (pairFives)
                        {
                            // Check if theres a third pair.
                            if (pairSixes)
                            {
                                // Set threePairs to true.
                                threePairs = true;
                            }
                            else
                            {
                                // There are not three pairs.
                            }
                        }
                        else
                        {
                            // There are not three pairs.
                        }
                    }
                    else
                    {
                        // There are not three pairs.
                    }

                    // If there are three pairs.
                    if (threePairs)
                    {
                        // Add 1500 to the pending score for three pairs.
                        this.pendingScore = 1500;
                    }
                    else
                    {
                        // Pending score stays as pending score.
                    }
                }

                if (!threePairs)
                {
                    // Check for 2 3-of-a-kinds.
                    if (threeOnes)
                    {
                        if (threeTwos)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeThrees)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeFours)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeFives)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeSixes)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else
                        {
                            // Theres not 2 3-of-a-kinds.
                        }
                    }
                    else if (threeTwos)
                    {
                        if (threeThrees)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeFours)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeFives)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeSixes)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else
                        {
                            // Theres not 2 3-of-a-kinds.
                        }
                    }
                    else if (threeThrees)
                    {
                        if (threeFours)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeFives)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeSixes)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else
                        {
                            // Theres not 2 3-of-a-kinds.
                        }
                    }
                    else if (threeFours)
                    {
                        if (threeFives)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else if (threeSixes)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else
                        {
                            // Theres not 2 3-of-a-kinds.
                        }
                    }
                    else if (threeFives)
                    {
                        if (threeSixes)
                        {
                            // There is 2 3-of-a-kinds.
                            // Set threeOfAKinds to true.
                            threeOfAKinds = true;
                        }
                        else
                        {
                            // Theres not 2 3-of-a-kinds.
                        }
                    }
                    else
                    {
                        // There is not 2 3-of-a-kinds.
                    }
                }
                else
                {
                    // There is not three pairs and not 2 3-of-a-kinds
                }
            }

            // Variable to hold the count of the savedDieList without the locked dice.
            int tempSavedDieListCount = 0;

            foreach (Dice die in savedDieList)
            {
                // Loop through the savedDieList.
                // if (!die.isLocked)
                if (!die.Locked1 && !die.Locked2 && !die.Locked3 && !die.Locked4 && !die.Locked5)
                {
                    // Add 1 to the counter for each die that isnt locked.
                    tempSavedDieListCount++;
                }
            }

            // Check to make sure the dice kept are scorable.
            if (twoCounter >= 3 && twoCounter + oneCounter + fiveCounter == savedDieList.Count || twoCounter >= 3 && twoCounter + oneCounter + fiveCounter == tempSavedDieListCount)
            {
                // Set scorable dice to true.
                keptDiceScorable = true;
            }
            else if (threeCounter >= 3 && threeCounter + oneCounter + fiveCounter == savedDieList.Count || threeCounter >= 3 && threeCounter + oneCounter + fiveCounter == tempSavedDieListCount)
            {
                // Set scorable dice to true.
                keptDiceScorable = true;
            }
            else if (fourCounter >= 3 && fourCounter + oneCounter + fiveCounter == savedDieList.Count || fourCounter >= 3 && fourCounter + oneCounter + fiveCounter == tempSavedDieListCount)
            {
                // Set scorable dice to true.
                keptDiceScorable = true;
            }
            else if (sixCounter >= 3 && sixCounter + oneCounter + fiveCounter == savedDieList.Count || sixCounter >= 3 && sixCounter + oneCounter + fiveCounter == tempSavedDieListCount)
            {
                // Set scorable dice to true.
                keptDiceScorable = true;
            }
            else
            {
                // Some of the dice are not scorable.
                keptDiceScorable = false;
            }

            if (straight || threePairs || threeOfAKinds || keptDiceScorable || (oneCounter + fiveCounter == tempSavedDieListCount))
            {
                if (savedDieList.Count == 6)
                {
                    // Set hot dice to true.
                    this.HotDice = true;
                }

                // Dice are valid.
                // Set validDice to true.
                this.validDice = true;

                if (!this.wasHotDice)
                {
                    // Check if locked1List has anything in it.
                    if (locked1List.Count > 0)
                    {
                        // Check if locked2List has anything in it.
                        if (locked2List.Count > 0)
                        {
                            // Check if locked3List has anything in it.
                            if (locked3List.Count > 0)
                            {
                                // Check if locked4List has anything in it.
                                if (locked4List.Count > 0)
                                {
                                    // Check if locked5List has anything in it.
                                    if (locked5List.Count > 0)
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.locked1ListScore + this.locked2ListScore + this.locked3ListScore
                                                    + this.locked4ListScore + this.locked5ListScore + this.pendingScore;
                                    }
                                    else
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.locked1ListScore + this.locked2ListScore + this.locked3ListScore
                                                    + this.locked4ListScore + this.pendingScore;

                                        // Set locked5List score as the current pending score.
                                        this.locked5ListScore = this.pendingScore;
                                    }
                                }
                                else
                                {
                                    // Set this.tempScore as the current pending score.
                                    this.tempScore = this.locked1ListScore + this.locked2ListScore + this.locked3ListScore + this.pendingScore;

                                    // Set locked4List score as the current pending score.
                                    this.locked4ListScore = this.pendingScore;
                                }
                            }
                            else
                            {
                                // Set this.tempScore as the current pending score.
                                this.tempScore = this.locked1ListScore + this.locked2ListScore + this.pendingScore;

                                // Set locked3List score as the current pending score.
                                this.locked3ListScore = this.pendingScore;
                            }
                        }
                        else
                        {
                            // Set this.tempScore as the current pending score.
                            this.tempScore = this.locked1ListScore + this.pendingScore;

                            // Set locked2List score as the current pending score.
                            this.locked2ListScore = this.pendingScore;
                        }
                    }
                    else
                    {
                        // Set this.tempScore as the current pending score.
                        this.tempScore = this.pendingScore;

                        // Set locked1List score as the current pending score.
                        this.locked1ListScore = this.pendingScore;
                    }
                }
                else
                {
                    // Hot dice scoring.
                    // Check if locked1List has anything in it.
                    if (locked1List.Count > 0)
                    {
                        // Check if locked2List has anything in it.
                        if (locked2List.Count > 0)
                        {
                            // Check if locked3List has anything in it.
                            if (locked3List.Count > 0)
                            {
                                // Check if locked4List has anything in it.
                                if (locked4List.Count > 0)
                                {
                                    // Check if locked5List has anything in it.
                                    if (locked5List.Count > 0)
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                                    + this.locked3ListScore + this.locked4ListScore + this.locked5ListScore
                                                    + this.pendingScore;
                                    }
                                    else
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                                    + this.locked3ListScore + this.locked4ListScore + this.pendingScore;

                                        // Set locked5List score as the current pending score.
                                        this.locked5ListScore = this.pendingScore;
                                    }
                                }
                                else
                                {
                                    // Set this.tempScore as the current pending score.
                                    this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                                + this.locked3ListScore + this.pendingScore;

                                    // Set locked4List score as the current pending score.
                                    this.locked4ListScore = this.pendingScore;
                                }
                            }
                            else
                            {
                                // Set this.tempScore as the current pending score.
                                this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                            + this.pendingScore;

                                // Set locked3List score as the current pending score.
                                this.locked3ListScore = this.pendingScore;
                            }
                        }
                        else
                        {
                            // Set this.tempScore as the current pending score.
                            this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.pendingScore;

                            // Set locked2List score as the current pending score.
                            this.locked2ListScore = this.pendingScore;
                        }
                    }
                    else
                    {
                        // Set this.tempScore as the current pending score.
                        this.tempScore = this.hotDiceAccumulator + this.pendingScore;

                        // Set locked1List score as the current pending score.
                        this.locked1ListScore = this.pendingScore;
                    }
                }

                // Reset pending score to 0.
                this.pendingScore = 0;
            }
            else
            {
                // Dice are not valid.
                // MessageBox.Show("Some of the dice you kept are not scorable.");
                this.validDice = false;

                // Set tempScore as pending score based on rolls.
                if (!this.wasHotDice)
                {
                    // Check if locked1List has anything in it.
                    if (locked1List.Count > 0)
                    {
                        // Check if locked2List has anything in it.
                        if (locked2List.Count > 0)
                        {
                            // Check if locked3List has anything in it.
                            if (locked3List.Count > 0)
                            {
                                // Check if locked4List has anything in it.
                                if (locked4List.Count > 0)
                                {
                                    // Check if locked5List has anything in it.
                                    if (locked5List.Count > 0)
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.locked1ListScore + this.locked2ListScore + this.locked3ListScore
                                                    + this.locked4ListScore + this.locked5ListScore + this.pendingScore;
                                    }
                                    else
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.locked1ListScore + this.locked2ListScore + this.locked3ListScore
                                                    + this.locked4ListScore + this.pendingScore;

                                        // Set locked5List score as the current pending score.
                                        this.locked5ListScore = this.pendingScore;
                                    }
                                }
                                else
                                {
                                    // Set this.tempScore as the current pending score.
                                    this.tempScore = this.locked1ListScore + this.locked2ListScore + this.locked3ListScore + this.pendingScore;

                                    // Set locked4List score as the current pending score.
                                    this.locked4ListScore = this.pendingScore;
                                }
                            }
                            else
                            {
                                // Set this.tempScore as the current pending score.
                                this.tempScore = this.locked1ListScore + this.locked2ListScore + this.pendingScore;

                                // Set locked3List score as the current pending score.
                                this.locked3ListScore = this.pendingScore;
                            }
                        }
                        else
                        {
                            // Set this.tempScore as the current pending score.
                            this.tempScore = this.locked1ListScore + this.pendingScore;

                            // Set locked2List score as the current pending score.
                            this.locked2ListScore = this.pendingScore;
                        }
                    }
                    else
                    {
                        // Set this.tempScore as the current pending score.
                        this.tempScore = this.pendingScore;

                        // Set locked1List score as the current pending score.
                        this.locked1ListScore = this.pendingScore;
                    }
                }
                else
                {
                    // Hot dice scoring.
                    // Check if locked1List has anything in it.
                    if (locked1List.Count > 0)
                    {
                        // Check if locked2List has anything in it.
                        if (locked2List.Count > 0)
                        {
                            // Check if locked3List has anything in it.
                            if (locked3List.Count > 0)
                            {
                                // Check if locked4List has anything in it.
                                if (locked4List.Count > 0)
                                {
                                    // Check if locked5List has anything in it.
                                    if (locked5List.Count > 0)
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                                    + this.locked3ListScore + this.locked4ListScore + this.locked5ListScore
                                                    + this.pendingScore;
                                    }
                                    else
                                    {
                                        // Set this.tempScore as the current pending score.
                                        this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                                    + this.locked3ListScore + this.locked4ListScore + this.pendingScore;

                                        // Set locked5List score as the current pending score.
                                        this.locked5ListScore = this.pendingScore;
                                    }
                                }
                                else
                                {
                                    // Set this.tempScore as the current pending score.
                                    this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                                + this.locked3ListScore + this.pendingScore;

                                    // Set locked4List score as the current pending score.
                                    this.locked4ListScore = this.pendingScore;
                                }
                            }
                            else
                            {
                                // Set this.tempScore as the current pending score.
                                this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.locked2ListScore
                                            + this.pendingScore;

                                // Set locked3List score as the current pending score.
                                this.locked3ListScore = this.pendingScore;
                            }
                        }
                        else
                        {
                            // Set this.tempScore as the current pending score.
                            this.tempScore = this.hotDiceAccumulator + this.locked1ListScore + this.pendingScore;

                            // Set locked2List score as the current pending score.
                            this.locked2ListScore = this.pendingScore;
                        }
                    }
                    else
                    {
                        // Set this.tempScore as the current pending score.
                        this.tempScore = this.hotDiceAccumulator + this.pendingScore;

                        // Set locked1List score as the current pending score.
                        this.locked1ListScore = this.pendingScore;
                    }
                }

                // Reset pending score to 0.
                this.pendingScore = 0;
            }
        }

        /// <summary>
        /// Method to reset the players fields for new turn.
        /// </summary>
        public void ResetFieldsForNewTurn()
        {
            // Reset round to 0.
            this.round = 0;

            // Reset hotDiceAccumulator to 0.
            this.hotDiceAccumulator = 0;

            // Reset hotDice to false.
            this.hotDice = false;

            // Reset wasHotDice to false.
            this.wasHotDice = false;

            // Reset validDice to false.
            this.validDice = false;
        }
    }
}
