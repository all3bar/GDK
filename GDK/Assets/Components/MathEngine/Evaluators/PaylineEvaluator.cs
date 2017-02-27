﻿using System;
using System.Collections.Generic;

namespace GDK.MathEngine.Evaluators
{
    /// <summary>
    /// Standard payline evaluator to provide the highest wins and all paylines.
    /// </summary>
    public class PaylineEvaluator : IEvaluator
    {
        private ReelWindow reelWindow;

        public SlotResults Evaluate(Paytable paytable, ReelWindow reelWindow, IRng rng)
        {
            // TODO: Each evaluator should add to this rather than creating a new one.
            SlotResults results = new SlotResults();

            PaylinesComponent component = new PaylinesComponent();

            // Iterate through each payline defined in the paytable.
            List<Payline> paylines = paytable.PaylineGroup.Paylines;
            foreach (Payline payline in paylines)
            {
                // Get the list of symbols on the payline.
                List<Symbol> symbolsInPayline =
                    reelWindow.GetSymbolsInPayline(payline);

                // Look for the highest pay amount on a given payline.
                int bestPayAmount = 0;
                PayCombo bestPayCombo = null;

                List<PayCombo> payCombos = paytable.PayComboGroup.Combos;

                foreach (PayCombo payCombo in payCombos)
                {
                    bool match = payCombo.IsMatch(paytable.PayComboGroup.SymbolComparer, symbolsInPayline);
                    if (match && (payCombo.PayAmount > bestPayAmount))
                    {
                        // Update the best pay combo so far.
                        bestPayCombo = payCombo;
                        bestPayAmount = payCombo.PayAmount;
                    }
                }

                // Add the best pay combo.
                if (bestPayCombo != null)
                {
                    component.PayResults.Add(new PayResult { PayCombo = bestPayCombo, Payline = payline });
                    results.TotalWin += bestPayCombo.PayAmount;
                }
            }

            SlotResult slotResult = new SlotResult();
            results.Results.Add(slotResult);
            if (component.PayResults.Count > 0)
            {
                slotResult.AddComponent<PaylinesComponent>(component);
            }

            return results;
        }
    }
}