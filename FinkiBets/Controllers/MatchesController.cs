using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinkiBets.Domain.Domain;
using FinkiBets.Repository;
using FinkiBets.Service.Interface;
using FinkiBets.Service.Implementation;

namespace FinkiBets.Controllers
{
    public class MatchesController : Controller
    {
        private readonly IMatchService _matchesService;

        public MatchesController(IMatchService matchService)
        {
            _matchesService = matchService;
        }

        // GET: Matches
        public IActionResult Index()
        {
            return View(_matchesService.GetAll());
        }

        public IActionResult Football()
        {
            return View(_matchesService.GetAllFootballMatches());
        }

        public IActionResult Basketball()
        {
            return View(_matchesService.GetAllBasketballPlayerMatches());
        }
        // GET: Matches/Details/5
        public IActionResult Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _matchesService.GetById(id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["matchType"] = new SelectList(Enum.GetValues(typeof(SportType)));
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,startTime,matchType")] Match match, string homeTeam, string awayTeam, string playerName)
        {
            if (match.matchType == SportType.Football)
            {
                match.Name = $"{homeTeam} vs {awayTeam}";
            }
            else
            {
                match.Name = playerName;
            }
            
                match.Id = Guid.NewGuid();
                _matchesService.Insert(match);
                return RedirectToAction(nameof(Index));
            
            return View(match);
        }

        // GET: Matches/Edit/5
        public IActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _matchesService.GetById(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["matchType"] = new SelectList(Enum.GetValues(typeof(SportType)));
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,Name,startTime,matchType")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _matchesService.Update(match);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(match);
        }

        // GET: Matches/Delete/5
        public IActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = _matchesService.GetById(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["matchType"] = new SelectList(Enum.GetValues(typeof(SportType)));
            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var match = _matchesService.GetById(id);
            if (match != null)
            {
                _matchesService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(Guid id)
        {
            return _matchesService.GetById(id)!=null;
        }
    }
}
