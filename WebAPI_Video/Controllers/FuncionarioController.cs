using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Video.Models;
using WebAPI_Video.Service.FuncionarioService;

namespace WebAPI_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionarioInterface = funcionarioInterface;
        }


        /// <summary>
        /// Retorna todos os funcionários
        /// </summary>
        /// <returns>Retorna uma lista com todos os funcionários</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        /// <summary>
        /// Retorna um funcionário de acordo com o Id
        /// </summary>
        /// <param name="id">Identificador do funcionário</param>
        /// <returns>Retorna um objeto de funcionário</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(id);

            return Ok(serviceResponse);
        }

        /// <summary>
        /// Adiciona um novo funcionário
        /// </summary>
        /// <remarks>
        /// "id": 0,
        ///"nome": "string",
        ///"sobrenome": "string",
        ///"departamento": "RH",
        ///"ativo": true,
        ///"turno": "Manha",
        ///"dataDeCriacao": "2024-06-02T13:56:34.891Z",
        ///"dataDeAlteracao": "2024-06-02T13:56:34.891Z"
        /// </remarks>
        /// <param name="novoFuncionario">Objeto funcionario </param>
        /// <returns>Retorna a lista de funcionários atualizada</returns>
        /// <response code="200">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

            return Ok(serviceResponse);
        }


        [HttpPut("inativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);

            return Ok(serviceResponse);

        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

            return Ok(serviceResponse);

        }

    }
}
