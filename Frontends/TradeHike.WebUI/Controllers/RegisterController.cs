using Microsoft.AspNetCore.Mvc;
using TradeHike.Domain.Entities;
using TradeHike.Persistence.Context;
using TradeHike.Dto.AppUserDtos;
using System.Linq;
using System.Threading.Tasks;

namespace TradeHike.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly MyContext _context;

        public RegisterController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new CreateAppUserDto()); // CreateAppUserDto gönderiliyor
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAppUserDto newUserDto)
        {
            if (ModelState.IsValid)
            {
                // DTO'dan entity'ye dönüşüm
                var newUser = new AppUser
                {
                    Username = newUserDto.Username,
                    Password = newUserDto.Password,
                    Name = newUserDto.Name,
                    Surname = newUserDto.Surname,
                    Email = newUserDto.Email,
                    AppRoleId = 2 // Varsayılan olarak 2
                };

                _context.AppUsers.Add(newUser);
                await _context.SaveChangesAsync();

                // Kayıt işlemi başarılı olduğunda giriş sayfasına yönlendir
                return RedirectToAction("Index", "Login");
            }

            // ModelState geçersizse, aynı sayfayı tekrar göster
            return View(newUserDto);
        }
    }
}
