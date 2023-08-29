using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Table_Tennis_UK.Logging;
using Table_Tennis_UK.Models;
using Table_Tennis_UK.Models.Dto;
using Table_Tennis_UK.Repository.IRepository;

namespace Table_Tennis_UK.Controllers
{
    [Route("api/TableTennisClubAPI")]
    [ApiController]
    public class TableTennisClubAPIControllers : ControllerBase
    {
        protected APIResponse _response;
        private readonly ITableTennisClubRepository _dbTableTennisClub;
        private readonly ILogging _logger;
        private readonly IMapper _mapper;

        public TableTennisClubAPIControllers(ITableTennisClubRepository dbTableTennisClub, ILogging logger, IMapper mapper)
        {
            _dbTableTennisClub = dbTableTennisClub;
            _logger = logger;
            _mapper = mapper;
            this._response = new();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetTableTennisClubs()
        {
            try
            {
                _logger.Log("Getting all clubs", "");
                IEnumerable<TableTennisClub> tableTennisClubList = await _dbTableTennisClub.GetAllAsync();
                _response.Result = _mapper.Map<List<TableTennisClubDTO>>(tableTennisClubList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpGet("{id:int}", Name = "GetTableTennisClub")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> GetTableTennisClub(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get Club Error with Id" + id, "error");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var tableTennisClub = await _dbTableTennisClub.GetAsync(u => u.Id == id);
                if (tableTennisClub == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<TableTennisClubDTO>(tableTennisClub);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CreateTableTennisClub([FromBody] TableTennisClubCreateDTO createDTO)
        {
            try
            {

                if (await _dbTableTennisClub.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("CustomError", "Club already Exists!");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                TableTennisClub tableTennisClub = _mapper.Map<TableTennisClub>(createDTO);


                await _dbTableTennisClub.CreateAsync(tableTennisClub);
                _response.Result = _mapper.Map<TableTennisClubCreateDTO>(tableTennisClub);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetTableTennisClub", new { id = tableTennisClub.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{id:int}", Name = "DeleteTableTennisClub")]
        public async Task<ActionResult<APIResponse>> DeleteTableTennisClub(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var villa = await _dbTableTennisClub.GetAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                await _dbTableTennisClub.RemoveAsync(villa);
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut("{id:int}", Name = "UpdateTableTennisClub")]
        public async Task<ActionResult<APIResponse>> UpdateTableTennisClub(int id, [FromBody] TableTennisClubUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.Id)
                {
                    return BadRequest();
                }


                TableTennisClub model = _mapper.Map<TableTennisClub>(updateDTO);


                await _dbTableTennisClub.UpdateAsync(model);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
