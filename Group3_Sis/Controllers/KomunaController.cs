using Group3_Sis.Data;
using Group3_Sis.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Group3_Sis.Controllers
{
    public class KomunaController :Controller
    {

    private Konteksti _konteksti;
    public KomunaController(Konteksti kon)
    {
        _konteksti = kon;
    }
    public IActionResult Listo()
    {
        List<Komuna> komuna = _konteksti.Komunat.ToList();
        var komunat = _konteksti.Komunat.ToList();
        return View(komunat);
    }

    private List<SelectListItem> ListoKomunat()
    {
        List<Komuna> komunat = _konteksti.Komunat.ToList();
        List<SelectListItem> lista = new List<SelectListItem>();
        foreach (var kom in komunat)
        {
            SelectListItem obj = new SelectListItem();
            obj.Text = kom.Emri;
            obj.Value = kom.Id.ToString();
            lista.Add(obj);
        }

        return lista;
    }

    public IActionResult Krijo()
    {
        ViewBag.Komunat = ListoKomunat();
        return View();
    }

    [HttpPost]
    public IActionResult Krijo(Komuna komuna)
    {
        if (ModelState.IsValid)
        {
            _konteksti.Komunat.Add(komuna);
            _konteksti.SaveChanges();
            return RedirectToAction("Listo");
        }
        else
        {
            ViewBag.Komunat = ListoKomunat();
            return View(komuna);
        }

    }
        [HttpPost]
        public IActionResult Ndrysho(Komuna komuna)
        {
            if (ModelState.IsValid)
            {
                _konteksti.Komunat.Update(komuna);
                _konteksti.SaveChanges();
                return RedirectToAction("Listo");
            }
            else
            {
                return View(komuna);
            }
        }
        public IActionResult Ndrysho(int? komunaId)
        {
            if (komunaId == null || komunaId == 0)
            {
                return NotFound();
            }
            Komuna komuna = _konteksti.Komunat.Find(komunaId);
            if (komuna == null)
            {
                return NotFound();
            }

            return View(komuna);
        }
        [HttpPost]
    public IActionResult Fshi(Komuna komuna)
    {
        _konteksti.Komunat.Remove(komuna);
        _konteksti.SaveChanges();
        return RedirectToAction("Listo");
    }
    public IActionResult Fshi(int? komunaId)
    {
        if (komunaId == null || komunaId == 0)
        {
            return NotFound();
        }
        Komuna komuna = _konteksti.Komunat.Find(komunaId);
            if (komuna == null)
            {
                return NotFound();
            }
        return View(komuna);
    }

}
}
