using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PartiesApi.Services.Friend;
using PartiesApi.Utils;

namespace PartiesApi.Controllers;

/// <summary>
/// Управление друзьями
/// </summary>
[ApiController]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Route("api/[controller]")]
public class FriendController(IFriendService friendService, UserIdReader userIdReader) : ControllerBase
{
    /// <summary>
    /// Отправление заявки в друзья другому пользователю
    /// </summary>
    [HttpPut("SendFriendRequest")]
    public async Task<IActionResult> SendFriendRequestAsync([FromQuery] Guid friendRequestId)
    {
        try
        {
            var userId = userIdReader.GetUserIdFromAuth(HttpContext);
            var result = await friendService.SendFriendRequestAsync(userId, friendRequestId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (SecurityTokenExpiredException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// Получение полученных заявок, на которые еще не ответили
    /// </summary>
    [HttpGet("ReceivedFriendRequests")]
    public async Task<IActionResult> GetReceivedFriendRequestsAsync()
    {
        try
        {
            var userId = userIdReader.GetUserIdFromAuth(HttpContext);
            var result = await friendService.GetReceivedFriendRequestsAsync(userId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (SecurityTokenExpiredException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// Получение всех друзей
    /// </summary>
    [HttpGet("GetFriends")]
    public async Task<IActionResult> GetFriendsAsync()
    {
        try
        {
            var userId = userIdReader.GetUserIdFromAuth(HttpContext);
            var result = await friendService.GetFriendsAsync(userId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (SecurityTokenExpiredException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// Удаление пользователя из друзей
    /// </summary>
    [HttpDelete("DeleteFriend")]
    public async Task<IActionResult> DeleteFriendAsync([FromQuery] Guid friendId)
    {
        try
        {
            var userId = userIdReader.GetUserIdFromAuth(HttpContext);
            var result = await friendService.DeleteUserFromFriendsAsync(userId, friendId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (SecurityTokenExpiredException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// Принятие заявки в друзья
    /// </summary>
    [HttpPatch("AcceptRequest")]
    public async Task<IActionResult> AcceptFriendRequestsAsync([FromQuery] Guid fromUserId)
    {
        try
        {
            var userId = userIdReader.GetUserIdFromAuth(HttpContext);
            var result = await friendService.AcceptFriendRequestAsync(userId, fromUserId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (SecurityTokenExpiredException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    
    /// <summary>
    /// Отклонение заявки в друзья
    /// </summary>
    [HttpPatch("RejectRequest")]
    public async Task<IActionResult> RejectFriendRequestsAsync([FromQuery] Guid fromUserId)
    {
        try
        {
            var userId = userIdReader.GetUserIdFromAuth(HttpContext);
            var result = await friendService.RejectFriendRequestAsync(userId, fromUserId);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        catch (SecurityTokenExpiredException e)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}