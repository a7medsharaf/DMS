using AutoMapper;
using DMS.DTModels.KnowledgePools;
using DMS.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPController : ControllerBase
    {
        private readonly IKPService _KPService;
        private readonly IMapper _Mapper;
        public KPController(IKPService KPService, IMapper mapper)
        {
            this._KPService = KPService;
            _Mapper = mapper;   
        }

        [HttpPost("AddKnowlegePool")]
        // public void Post([FromBody] string value)
        public IActionResult AddKnowlegePool(KPDT KPDT)
        {
            AppResponse response = _KPService.AddKnowledgePool(KPDT.Name);
            if (response.response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateKnowlegePool")]
        // public void Post([FromBody] string value)
        public IActionResult UpdateKnowlegePool(KPDT_Update KPDT_Update)
        {
            AppResponse response = _KPService.UpdateKnowledgePool(KPDT_Update.OldName, KPDT_Update.NewName);
            if (response.response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteKnowlegePool")]
        // public void Post([FromBody] string value)
        public IActionResult DeleteKnowlegePool(KPDT KPDT)
        {
            AppResponse response = _KPService.DeleteKnowledgePool(KPDT.Name);
            if (response.response)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("ListKnowlegePool")]
        public IActionResult ListKnowlegePool()
        {
            return Ok(_Mapper.Map < List<KPReturn> >(_KPService.ListKnowledgePools()));
        }

    }
}
