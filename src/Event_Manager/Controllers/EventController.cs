using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Event_Manager.Models;


namespace Event_Manager.Controllers
{
    public class EventController : Controller
    {

        private readonly ApplicationUser _context;

        public EventController(ApplicationUser context)
        {
            _context = context;
        }


        public IActionResult Create(Event Ev, String addNewEvent)

        {
          if (ModelState.IsValid)
            {
                if (addNewEvent != null)
                {
                    foreach (var Ev in _context.Event.ToList())
                    {
                        String name = artist.Name;
                        if (name == addNewArtist)
                        {
                            addNewArtist = "";
                        }
                    }

                    if (addNewArtist != "")
                    {
                        Artist artist = new Artist();
                        artist.Name = addNewArtist;
                        artist.Bio = "";
                        _context.Artists.Add(artist);
                        _context.SaveChanges();
                        album.Artist = _context.Artists.Last();
                    }
                }

                if (AddNewGenre != null)
                {
                    foreach (var genres in _context.Genres.ToList())
                    {
                        String name = genres.Name;
                        if (name == AddNewGenre)
                        {
                            AddNewGenre = "";
                        }
                    }

                    if (AddNewGenre != "")
                    {
                        Genre genre = new Genre();
                        genre.Name = AddNewGenre;
                        _context.Genres.Add(genre);
                        _context.SaveChanges();
                        album.Genre = _context.Genres.Last();
                    }
                }

                _context.Albums.Add(album);
                _context.SaveChanges();
                return RedirectToAction("Details");
            }
            ViewBag.ArtistList = new SelectList(_context.Artists, "ArtistID", "Name");
            ViewBag.GenreList = new SelectList(_context.Genres, "GenreID", "Name");
            return View();
        }


    }
}
}
