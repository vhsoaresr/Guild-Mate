﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Guildmate.Data;
using Guildmate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Guildmate.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CharactersController(ApplicationDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }
        // GET: Characters
        public async Task<ActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var characters = await _context.Character
                .Include(cr => cr.ClassRace)
                //.ThenInclude(r => r.Race)
                //.ThenInclude(c => c.Class)
                
                .FirstOrDefaultAsync(c => c.ApplicationUserId == user.Id);
            return View(characters);
        }

        // GET: Characters/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Characters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Characters/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<ApplicationUser> GetCurrentUserAsync() => await _userManager.GetUserAsync(HttpContext.User);
    }
}