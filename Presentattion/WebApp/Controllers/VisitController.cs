using System.ComponentModel.DataAnnotations;
using ACMEMarketing.Core.Application.Features.Visitors.Queries;
using Application.DTOs;
using Application.Features.Customers.Queries;
using Application.Features.Visits.Commands;
using Application.Features.Visits.Queries;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers.Base.Controllers;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Extentions;

namespace WebApp.Controllers;

public class VisitController : BaseController
{
    // GET
    public async Task<IActionResult> Index()
    {
        return View(await Mediator.Send(new GetAllVisits()));
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await Mediator.Send(new GetVisitById(id)));
    }

    public async Task<IActionResult> Create()
    {
        var visitors = await Mediator.Send(new GetAllVisitors());
        ViewBag.Visitors = new SelectList(visitors.Select(v => new { v.Id, FullName = v.Name + " " + v.LastName }), "Id", "FullName");
        var customers = await Mediator.Send(new GetAllCustomers());
        ViewBag.Customers = new SelectList(customers.Select(v => new { v.Id, FullName = v.FirstName + " " + v.LastName }), "Id", "FullName");
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateVisitCommand command)
    {
        try
        {
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        catch (FluentValidation.ValidationException e)
        {
            ModelState.AddToModelState(e.Errors);
            
            var visitors = await Mediator.Send(new GetAllVisitors());
            ViewBag.Visitors = new SelectList(visitors.Select(v => new { v.Id, FullName = v.Name + " " + v.LastName }), "Id", "FullName");
            var customers = await Mediator.Send(new GetAllCustomers());
            ViewBag.Customers = new SelectList(customers.Select(v => new { v.Id, FullName = v.FirstName + " " + v.LastName }), "Id", "FullName");

            return View(command);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IActionResult> Edit(int id)
    {
        return View(await Mediator.Send(new GetVisitById(id)));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(VisitDto visit)
    {
        try
        {
            await Mediator.Send(new UpdateVisitCommand(
                visit.Id,
                visit.VisitedDate ?? DateTime.Now,
                visit.Notes,
                visit.Purpose
            ));
            return RedirectToAction(nameof(Index));
        }
        catch (FluentValidation.ValidationException e)
        {
            ModelState.AddToModelState(e.Errors);
            return View(visit);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        return View(await Mediator.Send(new GetVisitById(id)));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await Mediator.Send(new DeleteVisitCommand(id));
        return RedirectToAction(nameof(Index));
    }
}