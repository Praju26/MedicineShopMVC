using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProgramMVC.Controllers
{
    //Added a controller by inheriting the Controller class from Microsoft.AspNetCore.Mvc namespace
    public class HomeController : Controller
    {
        //Added an action called index which returns a string
        public string Index()
        {
            return "This is from Index action of home controller";
        }
    }
}