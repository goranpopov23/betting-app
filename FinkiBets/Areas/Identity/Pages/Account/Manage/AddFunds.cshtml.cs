using System.ComponentModel.DataAnnotations;
using FinkiBets.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinkiBets.Areas.Identity.Pages.Account.Manage
{
    public class AddFundsModel : PageModel
    {
        private readonly UserManager<GamblingUser> _userManager;
        private readonly SignInManager<GamblingUser> _signInManager;

        public AddFundsModel(
            UserManager<GamblingUser> userManager,
            SignInManager<GamblingUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Range(1.0, 10000.0, ErrorMessage = "Please enter an amount between 1 and 10,000.")]
            [Display(Name = "Deposit Amount")]
            public double Amount { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user.");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound($"Unable to load user.");

            if (!ModelState.IsValid) return Page();

            user.accountBalance += Input.Amount;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Error: Unexpected error when trying to update balance.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);

            StatusMessage = $"Successfully added {Input.Amount}$ to your account!";
            return RedirectToPage();
        }
    }
}