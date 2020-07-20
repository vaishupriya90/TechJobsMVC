﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsMVC.Data;
using TechJobsMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsMVC.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.title = "Search Jobs";
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.selectedFilter = "all";
            return View();
        }

        // TODO #3: Create an action method to process a search request and render the updated search view.

        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Job> jobs;
            if (searchTerm == null || searchTerm.Equals(""))
            {
                jobs = JobData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                ViewBag.title = "Search term";
            }
            ViewBag.jobs = jobs;
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.selectedFilter = searchType;

            return View("Index");
        }
    }
}
