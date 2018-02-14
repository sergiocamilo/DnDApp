﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Dnd_App.Controllers
{
    public class NPCController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult _AllNPC()
        {
            TempData["CurrentAction"] = "_AllNPC";
            TempData["CurrentController"] = "NPC";
            return PartialView();
        }


        [HttpGet]
        public ActionResult New()
        {

            Utils.Presets Preset = new Utils.Presets();
            var NPC = Preset.GenerateEmptyNPC();
            Utils.TemporalDB.Instance.InsertNPC(NPC);

            return View(NPC);
        }

        [HttpGet]
        public PartialViewResult _Create(long TempID)
        {
            var Npc = new Models.Characters.NPC();
            Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc);
        }

        [HttpGet]
        public ActionResult _View(long TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            return PartialView(Npc);
        }



        #region Callbacks --> Basic Info

        [HttpPost]
        public ActionResult _updateName(String newName, long TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Name;
            Npc.Name = newName;

            return Json(new { nameValue = "Name", lastValue = LastValue, newValue = newName });
        }

        [HttpPost]
        public ActionResult _updateSize(Models.Enum.TypeSize type, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Size.TypeSize;
            Npc.Size.TypeSize = type;

            return Json(new { nameValue = "Size", lastValue = LastValue.ToString(), newValue = type.ToString() });
        }

        [HttpPost]
        public ActionResult _updateType(Models.Enum.TypeCreature type, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.TypeCreature;
            Npc.TypeCreature = type;

            return Json(new { nameValue = "Type creature", lastValue = LastValue.ToString(), newValue = type.ToString() });
        }

        [HttpPost]
        public ActionResult _updateAlignmentMorality(Models.Enum.TypeAlignMorality val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.AlignmentMorality;
            Npc.AlignmentMorality = val;

            return Json(new { nameValue = "Alignment Morality", lastValue = LastValue.ToString(), newValue = val.ToString() });
        }

        [HttpPost]
        public ActionResult _updateAlignmentAttitude(Models.Enum.TypeAlignAttitude val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.AlignmentMorality;
            Npc.AlignmentAttitude = val;

            return Json(new { nameValue = "Alignment Attitude", lastValue = LastValue.ToString(), newValue = val.ToString() });
        }

        [HttpPost]
        public ActionResult _updateTag(String val, int TempID)
        {
            var Npc = Utils.TemporalDB.Instance.SelectNPC(TempID);
            var LastValue = Npc.Tag;
            Npc.Tag = val;

            return Json(new { nameValue = "Tag", lastValue = LastValue, newValue = val });
        }


        #endregion




    }
}