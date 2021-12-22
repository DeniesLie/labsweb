using Microsoft.AspNetCore.Mvc;
using DynamicMenu.Domain;
using DynamicMenu.Infrastructure;

namespace DynamicMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly MenuOption[] options = new MenuOption[] { 
            new MenuOption() {Title = "Entity Framework", Content = "Entity Framework is an open source object–relational mapping framework for ADO.NET. It was originally shipped as an integral part of .NET Framework. Starting with Entity Framework version 6, it has been delivered separately from the .NET Framework."},
            new MenuOption() {Title = "ADO.NET", Content = "ADO.NET is a set of classes that expose data access services for .NET Framework programmers. ADO.NET provides a rich set of components for creating distributed, data-sharing applications. It is an integral part of the .NET Framework, providing access to relational, XML, and application data. ADO.NET supports a variety of development needs, including the creation of front-end database clients and middle-tier business objects used by applications, tools, languages, or Internet browsers." },
            new MenuOption() {Title = "Dapper", Content = "Dapper is an object–relational mapping product for the Microsoft .NET platform: it provides a framework for mapping an object-oriented domain model to a traditional relational database. Its purpose is to relieve the developer from a significant portion of relational data persistence-related programming tasks." }
        };

        [HttpGet]
        [Route("getOptions")]
        public IActionResult GetOptions()
        {
            var result = options.Select(o => o.Title).ToList();
            Logger.LogAsXML(result);
            return Ok(result);
        }
  
        [HttpGet]
        [Route("getContent/{optionTitle}")]
        public IActionResult GetContent(string optionTitle)
        {
            var result = options.FirstOrDefault(o => o.Title == optionTitle);
            if (result == null)
                return NotFound();
            else
            {
                Logger.LogAsXML(result);
                return Ok(result);
            }
        }
    }
}
