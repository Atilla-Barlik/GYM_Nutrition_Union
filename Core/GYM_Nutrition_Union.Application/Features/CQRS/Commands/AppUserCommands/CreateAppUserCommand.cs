using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_Nutrition_Union.Application.Features.CQRS.Commands.AppUserCommands
{
	public class CreateAppUserCommand
	{
		public string AppUserFirstName { get; set; }
		public string AppUserLastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string AppUserEmail { get; set; }
        [Required]
        public string AppUserPassword { get; set; }

    }
}
