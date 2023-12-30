using HospitalAppointment.Areas.Identity.Data;
using HospitalAppointment.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HospitalAppointment.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly HospitalAppointmentDbContext _context;

        public DoctorController(HospitalAppointmentDbContext context)
        {
            _context = context;
        }

        //Get : Doctor 
        public async Task<IActionResult> Index()
        {
            return _context.Doctor != null ?
                          View(await _context.Doctor.ToListAsync()) :
                          Problem("Entity set 'HospitalAppointmentDbContext.Doctor'  is null.");
        }


        //GET: Doctor/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,DoctorName,department")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["department"] = new SelectList(_context.Doctors, "departmentID", "DepartmentName", doctor.departmentID);
            return View(doctor);
        }

        //Get: Doctor/Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["departmentID"] = new SelectList(_context.Departments, "departmentID", "DepartmentName", doctor.departmentID);
            return View(doctor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,DoctorName,departmentID")] Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExits(doctor.DoctorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["departmentID"] = new SelectList(_context.Departments, "departmentID", "DepartmentName", doctor.departmentID);
            return View(doctor);
        }

       //GET: Doctor//Delete
       public async Task<IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .Include(k => k.Department)
        }
      
    

        private bool DoctorExits(int id)
        {
            return _context.Doctors.Any(e => e.DoctorId == id);
        }
    }
}
