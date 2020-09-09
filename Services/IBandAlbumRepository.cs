using BandAPI.Entities;
using System;
using System.Collections.Generic;

namespace BandAPI.Services
{
    public interface IBandAlbumRepository
    {

        IEnumerable<Album> GetAlbums(Guid BandId);
        Album GetAlbum(Guid bandId, Guid albumId);
        void AddAlbum(Guid bandId, Album album);
        void UpdateAlbum(Album album);
        void DeleteAlbum(Album album);

        IEnumerable<Band> GetBands();
        Band GetBand(Guid bandId);
        IEnumerable<Band> GetBands(IEnumerable<Guid> bandIds);
        void AddBand(Band band);
        void UpdateBand(Band band);
        void DeleteBand(Band band);

        bool BandExist(Guid bandId);
        bool AlbumExist(Guid albumId);
        bool Save();

    }
}
