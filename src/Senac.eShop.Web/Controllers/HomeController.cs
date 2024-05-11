using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Senac.eShop.Web.Models;

namespace Senac.eShop.Web.Controllers;

public class HomeController : MainController
{
    [Route("system-unavaible")]
    public IActionResult SystemUnavailable()
    {
        var modelError = new ErrorViewModel
        {
            Message = "O sistema est� temporariamente indispon�vel, isto pode ocorrer " +
            "em momentos de sobrecarga de usu�rios.",
            Title = "Sistema Indispon�vel.",
            ErrorCode = 500
        };

        return View("Error", modelError);
    }

    public IActionResult Error(int id)
    {
        var modelError = new ErrorViewModel();

        if(id == 500)
        {
            modelError.Message = "Ocorreu um erro! Tente novamente mais tarde. " +
                "ou contate nosso suporte.";
            modelError.Title = "Ocorreu um erro!";
            modelError.ErrorCode = id;
        } else if (id == 404)
        {
            modelError.Message = "A p�gina que est� procurando n�o existe! <br />. " +
                "Em caso de d�vidas entre em contato com nosso suporte.";
            modelError.Title = "Ops! P�gina n�o encontrada";
            modelError.ErrorCode = id;
        }
        else if (id == 403)
        {
            modelError.Message = "Voc� n�o tem permiss�o para fazer isto.";
            modelError.Title = "Acesso Negado";
            modelError.ErrorCode = id;
        }
        else
        {
            return StatusCode(404);
        }

        return View("Error", modelError);
    }

}