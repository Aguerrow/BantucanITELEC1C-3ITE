using Microsoft.AspNetCore.Mvc;
using Bantucan_ITELEC1C.Models;


namespace Bantucan_ITELEC1C.Controllers
{
    public class InstructorController : Controller
    {
        List<Instructor> InstructorList = new List<Instructor>
            {
                new Instructor()
                {
                    Id= 1,FirstName = "Gabriel",LastName = "Montano", Rank =  Rank.Instructor, HiringDate = DateTime.Parse("2022-08-26"), IsTenured = true 
                },
                new Instructor()
                {
                    Id= 2,FirstName = "Zyx",LastName = "Montano", Rank = Rank.AssistantProfessor, HiringDate = DateTime.Parse("2022-08-07"), IsTenured = true
                },
                new Instructor()
                {
                    Id= 3,FirstName = "Aerdriel",LastName = "Montano", Rank = Rank.AssociateProfessor, HiringDate = DateTime.Parse("2020-01-25"), IsTenured = false
                }
            };
        public IActionResult Index()
        {
            
            return View(InstructorList);
        }

        public IActionResult ShowDetail(int id)
        {
            //Search for the student whose id matches the given id
            Instructor? instructor = InstructorList.FirstOrDefault(st => st.Id == id);
            
            if (instructor != null)//was an student found?
                return View(instructor);

            return NotFound();
        }

    }
}
