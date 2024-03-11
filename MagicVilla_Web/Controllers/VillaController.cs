using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaController(IVillaService villaService, IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> list = new();

            var reponse = await _villaService.GetAllAsync<APIResponse>();

            if (reponse != null && reponse.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(reponse.Result));
            }

            return View(list);
        }

        public async Task<IActionResult> CreateVilla()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _villaService.CreateAsync<APIResponse>(model);

                if (reponse != null && reponse.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(model);
        }

        public async Task<IActionResult> UpdateVilla(int villaId)
        {
            var reponse = await _villaService.GetAsync<APIResponse>(villaId);

            if (reponse != null && reponse.IsSuccess)
            {
                VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(reponse.Result));

                return View(_mapper.Map<VillaUpdateDTO>(model));
            }

            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVilla(VillaUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var reponse = await _villaService.UpdateAsync<APIResponse>(model);

                if (reponse != null && reponse.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }

            return View(model);
        }
    }
}