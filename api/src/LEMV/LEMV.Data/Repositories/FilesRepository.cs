using Abp.MimeTypes;
using LEMV.Domain.Entities;
using LEMV.Domain.Interfaces.Repositories;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.IO;

namespace LEMV.Data.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IGridFSBucket _gridFS;

        public FilesRepository(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase("File");
            _gridFS = new GridFSBucket(_database);
        }

        public MediaInfo Upload(string fileName, Stream fileStream, string contentType)
        {
            fileStream.Position = 0;
            var options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument
                {
                    { "contentType", contentType },
                }
            };
            var objectId = _gridFS.UploadFromStream(fileName, fileStream, options);

            return this.Details(objectId.ToString());
        }

        public void Download(string id, Stream fileStream)
        {
            var objectId = ObjectId.Parse(id);
            _gridFS.DownloadToStream(objectId, fileStream);
        }

        public MediaInfo Details(string id)
        {
            var objectId = ObjectId.Parse(id);
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", objectId);

            var fileInfo = _gridFS.Find(filter).FirstOrDefault();

            if (fileInfo != null)
            {
                return new MediaInfo(
                    id,
                    fileInfo.Filename,
                    format: fileInfo.Metadata["contentType"].AsString,
                    fileInfo.Length
                );
            }

            return null;
        }

    }
}