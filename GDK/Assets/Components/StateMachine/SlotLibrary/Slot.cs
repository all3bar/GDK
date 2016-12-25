﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine;
using GameLibrary;

namespace SlotLibrary
{
    /// <summary>
    /// Base class for slot games.
    /// </summary>
    public class Slot : Game
    {
        private BaseState stateBeginPlay;
        private BaseState stateEvaluate;

        /// <summary>
        /// Configure all the slot states.
        /// </summary>
        /// <param name="stateMachine">The game state machine.</param>
        public override void ConfigureStates(GameStateMachine stateMachine)
        {
            // Base states must be initialized first.
            base.ConfigureStates(stateMachine);

            // Substates of StatePlay.
            stateBeginPlay = new StateBeginPlay();
            stateBeginPlay.Configure(stateMachine);
                

            stateEvaluate = new StateEvaluate();
            stateEvaluate.Configure(stateMachine);
        }

        public override void StartGameResponse()
        {
            stateMachine.AddTrigger("TriggerStateBeginPlay");
            stateMachine.AddTrigger("TriggerStateEvaluate");
            
            // This should be called at the end so we can trigger the appropriate
            // game specific states. If we called this at the start of the method,
            // the triggers for the slot substates would be invalid.
            base.StartGameResponse();
        }
    }
}
