using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bejeweled.Kernel {
    public class MoveSolution {

        public Point From { get; set; }

        public Point To { get; set; }

        public int Score { get; set; }

        public int DestroyedWhite { get; set; }
        public int DestroyedOrange { get; set; }
        public int DestroyedYellow { get; set; }
        public int DestroyedGreen { get; set; }
        public int DestroyedBlue { get; set; }
        public int DestroyedPurple { get; set; }
        public int DestroyedRed { get; set; }

        public void AddDestroyed(JewelColors color, int count) {
            if (color == JewelColors.White) DestroyedWhite += count;
            else if (color == JewelColors.Orange) DestroyedOrange += count;
            else if (color == JewelColors.Yellow) DestroyedYellow += count;
            else if (color == JewelColors.Green) DestroyedGreen += count;
            else if (color == JewelColors.Blue) DestroyedBlue += count;
            else if (color == JewelColors.Purple) DestroyedPurple += count;
            else if (color == JewelColors.Red) DestroyedRed += count;
        }



        public static MoveSolution[] Find(Jewel[,] jewels) {
            var list = new List<MoveSolution>();

            for (var x = 0; x <= 7; x++) {
                for (var y = 0; y <= 7; y++) {

                    MoveSolution solution = null;

                    if (x + 1 <= 7) {
                        solution = new MoveSolution {
                            From = new Point(x, y),
                            To = new Point(x + 1, y)
                        };
                    }

                    if (solution != null) {
                        solution.Score = GetScoreTheMove(jewels, solution);
                        if (solution.Score > 0) list.Add(solution);
                    }

                    solution = null;

                    if (y + 1 <= 7) {
                        solution = new MoveSolution {
                            From = new Point(x, y),
                            To = new Point(x, y + 1)
                        };
                    }

                    if (solution != null) {
                        solution.Score = GetScoreTheMove(jewels, solution);
                        if (solution.Score > 0) list.Add(solution);
                    }




                }
            }

            return list.ToArray();
        }

        ///<summary>1 score for 3 jewels, 2 for 4 jewels... </summary>
        public static int GetScoreTheMove(Jewel[,] jewels, MoveSolution solution) {
            var jewel1 = jewels[solution.From.X, solution.From.Y];
            var jewel2 = jewels[solution.To.X, solution.To.Y];

            if (jewel1.Color == jewel2.Color) return 0;

            jewels[solution.From.X, solution.From.Y] = jewel2;
            jewels[solution.To.X, solution.To.Y] = jewel1;
            

            var score = 0;
            var destroyed = countDestroyed(jewels, solution.From.X, solution.From.Y);
            score += Math.Max(0, destroyed - 2);
            solution.AddDestroyed(jewel2.Color, destroyed);



            destroyed = countDestroyed(jewels, solution.To.X, solution.To.Y);
            score += Math.Max(0, destroyed - 2);
            solution.AddDestroyed(jewel1.Color, destroyed);


            jewels[solution.From.X, solution.From.Y] = jewel1;
            jewels[solution.To.X, solution.To.Y] = jewel2;
            

            return score;
        }

        ///<summary>Count how many jewels have the same color in a row near a specified position.</summary>
        static int countDestroyed(Jewel[,] jewels, int x, int y) {
            var row = countMatchRow(jewels, x, y);
            var col = countMatchColumn(jewels, x, y);
            var destroyed = 0;

            if (row >= 3) destroyed += row;
            if (col >= 3) destroyed += col;

            return destroyed;
        }

        ///<summary>Count how many jewels have the same color in a row near a specified position.</summary>
        static int countMatchRow(Jewel[,] jewels, int x, int y) {
            var jewel = jewels[x, y];
            var count = 0;

            if (jewel.Color == JewelColors.None) return 0;

            for (var i = x + 1; i <= 7; i++) {
                if (jewels[i, y].Color == jewel.Color) count++;
                else {
                    break;
                }
            }

            for (var i = x - 1; i >= 0; i--) {
                if (jewels[i, y].Color == jewel.Color) count++;
                else break;
            }


            return count + 1;
        }

        ///<summary>Count how many jewels have the same color in a column near a specified position.</summary>
        static int countMatchColumn(Jewel[,] jewels, int x, int y) {
            var jewel = jewels[x, y];
            var count = 0;

            if (jewel.Color == JewelColors.None) return 0;

            for (var i = y + 1; i <= 7; i++) {
                if (jewels[x, i].Color == jewel.Color) count++;
                else break;
            }

            for (var i = y - 1; i >= 0; i--) {
                if (jewels[x, i].Color == jewel.Color) count++;
                else break;
            }

            return count + 1;
        }


        public static MoveSolution[] FilterMoveCanInOneTime(Jewel[,] jewels, MoveSolution[] solutions) {
            if (solutions.Length == 0) return new MoveSolution[] { };
            if (solutions.Length == 1) return new MoveSolution[] { solutions[0] };

            var list = new List<MoveSolution>();
            var mask = new byte[8, 8];

            //
            for (var i = 0; i < solutions.Length; i++) {
                var moveMask = getMaskOfMove(jewels, solutions[i]);

                if (isMaskOverlap(mask, moveMask) == false) list.Add(solutions[i]);
            }

            return list.ToArray();
        }

        ///<summary>Gets affect jewels of a move solution.</summary>
        static byte[,] getMaskOfMove(Jewel[,] jewels, MoveSolution solution) {
            var from = solution.From;
            var to = solution.To;
            var jewel1 = jewels[solution.From.X, solution.From.Y];
            var jewel2 = jewels[solution.To.X, solution.To.Y];

            jewels[solution.From.X, solution.From.Y] = jewel2;
            jewels[solution.To.X, solution.To.Y] = jewel1;

            var mask = new byte[8, 8];

            maskRow(jewels, from.X, from.Y, mask);
            maskColumn(jewels, from.X, from.Y, mask);

            maskRow(jewels, to.X, to.Y, mask);
            maskColumn(jewels, to.X, to.Y, mask);

            //jewels[from.X, from.Y]

            jewels[solution.From.X, solution.From.Y] = jewel1;
            jewels[solution.To.X, solution.To.Y] = jewel2;

            return mask;
        }
        static void maskRow(Jewel[,] jewels, int x, int y, byte[,] mask) {
            
            if (countMatchRow(jewels, x, y) < 3) return;

            var jewel = jewels[x, y];

            mask[x, y] = 1;

            for (var i = x + 1; i <= 7; i++) {
                if (jewels[i, y].Color == jewel.Color) mask[i, y] = 1;
                else
                    break;
            }    
            

            for (var i = x - 1; i >= 0; i--) {
                if (jewels[i, y].Color == jewel.Color) mask[i, y] = 1;
                else break;
            }

        }
        static void maskColumn(Jewel[,] jewels, int x, int y, byte[,] mask) {

            if (countMatchColumn(jewels, x, y) < 3) return;

            var jewel = jewels[x, y];


            if (jewel.Color == JewelColors.None) return;
            mask[x, y] = 1;

            for (var i = y + 1; i <= 7; i++) {
                if (jewels[x, i].Color == jewel.Color) mask[x, i] = 1;
                else break;
            }

            for (var i = y - 1; i >= 0; i--) {
                if (jewels[x, i].Color == jewel.Color) mask[x, i] = 1;
                else break;
            }
        }

        static bool isMaskOverlap(byte[,] mask1, byte[,] mask2) {
            for (var x = 0; x <= 7; x++) {
                for (var y = 0; y <= 7; y++) {
                    if (mask2[x, y] == 1 && mask1[x, y] == 1) return true;
                }
            }

            return false;
        }

    }
}
