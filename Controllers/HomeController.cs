// 🔷 "Controllers/HomeController.cs" file, Project: ConsoleApplication .NET8 🔷

using Microsoft.AspNetCore.Mvc;
using SWebAPI_6.Models;
using System.Globalization;
using System.Text.Json;

namespace SWebAPI_5.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ILogger<Shareholder> _logger;
    public List<Shareholder> Shareholders { get; set; }

    public HomeController(ILogger<Shareholder> logger)
    {
        _logger = logger;
        Shareholders = GetExamplePeopleListDeserializeLiteral();
    }

    // ✅ ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
    // ---------------- Actions -------------------------
    // -- Handling these actions creates a RESTful API --
    
    [HttpGet]
    public IEnumerable<Shareholder> GetAll()
    {
        return Shareholders;
    }

    [HttpGet("{id}")]
    public ActionResult<Shareholder> GetById(int id)
    {
        var sh = Shareholders.FirstOrDefault(s => s.Id == id);
        if (sh == null) return NotFound();
        return sh;
    }

    [HttpPost]
    public ActionResult<Shareholder> Create(Shareholder newShareholder)
    {
        newShareholder.Id = Shareholders.Max(s => s.Id) + 1;
        Shareholders.Add(newShareholder);
        return CreatedAtAction(nameof(GetById), new { id = newShareholder.Id }, newShareholder);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Shareholder updated)
    {
        var sh = Shareholders.FirstOrDefault(s => s.Id == id);
        if (sh == null) return NotFound();

        sh.FirstName = updated.FirstName;
        sh.LastName = updated.LastName;
        sh.Sex = updated.Sex;
        sh.Address = updated.Address;
        sh.City = updated.City;
        sh.Shares = updated.Shares;
        sh.JoinDate = updated.JoinDate;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sh = Shareholders.FirstOrDefault(s => s.Id == id);
        if (sh == null) return NotFound();

        Shareholders.Remove(sh);
        return NoContent();
    }


    // ✅ ━━━━━━ functions ━━━━━━━━━━━━━

    private List<Shareholder> GetExamplePeopleListDeserializeLiteral()
    {
        // verbatim string """. This is valid in C# 11 and .NET 7+. No need to escape "
        string externalJson2 = """
        [
            {"Id":1,"FirstName":"Sylwia","LastName":"Michalak","Sex":"woman","Address":"ul. S\u0142owackiego 1","City":"Krak\u00F3w","Shares":1066.00,"JoinDate":"2020-12-29T00:00:00"},
            {"Id":2,"FirstName":"W\u0142odzimierz","LastName":"Kope\u0107","Sex":"man","Address":"ul. Lombard 3","City":"Radom","Shares":965.00,"JoinDate":"2020-09-20T00:00:00"},
            {"Id":3,"FirstName":"Wac\u0142aw","LastName":"Bednarz","Sex":"man","Address":"ul. S\u0142owackiego 11","City":"Krak\u00F3w","Shares":724.00,"JoinDate":"2021-10-13T00:00:00"},
            {"Id":4,"FirstName":"Anna","LastName":"Mucha","Sex":"woman","Address":"ul. Graniczna 24","City":"Gdynia","Shares":2109.00,"JoinDate":"2020-05-28T00:00:00"},
            {"Id":5,"FirstName":"Natalia","LastName":"Lis","Sex":"woman","Address":"al. Lombard 105","City":"Katowice","Shares":103.00,"JoinDate":"2021-03-21T00:00:00"},
            {"Id":6,"FirstName":"Witold","LastName":"W\u00F3jcik","Sex":"man","Address":"ul. Mickiewicza 28","City":"Wroc\u0142aw","Shares":1241.00,"JoinDate":"2022-01-30T00:00:00"},
            {"Id":7,"FirstName":"Wojciech","LastName":"Faber","Sex":"man","Address":"al. Piwna 109","City":"Pisz","Shares":158.00,"JoinDate":"2021-10-03T00:00:00"},
            {"Id":8,"FirstName":"Gra\u017Cyna","LastName":"Ko\u0142odziej","Sex":"woman","Address":"ul. Chmielna 30","City":"Pozna\u0144","Shares":761.00,"JoinDate":"2021-10-17T00:00:00"},
            {"Id":9,"FirstName":"Andrzej","LastName":"Biel","Sex":"man","Address":"ul. Hipoteczna 25","City":"Koszalin","Shares":3018.00,"JoinDate":"2020-05-19T00:00:00"},
            {"Id":10,"FirstName":"Marcin","LastName":"Urban","Sex":"man","Address":"ul. Bugaj 78","City":"Wroc\u0142aw","Shares":1579.00,"JoinDate":"2021-04-01T00:00:00"}
        ]
        """;

        var jsonShare = JsonSerializer.Deserialize<List<Shareholder>>(externalJson2);
        List<Shareholder> LHolders3 = (List<Shareholder>)jsonShare;

        return (LHolders3);
    }
}
