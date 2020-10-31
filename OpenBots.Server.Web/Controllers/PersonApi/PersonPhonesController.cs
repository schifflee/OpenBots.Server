using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenBots.Server.DataAccess.Repositories;
using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using OpenBots.Server.Business;
using OpenBots.Server.Security;
using Microsoft.AspNetCore.Authorization;

namespace OpenBots.Server.WebAPI.Controllers
{
    [Route("api/v1/People/{personId}/[controller]")]
    [ApiController]
    [Authorize]
    public class PersonPhonesController : EntityController<PersonPhone>
    {
        public PersonPhonesController(
            IPersonPhoneRepository repository, 
            IMembershipManager membershipManager,
            ApplicationIdentityUserManager userManager,
            IHttpContextAccessor httpContextAccessor) : base(repository, userManager, httpContextAccessor, membershipManager)
        {
        }


        /// <summary>
        /// Gets all the phone numbers for a user.
        /// </summary>
        /// <param name="personId">person identifier</param>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="top">fetches the top 100</param>
        /// <param name="skip"></param>
        /// <response code="200">OK: Paginated List of all phone numbers .</response>       
        /// <response code="400">BadRequest: If person id is not provided/improper Guid</response>
        /// <response code="403">Forbidden: Person ID passed in the URL is not the same as the currently logged in user</response>
        /// <response code="422">UnprocessableEntity,Validation error</response>
        /// <returns>A paginated list of all the phone numbers for a particular person.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(PersonPhone), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public PaginatedList<PersonPhone> Get(
            [FromRoute] string personId,
            [FromQuery(Name = "$filter")] string filter = "",
            [FromQuery(Name = "$orderby")] string orderBy = "",
            [FromQuery(Name = "$top")] int top = 100,
            [FromQuery(Name = "$skip")] int skip = 0)
        {
            return base.GetMany(personId);
        }


        /// <summary>
        /// Gets the phone number detail for a particular person 
        /// </summary>
        /// <param name="personId">person identifier</param>
        /// <param name="id">Phone number identifier</param>
        /// <response code="200">OK,If phone number is available for the given id .></response>
        /// <response code="400">BadRequest, If the person Id/Phone Id is not provided or improper Guid.</response>
        /// <response code="403">Forbidden,Person ID passed in the URL is not the same as the currently logged in user</response>
        /// <response code="404">NotFound</response>
        /// <response code="422">Unprocessable entity,validation error.</response>
        /// <returns>Phone number detail for a particular id</returns>
        [HttpGet("{id}", Name = "GetPersonPhone")]
        [ProducesResponseType(typeof(PersonPhone), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string personId, string id)
        {
            return await base.GetEntity(id);
        }

        /// <summary>
        /// Adds a phone number for a person
        /// </summary>
        /// <param name="personId">person identifier</param>
        /// <param name="value">phone number to be added</param>
        /// <response code="200">OK,If the phone number details  has been added for a department</response>
        /// <response code="400">BadRequest,if person id is not provided/improper Guid.</response>
        /// <response code="403">Forbidden,Unauthorized access by user.</response>
        /// <response code="409">Conflict,concurrency error </response>
        /// <response code="422">UnprocessableEntity,If a duplicate record is being entered, phone details already exists</response>
        /// <returns>OK response, If the phone number has been added.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(PersonPhone), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Post(string personId, [FromBody] PersonPhone value)
        {
            value.PersonId = new Guid(personId);
            return await base.PostEntity(value);
        }

        /// <summary>
        /// Updates the phone number for a person
        /// </summary>
        /// <param name="personId">person identifier</param>
        /// <param name="id">phone number identifier</param>
        /// <param name="value">value to be updated</param>
        /// <response code="200">OK,If the details of phone number has been updated.</response>
        /// <response code="400">BadRequest,if person id/phone id is not provided/improper Guid.</response>
        /// <response code="403">Forbidden,unauthorized access by user</response>
        /// <response code="409">Conflict,concurrency error</response>
        /// <response code="422">Unprocessable entity,validation error.</response>
        /// <returns>Ok response, if the phone number has been updated.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Put(string personId, string id, [FromBody] PersonPhone value)
        {
            value.PersonId = new Guid(personId);
            return await base.PutEntity(id, value);
        }

        /// <summary>
        /// Deletes the phone number for a person
        /// </summary>
        /// <param name="id">phone number identifier</param>
        /// <response code="200">OK, if the phone details for the particular id has been deleted.</response>
        /// <response code="400">BadRequest,If phone id is not provided or improper guid.</response>
        /// <response code="403">Forbidden,unauthorized access</response>
        /// <returns>Ok response, if the phone number for the id has been deleted.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(string id)
        {
            return await base.DeleteEntity(id);
        }

        /// <summary>
        /// Updates Person/ Phone number detail
        /// </summary>
        /// <param name="id">Person phone identifier</param>
        /// <param name="value">Person Identifier,Phone number</param>
        /// <response code="200">OK,If update of Phone number/Person Identifier is successful. </response>
        /// <response code="400">BadRequest,if the Id is null or Id's dont match.</response>
        /// <response code="403">Forbidden,unauthorized access</response>
        /// <response code="422">Unprocessable entity,validation error</response>
        /// <returns>Ok response, if the phone number/ Person Id has been updated</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Patch(string id, [FromBody]JsonPatchDocument<PersonPhone> value)
        {
            return await base.PatchEntity(id, value);
        }
    }
}