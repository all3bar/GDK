﻿using System.Collections.Generic;

namespace MathEngine
{
    /// <summary>
    /// Represents a simple paytable for a slot game.
    /// </summary>
    public class Paytable
    {
        /// <summary>
        /// The reel group.
        /// </summary>
        public ReelGroup ReelGroup { get; set; }

        /// <summary>
        /// The paylines.
        /// </summary>
        public PaylineGroup PaylineGroup { get; set; }

        /// <summary>
        /// The pay combinations.
        /// </summary>
        public PayComboGroup PayComboGroup { get; set; }

        public void ConstructDummyPaytable()
        {
            ReelGroup = GenerateReelGroup();
            PaylineGroup = GeneratePaylineGroup();
            PayComboGroup = GeneratePayComboGroup();
        }

        private ReelGroup GenerateReelGroup()
        {
            ReelGroup reels = new ReelGroup();

            Reel reel1 = new Reel();
            reel1.AddSymbol(new Symbol(0, "AA"));
            reel1.AddSymbol(new Symbol(1, "BB"));
            reel1.AddSymbol(new Symbol(2, "CC"));
            reel1.AddSymbol(new Symbol(3, "DD"));
            reel1.AddSymbol(new Symbol(4, "EE"));
            reel1.AddSymbol(new Symbol(5, "FF"));
            reel1.AddSymbol(new Symbol(6, "GG"));

            Reel reel2 = new Reel();
            reel2.AddSymbol(new Symbol(0, "AA"));
            reel2.AddSymbol(new Symbol(1, "BB"));
            reel2.AddSymbol(new Symbol(2, "CC"));
            reel2.AddSymbol(new Symbol(3, "DD"));
            reel2.AddSymbol(new Symbol(4, "EE"));
            reel2.AddSymbol(new Symbol(5, "FF"));
            reel2.AddSymbol(new Symbol(6, "GG"));

            Reel reel3 = new Reel();
            reel3.AddSymbol(new Symbol(0, "AA"));
            reel3.AddSymbol(new Symbol(1, "BB"));
            reel3.AddSymbol(new Symbol(2, "CC"));
            reel3.AddSymbol(new Symbol(3, "DD"));
            reel3.AddSymbol(new Symbol(4, "EE"));
            reel3.AddSymbol(new Symbol(5, "FF"));
            reel3.AddSymbol(new Symbol(6, "GG"));

            reels.AddReel(reel1);
            reels.AddReel(reel2);
            reels.AddReel(reel3);

            return reels;
        }

        private PaylineGroup GeneratePaylineGroup()
        {
            PaylineGroup paylines = new PaylineGroup();

            Payline payline1 = new Payline();
            payline1.AddPaylineCoord(new PaylineCoord { ReelIndex = 0, Offset = 0 });
            payline1.AddPaylineCoord(new PaylineCoord { ReelIndex = 1, Offset = 0 });
            payline1.AddPaylineCoord(new PaylineCoord { ReelIndex = 2, Offset = 0 });

            Payline payline2 = new Payline();
            payline2.AddPaylineCoord(new PaylineCoord { ReelIndex = 0, Offset = 1 });
            payline2.AddPaylineCoord(new PaylineCoord { ReelIndex = 1, Offset = 1 });
            payline2.AddPaylineCoord(new PaylineCoord { ReelIndex = 2, Offset = 1 });

            Payline payline3 = new Payline();
            payline3.AddPaylineCoord(new PaylineCoord { ReelIndex = 0, Offset = 2 });
            payline3.AddPaylineCoord(new PaylineCoord { ReelIndex = 1, Offset = 2 });
            payline3.AddPaylineCoord(new PaylineCoord { ReelIndex = 2, Offset = 2 });

            paylines.AddPayline(payline1);
            paylines.AddPayline(payline2);
            paylines.AddPayline(payline3);

            return paylines;
        }

        private PayComboGroup GeneratePayComboGroup()
        {
            PayComboGroup payCombos = new PayComboGroup();

            List<Symbol> payAA = new List<Symbol>
            {
                new Symbol(0, "A"), new Symbol(0, "A")
            };

            List<Symbol> payAAA = new List<Symbol>
            {
                new Symbol(0, "A"), new Symbol(0, "A"), new Symbol(0, "A")
            };

            List<Symbol> payBBB = new List<Symbol>
            {
                new Symbol(1, "B"), new Symbol(1, "B"), new Symbol(1, "B")
            };

            List<Symbol> payCCC = new List<Symbol>
            {
                new Symbol(2, "C"), new Symbol(2, "C"), new Symbol(2, "C")
            };

            payCombos.AddPayCombo(new PayCombo(payAA, 10));
            payCombos.AddPayCombo(new PayCombo(payAAA, 100));
            payCombos.AddPayCombo(new PayCombo(payBBB, 50));
            payCombos.AddPayCombo(new PayCombo(payCCC, 20));

            return payCombos;
        }
    }
}
