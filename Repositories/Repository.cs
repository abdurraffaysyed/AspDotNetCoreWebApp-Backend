using DotNetCoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApp.Repositories
{
    public class Repository : IRepository
    {

        private readonly AppDbContext appDbContext;
        public Repository(AppDbContext context)
        {
            appDbContext = context;
        }
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlayLists()
        {
            return await appDbContext.playlist.ToListAsync();
        }
        public async Task<ActionResult<IEnumerable<Playlist>>> GetAllPlayLists()
        {
            return await appDbContext.playlist.ToListAsync();
        }
        public async Task<JsonResult> GetPlayListById(string playlistid)
        {
            var playlist = appDbContext.playlist.Where(p => p.id == playlistid).ToListAsync();
            return new JsonResult(await playlist);
        }
        public async Task<JsonResult> GetPlayListByIdAndTitle(string playlistid, string playlisttitle)
        {
            var playlist = appDbContext.playlist.Where(p => p.id == playlistid && p.videotitle == playlisttitle).ToListAsync();
            return new JsonResult(await playlist);
        }
        public async Task<JsonResult> GetPlayListByIdUsingPathVariable(string id)
        {
            var playlist = appDbContext.playlist.Where(p => p.userid == id).ToListAsync();
            return new JsonResult(await playlist);
        }
        public async Task<ActionResult<Playlist>> CreatePlaylist(Playlist playlist)
        {
            await appDbContext.playlist.AddAsync(playlist);
            await appDbContext.SaveChangesAsync();
            return playlist;
        }

       

        public async Task DeletePlaylist(string id)
        {
            var context = appDbContext;
            var playlistobj = await context.playlist.FirstOrDefaultAsync(p => p.id == id);
            if (playlistobj != null)
            {
                context.playlist.Remove(playlistobj);
                await context.SaveChangesAsync();
            }


        }
        public async Task DeletePlaylistByTitle(string title)
        {
            var context = appDbContext;
            var playlistobj = await context.playlist.Where(p => p.videotitle == title).ToListAsync();
            if (playlistobj != null)
            {
                playlistobj.ForEach(obj => context.playlist.Remove(obj));

                await context.SaveChangesAsync();
            }


        }
        public async Task UpdatePlaylist(string title)
        {
            var playlistobj = await appDbContext.playlist.Where(p => p.videotitle == title).ToListAsync();
            playlistobj.ForEach(obj => obj.description = "helloooo");


        }
    }

}
