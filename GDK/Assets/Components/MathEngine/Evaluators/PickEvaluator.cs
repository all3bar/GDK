﻿using System;
using System.Collections.Generic;

namespace GDK.MathEngine.Evaluators
{
	public class PickEvaluator : IEvaluator
	{
		private string PickFeatureId { get; set; }

		public PickEvaluator (string pickFeatureId)
		{
			PickFeatureId = pickFeatureId;
		}

        public SlotResults Evaluate(Paytable paytable, ReelWindow reelWindow, IRng rng)
		{
			if (paytable.PickTableGroup.PickTable.ContainsKey (PickFeatureId) == false)
			{
				// Can't evaluate if it doesn't exist in paytable.
				return null;
			}

			PickTable pickTable = paytable.PickTableGroup.PickTable [PickFeatureId];

			// Make a copy of the list since we will be removing elements from it.
			List<PickItem> pickItems = new List<PickItem> (pickTable.PickItemList);

			PickItem item;
			SlotResults results = new SlotResults ();
            PickComponent component = new PickComponent();

			do
			{
				// Continue picking items until a trigger is found.
				int randomNumber = rng.GetRandomNumber (pickItems.Count);
				item = pickItems [randomNumber];
				pickItems.RemoveAt(randomNumber);

                component.PickResults.Add(new PickResult {
                    Name = item.Name,
                    Value = item.Value,
                    Trigger = item.Trigger.Name
                });

			} while (string.IsNullOrEmpty (item.Trigger.Name));

            // Add the pick component to the slot result.
            SlotResult slotResult = new SlotResult();
            results.Results.Add(slotResult);
            if (component.PickResults.Count > 0)
                slotResult.AddComponent<PickComponent>(component);
				
			return results;
		}
	}
}
