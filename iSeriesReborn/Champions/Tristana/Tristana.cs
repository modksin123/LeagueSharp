﻿using System;
using System.Collections.Generic;
using DZLib.Logging;
using iSeriesReborn.Champions.Tristana.Skills;
using iSeriesReborn.Utility;
using iSeriesReborn.Utility.MenuUtility;
using iSeriesReborn.Utility.ModuleHelper;
using LeagueSharp;
using LeagueSharp.Common;

namespace iSeriesReborn.Champions.Tristana
{
    class Tristana : ChampionBase
    {
        private readonly Dictionary<SpellSlot, Spell> spells = new Dictionary<SpellSlot, Spell>()
        {
            { SpellSlot.Q, new Spell(SpellSlot.Q) },
            { SpellSlot.E, new Spell(SpellSlot.E, 550) },
            { SpellSlot.R, new Spell(SpellSlot.R, 550) }
        };

        protected override void OnChampLoad()
        {
            throw new NotImplementedException();
        }

        protected override void LoadMenu()
        {
            var defaultMenu = Variables.Menu;

            var comboMenu = defaultMenu.AddModeMenu(Orbwalking.OrbwalkingMode.Combo);
            {
                comboMenu.AddSkill(SpellSlot.Q, Orbwalking.OrbwalkingMode.Combo, true, 15);
                comboMenu.AddSkill(SpellSlot.E, Orbwalking.OrbwalkingMode.Combo, true, 5);
                comboMenu.AddSkill(SpellSlot.R, Orbwalking.OrbwalkingMode.Combo, true, 10);
            }

            var mixedMenu = defaultMenu.AddModeMenu(Orbwalking.OrbwalkingMode.Mixed);
            {
                mixedMenu.AddSkill(SpellSlot.Q, Orbwalking.OrbwalkingMode.Mixed, true, 15);
                mixedMenu.AddSkill(SpellSlot.E, Orbwalking.OrbwalkingMode.Mixed, true, 5);
            }

            var laneclearMenu = defaultMenu.AddModeMenu(Orbwalking.OrbwalkingMode.LaneClear);
            {
                laneclearMenu.AddSkill(SpellSlot.Q, Orbwalking.OrbwalkingMode.LaneClear, true, 50);
            }

            spells[SpellSlot.E].SetTargetted(0.25f, 2400);
        }

        protected override void OnTick()
        {

        }

        protected override void OnCombo()
        {
            TristanaQ.HandleLogic();
            TristanaE.HandleLogic();
            TristanaR.HandleLogic();
        }

        protected override void OnMixed()
        {

        }

        protected override void OnLastHit() { }

        protected override void OnLaneClear()
        {

        }

        protected override void OnAfterAttack(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {

        }

        public override Dictionary<SpellSlot, Spell> GetSpells()
        {
            return spells;
        }

        public override List<IModule> GetModules()
        {
            return new List<IModule>()
            {

            };
        }
    }
}