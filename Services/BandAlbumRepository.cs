using BandAPI.DbContexts;
using BandAPI.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace BandAPI.Services
{
    public class BandAlbumRepository : IBandAlbumRepository
    {

        public BandAlbumRepository(BandAlbumContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        private readonly BandAlbumContext _context;

        public void AddAlbum(Guid bandId, Album album)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            if (album == null)
                throw new ArgumentNullException(nameof(album));

            album.BandId = bandId;
            _context.Albums.Add(album);

        }

        public void AddBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Add(band);
        }

        public bool AlbumExist(Guid albumId)
        {
            if (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));

            return _context.Albums.Any(a => a.Id == albumId);
        }

        public bool BandExist(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.Any(a => a.Id == bandId);
        }

        public void DeleteAlbum(Album album)
        {
            if (album == null)
                throw new ArgumentNullException(nameof(album));

            _context.Albums.Remove(album);
        }

        public void DeleteBand(Band band)
        {
            if (band == null)
                throw new ArgumentNullException(nameof(band));

            _context.Bands.Remove(band);
        }

        public Album GetAlbum(Guid bandId, Guid albumId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));


            if  (albumId == Guid.Empty)
                throw new ArgumentNullException(nameof(albumId));

            return _context.Albums.Where(a => albumId == a.Id && bandId == a.BandId).FirstOrDefault();
        }

        public IEnumerable<Album> GetAlbums(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Albums.Where(a => a.BandId == bandId).OrderBy(a => a.Title).ToList();
        }

        public Band GetBand(Guid bandId)
        {
            if (bandId == Guid.Empty)
                throw new ArgumentNullException(nameof(bandId));

            return _context.Bands.FirstOrDefault(b => b.Id == bandId);
        }

        public IEnumerable<Band> GetBands()
        {
            return _context.Bands.ToList();
        }

        public IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds)
        {
            if (bandIds == null)
                throw new ArgumentNullException(nameof(bandIds));

            return _context.Bands.Where(b => bandIds.Contains(b.Id)).OrderBy(b => b.Name).ToList();
        }
        
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateAlbum(Album album)
        {
            //not implemented
            //if (album == null)
            //    throw new ArgumentNullException();

            //_context.Albums.Update(album);
        }

        public void UpdateBand(Band band)
        {
            //not implemented
            //if (band == null)
            //    throw new ArgumentNullException();

            //_context.Bands.Update(band);
        }
    }
}
