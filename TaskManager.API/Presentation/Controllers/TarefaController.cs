using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Application.UseCases;
using TaskManager.API.Application.UseCases.CriarTarefa;
using TaskManager.API.Application.UseCases.ListarTarefas;
using TaskManager.API.Application.UseCases.ConcluirTarefa;
using TaskManager.API.Application.UseCases.EditarTarefas;
using TaskManager.API.Application.UseCases.DeletarTarefa;
using FluentValidation;

namespace TaskManager.API.Presentation
{
    [ApiController]
    [Route("tarefas")]
    public class TarefaController : ControllerBase
    {
        private readonly CriarTarefaUseCase _criarTarefaUseCase;
        private readonly ListarTarefasUseCase _listarTarefasUseCase;
        private readonly ConcluirTarefaUseCase _concluirTarefaUseCase;
        private readonly EditarTarefaUseCase _editarTarefaUseCase;
        private readonly DeletarTarefaUseCase _deletarTarefaUseCase;
        private readonly IValidator<CriarTarefaRequest> _validator;

        public TarefaController(
            CriarTarefaUseCase criarTarefaUseCase,
            ListarTarefasUseCase listarTarefasUseCase,
            ConcluirTarefaUseCase concluirTarefaUseCase,
            EditarTarefaUseCase editarTarefaUseCase,
            DeletarTarefaUseCase deletarTarefaUseCase,
            IValidator<CriarTarefaRequest> validator
            )
        {
            _criarTarefaUseCase = criarTarefaUseCase;
            _listarTarefasUseCase = listarTarefasUseCase;
            _concluirTarefaUseCase = concluirTarefaUseCase;
            _editarTarefaUseCase = editarTarefaUseCase;
            _deletarTarefaUseCase = deletarTarefaUseCase;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(CriarTarefaRequest request)
        {
            var result = await _validator.ValidateAsync(request);
            if (!result.IsValid)
                return BadRequest(result.Errors.Select(e => e.ErrorMessage));

            var response = await _criarTarefaUseCase.ExecuteAsync(request);
            return StatusCode(201, response);
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var response = await _listarTarefasUseCase.ExecuteAsync();
            return Ok(response);
        }

        [HttpPatch("{id}/concluir")]
        public async Task<IActionResult> Concluir(int id)
        {
            await _concluirTarefaUseCase.ExecuteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Editar(int id, EditarTarefaRequest request)
        {
            await _editarTarefaUseCase.ExecuteAsync(id, request);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            await _deletarTarefaUseCase.ExecuteAsync(id);
            return NoContent();
        }
    }
}