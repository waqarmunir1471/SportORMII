using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context context;

        public HomeController(Context DBContext)
        {
            context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = context.Leagues
                .Where(l => l.Sport.Contains("Baseball"));
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            
            ViewBag.allWomens = context.Leagues.Where(a => a.Name.Contains("Women")).ToList();
            ViewBag.Hockey = context.Leagues.Where(b => b.Sport.Contains("Hockey")).ToList();
            // ...all leagues where sport is something OTHER THAN football
            ViewBag.football = context.Leagues.Where(c => c.Sport != "Football").ToList();
            // ...all leagues that call themselves "conferences"
            ViewBag.Conferences = context.Leagues.Where(d => d.Name.Contains("Conference")).ToList();
            // ...all leagues in the Atlantic region
            ViewBag.Atlantic = context.Leagues.Where(e => e.Name.Contains("Atlantic")).ToList();
            // ...all teams based in Dallas
            ViewBag.Dallas = context.Teams.Where(f => f.Location == "Dallas").ToList();
            // ...all teams named the Raptors
            ViewBag.Raptors = context.Teams.Where(g => g.TeamName == "Raptors").ToList();
            // ...all teams whose location includes "City"
            ViewBag.City = context.Teams.Where(h => h.Location.Contains("City")).ToList();

            // ...all teams whose names begin with "T"
            ViewBag.T = context.Teams.Where(g => g.TeamName.StartsWith("T")).ToList();
            // ...all teams, ordered alphabetically by location
            ViewBag.Alpha = context.Teams.OrderBy(j => j.Location).ToList();

            // ...all teams, ordered by team name in reverse alphabetical order
            ViewBag.RAlpha= context.Teams.OrderByDescending(k=>k.TeamName).ToList();

            // ...every player with last name "Cooper"
            ViewBag.LastName= context.Players.Where(k => k.LastName == "Cooper").ToList();

            // ...every player with first name "Joshua"
            ViewBag.FirstName= context.Players.Where(k => k.FirstName == "Joshua").ToList();

            // ...every player with last name "Cooper" EXCEPT those with "Joshua" as the first name
            ViewBag.FirstNLast= context.Players.Where(k => k.LastName == "Cooper" && k.FirstName != "Joshua").ToList();

            // ...all players with first name "Alexander" OR first name "Wyatt"
            ViewBag.Last= context.Players.Where(k => k.FirstName == "Alexander" || k.FirstName == "Wyatt" ).ToList();


            return View();
        }
        [HttpGet("Level_1_Model")]
        public IActionResult Level1Model()
        {
            
            // Context =context.ToList();
            return View(context);
        }


        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View(context);
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}