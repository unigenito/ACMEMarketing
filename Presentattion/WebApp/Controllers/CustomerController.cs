﻿using Application.DTOs;
using Application.Features.Customers.Command;
using Application.Features.Customers.Queries;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Controllers.Base.Controllers;
using WebApp.Extentions;

namespace WebApp.Controllers;

public class CustomerController : BaseController
{

    // GET
    public async Task<IActionResult> Index()
    {
        return View(await Mediator.Send(new GetAllCustomers()));
    }

    public async Task<IActionResult> Details(int id)
    {
        return View(await Mediator.Send(new GetCustomerById(id)));
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
    public async Task<IActionResult> Create(CreateCustomerCommand command)
    {
        try
        {
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ModelState.AddToModelState(e.Errors);
            ViewBag.Genders = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "Male", Value = "M" },
                new SelectListItem { Text = "Female", Value = "F" }
            }, "Value", "Text");
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
        return View(await Mediator.Send(new GetCustomerById(id)));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CustomerDto customer)
    {
        try
        {
            await Mediator.Send(new UpdateCustomerCommand(
                customer.Id,
                customer.Country,
                customer.Email,
                customer.Phone,
                customer.City,
                customer.ZipCode,
                customer.Street
            ));
            
            return RedirectToAction(nameof(Index));
        }
        catch (ValidationException e)
        {
            ModelState.AddToModelState(e.Errors);
            return View(customer);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }

    public async Task<IActionResult> Delete(int id)
    {
        return View(await Mediator.Send(new GetCustomerById(id)));
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await Mediator.Send(new DeleteCustomerCommand(id));
        return RedirectToAction(nameof(Index));
    }


}