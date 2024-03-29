﻿using SmartOtomasyonWebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartOtomasyonWebApp.Application.Interfaces.Repository
{
    public interface IDocumentRepository : IGenericRepositoryAsync<Document>
    {
        public Task<List<Document>> getPublicAsync();
        public Task<List<Document>> getByCategoryIdAsync(Guid id);
    }
}
