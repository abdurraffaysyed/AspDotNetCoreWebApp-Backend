using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreWebApp.Models;
using DotNetCoreWebApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApp.Controllers
{
    [Route("api/playlist/")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        private readonly AppDbContext appDbContext;
        private readonly IRepository repository;
        public PlaylistController(IRepository repo)
        {
            repository = repo;
        }
        [HttpGet("pl")]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlayLists()
        {
            return await repository.GetPlayLists();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetAllPlayLists()
        {
            return await repository.GetAllPlayLists();
        }
        [HttpGet("playlistid")]
        public async Task<JsonResult> GetPlayListById([FromQuery] string playlistid)
        {
            return await repository.GetPlayListById(playlistid);
        }
        [HttpGet("playlistidandtitle")]
        public async Task<JsonResult> GetPlayListByIdAndTitle([FromQuery] string playlistid, [FromQuery] string playlisttitle)
        {
            return await repository.GetPlayListByIdAndTitle(playlistid,playlisttitle);
        }
        [HttpGet("{id}")]
        public async Task<JsonResult> GetPlayListByIdUsingPathVariable(string id)
        {
            return await repository.GetPlayListByIdUsingPathVariable(id);
        }
        [HttpPost("CreatePlaylist")]
        public async Task<ActionResult> CreatePlaylist(Playlist playlist)
        {
            return Ok(await repository.CreatePlaylist(playlist));
        }
        [HttpDelete("DeletePlaylist")]
        public async Task DeletePlaylist([FromQuery] string id)
        {
            await repository.DeletePlaylist(id);
        }
        [HttpDelete("DeletePlaylistByTitle")]
        public async Task DeletePlaylistByTitle([FromQuery] string title)
        {
            await repository.DeletePlaylistByTitle(title);
        }
        [HttpPut("UpdatePlaylist")]
        public async Task UpdatePlaylist([FromQuery] string title)
        {
            await repository.UpdatePlaylist(title);
        }

    }
}