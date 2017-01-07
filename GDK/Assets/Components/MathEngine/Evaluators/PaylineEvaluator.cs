﻿using System;
using System.Collections.Generic;

namespace GDK.MathEngine.Evaluators
{
	/// <summary>
	/// Standard payline evaluator to provide the highest wins and all paylines.
	/// </summary>
	public class PaylineEvaluator : IEvaluator
	{
		public SlotResults Evaluate (Paytable paytable, IRng rng)
		{
			SlotResults results = new SlotResults ();
			List<Symbol> symbolsInPayline = new List<Symbol> ();

			// Get random numbers for each reel.
			List<int> randomNumbers = new List<int> ();
			for (int reel = 0; reel < paytable.ReelGroup.Reels.Count; ++reel)
			{
				ReelStrip reelStrip = paytable.ReelGroup.Reels [reel].ReelStrip;
				randomNumbers.Add (rng.GetRandomNumber (reelStrip.Strip.Count));
			}

			List<Payline> paylines = paytable.PaylineGroup.Paylines;
			foreach (Payline payline in paylines)
			{
				// Obtain the reel window based on the random numbers.
				symbolsInPayline = ReelWindow.GetSymbolsInPayline (paytable.ReelGroup, randomNumbers, payline);

				// Look for the highest pay amount on a given payline.
				int bestPayAmount = 0;
				PayCombo bestPayCombo = null;

				List<PayCombo> payCombos = paytable.PayComboGroup.Combos;

				foreach (PayCombo payCombo in payCombos)
				{
					bool match = payCombo.IsMatch (symbolsInPayline);
					if (match && (payCombo.PayAmount > bestPayAmount))
					{
						bestPayCombo = payCombo;
						bestPayAmount = payCombo.PayAmount;
					}
				}
					
				if (bestPayCombo != null)
				{
					results.Results.Add (new SlotResult (bestPayCombo, payline));
				}
			}

			return results;
		}
	}
}