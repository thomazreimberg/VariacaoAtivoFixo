using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VariacaoAtivoFixo.Application.Dto;
using VariacaoAtivoFixo.Application.Interfaces;

namespace VariacaoAtivoFixo.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private IAssetApplication _assetApplication { get; set; }

        public AssetController(ILogger<AssetController> logger, IAssetApplication assetApplication)
        {
            _logger = logger;
            _assetApplication = assetApplication;
        }

        /// <summary>
        /// GetAssets.
        /// </summary>
        /// <param name="paper"></param>
        /// <returns>200: IEnumerable<AssetDtoGet></returns>
        [HttpGet(Name = "GetAssets")]
        public ActionResult<List<AssetDtoGet>> GetAssets(string paper) =>
            Ok(_assetApplication.GetAssets(paper));
    }
}
