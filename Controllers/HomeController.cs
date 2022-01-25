using System.Diagnostics;
using Assignment_ASP.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers;

public class HomeController : Controller
{
   public readonly ILogger<HomeController> _logger;
    [Route("NashTech/Rookies/Index")]
    //Danh sach member:
    public List<Member> GetList(){
        return new List<Member>
        {
            new Member
            {
                FName = "A",
                LName = "Nguyen Van",
                Gender = "Male",
                DoB = 2000,
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                Age = 22,
                isGraduated = false
            },
            new Member
            {
                FName = "B",
                LName = "Nguyen Van",
                Gender = "Male",
                DoB = 1999,
                PhoneNumber = "0123456789",
                BirthPlace = "HCM",
                Age = 23,
                isGraduated = false
            },
            new Member
            {
                FName = "C",
                LName = "Nguyen Thi",
                Gender = "Female",
                DoB = 2001,
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                Age = 21,
                isGraduated = false
            },
            new Member
            {
                FName = "D",
                LName = "Nguyen Van",
                Gender = "Male",
                DoB = 2000,
                PhoneNumber = "0123456789",
                BirthPlace = "Hai Phong",
                Age = 22,
                isGraduated = false
            },
            new Member
            {
                FName = "E",
                LName = "Nguyen Thi",
                Gender = "Female",
                DoB = 1997,
                PhoneNumber = "0123456789",
                BirthPlace = "Ha Noi",
                Age = 25,
                isGraduated = false
            }
        };
    }    
    //cau 1
    public List<Member> GetMaleMembers(List<Member> listMember)
    {
        var maleMembers = from member in listMember where member.Gender == "Male" select member;
        return maleMembers.ToList();
    }
    //cau 2
   public Member GetOldestMember(List<Member> listMember)
    {
        var oldestMember = from member in listMember orderby member.DoB ascending select member;
        return oldestMember.FirstOrDefault();
    }
    //cau 3
   public List<string> GetFullNameList(List<Member> listMember){
        var fullname = from member in listMember select string.Join(" ", member.FName, member.LName);
        return fullname.ToList();
    }

    //cau 4
    public List<List<Member>> List3(List<Member> listMember){
        var under2000 = from member in listMember where (member.DoB < 2000) select member;
        var is2000 = from member in listMember where (member.DoB == 2000) select member;
        var over2000 = from member in listMember where (member.DoB > 2000) select member;

        List<List<Member>> list3 = new List<List<Member>>{under2000.ToList(), is2000.ToList(), over2000.ToList()};
        return list3;
    }
    //Cau 6
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public List<Member> MaleMembers()
    {
        return GetMaleMembers(GetList());
    }

    public Member OldestMember()
    {
        return GetOldestMember(GetList());
    }

    public List<string> FullnameMembers()
    {
        return GetFullNameList(GetList());
    }
    public List<List<Member>> Get3Lists()
    {
        return List3(GetList());
    }
    //cau 5
    public FileResult Excel()
    {
        return File("Assets/Member.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Member.xlsx");
    }
    
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
