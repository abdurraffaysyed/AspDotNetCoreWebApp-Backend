using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebApp.Models;
namespace DotNetCoreWebApp.Repositories
{
    public interface IRepository
    {
        Task<ActionResult<IEnumerable<Playlist>>> GetPlayLists();

        Task<ActionResult<IEnumerable<Playlist>>> GetAllPlayLists();
        Task<JsonResult> GetPlayListById([FromQuery] string playlistid);
        Task<JsonResult> GetPlayListByIdAndTitle([FromQuery] string playlistid, [FromQuery] string playlisttitle);
        Task<JsonResult> GetPlayListByIdUsingPathVariable(string id);
        Task<ActionResult<Playlist>> CreatePlaylist(Playlist playlist);
        Task DeletePlaylist([FromQuery] string id);
        Task DeletePlaylistByTitle([FromQuery] string title);
        Task UpdatePlaylist([FromQuery] string title);

    }
}
