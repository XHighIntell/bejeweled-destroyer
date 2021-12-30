using System;
using System.Collections.Generic;

namespace Bejeweled.Kernel {

    public class ColorScoreRecord {

        List<int> colors = new List<int>(8);
        List<int> scores = new List<int>(8);


        public void Add(JewelColors color, int score) {
            for (var i = 0; i < colors.Count; i++) {
                if (colors[i] == (int)color) {
                    scores[i] += score;
                    return;
                }
            }

            colors.Add((int)color);
            scores.Add(score);
        }


        public JewelColors GetHighest(out int score) {
            if (scores.Count == 0) {
                score = 0;
                return JewelColors.None;
            }

            var max_color = colors[0];
            var max_score = scores[0];

            for (var i = 1; i < colors.Count; i++) {
                if (scores[i] > max_score) {
                    max_color = colors[i];
                    max_score = scores[i];
                }
            }

            score = max_score;
            return (JewelColors)max_color;

        }

    }

   
}
