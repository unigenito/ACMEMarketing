using ACMEMarketing.Core.Application.Features.Visitors.Queries;
using Application.DTOs;
using Application.Features.Visitors.Command;
using Application.Features.Visitors.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Controllers.Base.Controllers;
using WebApp.Extentions;

namespace WebApp.Controllers;

public class VisitorController : BaseController
{
    // GET
    public async Task<IActionResult> Index()
    {
        return View(await Mediator.Send(new GetAllVisitors()));
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await Mediator.Send(new GetVisitorById(id)));
    }

    public IActionResult Create()
    {
        ViewBag.Genders = new SelectList(new List<SelectListItem>
        {
            new SelectListItem { Text = "Male", Value = "M" },
            new SelectListItem { Text = "Female", Value = "F" }
        }, "Value", "Text");
        
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateVisitorCommand command)
    {
        try
        {
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ModelState.AddToModelState(e.Errors);
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
        return View(await Mediator.Send(new GetVisitorById(id)));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(VisitorDto visitor)
    {
        try
        {
            await Mediator.Send(new UpdateVisitorCommand(
                visitor.Id,
                visitor.Email,
                visitor.Phone,
                visitor.Position,
                visitor.Department
            ));
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ModelState.AddToModelState(e.Errors);
            return View(visitor);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IActionResult> Delete(int id)
    {
        return View(await Mediator.Send(new GetVisitorById(id)));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await Mediator.Send(new DeleteVisitorCommand(id));
        return RedirectToAction(nameof(Index));
    }
}