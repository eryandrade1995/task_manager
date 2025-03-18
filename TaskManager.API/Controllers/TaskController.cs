using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.DTOs;
using TaskManager.API.DTOs.ViewModels;
using TaskManager.Application.Interfaces;
using TaskManager.Core.Entities;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Save(TaskItemInputModel item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Code)) return BadRequest("O Código é obrigatório.");

                var exists = await _taskService.Get(item.Code);
                if (exists != null) return BadRequest("Este Código já existe.");
                if (string.IsNullOrEmpty(item.Description)) return BadRequest("A Descrição é obrigatória.");

                TaskItem newItem = new TaskItem() { Code = item.Code, Description = item.Description, Status = "P" };

                await _taskService.Save(newItem);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(bool atualizarStatus, TaskItemInputModel item)
        {
            try
            {
                if (string.IsNullOrEmpty(item.Code)) return BadRequest("O Código é obrigatório.");
                if (string.IsNullOrEmpty(item.Description)) return BadRequest("A Descrição é obrigatória.");
                
                var updateItem = new TaskItem() { Code = item.Code, Description = item.Description};
                if (atualizarStatus)
                    updateItem.Status = "C";

                await _taskService.Update(updateItem);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _taskService.GetAll();
                if (list == null) return NotFound();
                var listView = new List<TaskItemViewModel>();
                foreach (var item in list)
                {
                    listView.Add(new TaskItemViewModel() { Code = item.Code, Description = item.Description, Status = item.Status });
                }
                return Ok(listView);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                await _taskService.Delete(code);

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                var item = await _taskService.Get(code);
                if (item == null) return NotFound();

                var itemViewModel = new TaskItemViewModel() { Code = item.Code, Description = item.Description, Status = item.Status };

                return Ok(itemViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}