using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CollegeFestMVC.Models;
using CollegeFestMVC.Extensions;

namespace CollegeFestMVC.Controllers
{
    public class FestController : Controller
    {
        private static readonly List<Participant> _participants = new()
        {
            new Participant 
            { 
                ParticipantId = 1, 
                ParticipantName = "Aarav Patel", 
                Email = "aarav@amtics.ac.in", 
                Department = "Computer Engineering", 
                Year = "3rd Year", 
                EventName = "Coding Competition", 
                IsTeamEvent = false, 
                IsConfirmed = true 
            },
            new Participant 
            { 
                ParticipantId = 2, 
                ParticipantName = "Diya Shah", 
                Email = "diya@amtics.ac.in", 
                Department = "Information Technology", 
                Year = "2nd Year", 
                EventName = "Robo Race", 
                IsTeamEvent = true, 
                IsConfirmed = false 
            }
        };

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View(_participants);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Participant participant)
        {
            if (ModelState.IsValid)
            {
                participant.ParticipantId = _participants.Count > 0 ? _participants.Max(p => p.ParticipantId) + 1 : 1;
                participant.IsConfirmed = true;
                _participants.Add(participant);
                
                return RedirectToAction(nameof(Index));
            }
            return View(participant);
        }

        public IActionResult Details(int id)
        {
            var participant = _participants.FirstOrDefault(p => p.ParticipantId == id);
            if (participant == null)
            {
                return NotFound();
            }
            return View(participant);
        }
    }
}